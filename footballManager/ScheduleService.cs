using System;
using System.Collections.Generic;
using System.Data;

public class ScheduleService
{
    private ScheduleRepository repo = new ScheduleRepository();

    public DataTable GetLeagues() => repo.GetLeaguesForCombo();
    public DataTable GetScheduleTable(int leagueId) => repo.GetSchedule(leagueId);
    public bool LeagueHasMatches(int leagueId) => repo.HasMatches(leagueId);

    public void GenerateTournamentSchedule(int leagueId, bool twoRounds)
    {
        DataTable dtTeams = repo.GetLeagueParticipants(leagueId);

        // Валидация: Минимум 2 отбора
        if (dtTeams.Rows.Count < 2)
            throw new InvalidOperationException("Трябва да има поне 2 отбора в лигата, за да се генерира програма!");

        // Конвертираме таблицата в списък с ID-та
        List<int> teams = new List<int>();
        foreach (DataRow row in dtTeams.Rows)
        {
            teams.Add(Convert.ToInt32(row["ClubId"]));
        }

        // Ако отборите са нечетен брой, добавяме почиващ отбор (-1)
        if (teams.Count % 2 != 0) teams.Add(-1);

        int numTeams = teams.Count;
        int numRounds = numTeams - 1;
        int matchesPerRound = numTeams / 2;
        DateTime startDate = DateTime.Now.Date.AddDays(7); // Първият кръг започва след седмица

        // Изчистваме старите мачове, ако има такива
        repo.DeleteMatches(leagueId);

        // Алгоритъм на Бергер - Първи полусезон
        for (int round = 0; round < numRounds; round++)
        {
            for (int match = 0; match < matchesPerRound; match++)
            {
                int home = (round + match) % (numTeams - 1);
                int away = (numTeams - 1 - match + round) % (numTeams - 1);

                if (match == 0) away = numTeams - 1;

                int homeId = teams[home];
                int awayId = teams[away];

                if (homeId == -1 || awayId == -1) continue; // Някой почива в този кръг

                // Балансиране на домакинствата
                if (round % 2 != 0)
                {
                    int temp = homeId; homeId = awayId; awayId = temp;
                }

                DateTime matchDate = startDate.AddDays(round * 7); // Всеки кръг е през седмица
                repo.InsertMatch(leagueId, round + 1, homeId, awayId, matchDate);
            }
        }

        // Втори полусезон (Разменени гостувания)
        if (twoRounds)
        {
            DataTable firstHalf = repo.GetSchedule(leagueId);
            // За по-лесно в базата данни, четем каквото току-що записахме и го записваме обратно с разменени отбори
            // Нова заявка директно в базата за втория полусезон спестява сложни изчисления в паметта
            GenerateSecondHalf(leagueId, numRounds, startDate);
        }
    }

    private void GenerateSecondHalf(int leagueId, int numRounds, DateTime startDate)
    {
        // Взимаме мачовете от първия полусезон директно от базата (сурови данни)
        DataTable dt = Db.GetDataTable("SELECT RoundNo, HomeClubId, AwayClubId, MatchDate FROM matches WHERE LeagueId = " + leagueId);

        foreach (DataRow row in dt.Rows)
        {
            int oldRound = Convert.ToInt32(row["RoundNo"]);
            int homeId = Convert.ToInt32(row["HomeClubId"]);
            int awayId = Convert.ToInt32(row["AwayClubId"]);
            DateTime oldDate = Convert.ToDateTime(row["MatchDate"]);

            int newRound = oldRound + numRounds;
            DateTime newDate = oldDate.AddDays(numRounds * 7);

            // Записваме обратно с РАЗМЕНЕНИ места (Гостът става Домакин)
            repo.InsertMatch(leagueId, newRound, awayId, homeId, newDate);
        }
    }
}