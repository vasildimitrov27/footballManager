using System;
using System.Data;
using MySql.Data.MySqlClient;

public class ScheduleRepository
{
    // Взема всички лиги за падащото меню
    public DataTable GetLeaguesForCombo()
    {
        return Db.GetDataTable("SELECT LeagueId, CONCAT(Name, ' (', Season, ')') AS LeagueInfo FROM leagues ORDER BY Season DESC");
    }

    // Взема ID-тата на всички участници в избраната лига
    public DataTable GetLeagueParticipants(int leagueId)
    {
        string sql = "SELECT ClubId FROM league_teams WHERE LeagueId = @id";
        // КОРИГИРАНО: Параметърът е сложен в масив []
        return Db.GetDataTable(sql, new MySqlParameter[] { new MySqlParameter("@id", leagueId) });
    }

    // Проверява дали вече има генерирани мачове
    public bool HasMatches(int leagueId)
    {
        string sql = "SELECT COUNT(*) FROM matches WHERE LeagueId = @id";

        // КОРИГИРАНО: Вместо ExecuteScalar, ползваме наличния GetDataTable
        DataTable dt = Db.GetDataTable(sql, new MySqlParameter[] { new MySqlParameter("@id", leagueId) });

        if (dt.Rows.Count > 0)
        {
            return Convert.ToInt32(dt.Rows[0][0]) > 0;
        }
        return false;
    }

    // Изтрива стара програма
    public void DeleteMatches(int leagueId)
    {
        string sql = "DELETE FROM matches WHERE LeagueId = @id";
        // КОРИГИРАНО: Параметърът е сложен в масив []
        Db.ExecuteNonQuery(sql, new MySqlParameter[] { new MySqlParameter("@id", leagueId) });
    }

    // Записва един мач
    public void InsertMatch(int leagueId, int roundNo, int homeId, int awayId, DateTime date)
    {
        string sql = @"INSERT INTO matches (LeagueId, RoundNo, HomeClubId, AwayClubId, MatchDate) 
                       VALUES (@leagueId, @roundNo, @homeId, @awayId, @date)";

        // КОРИГИРАНО: Всички параметри са събрани в един масив, вместо да се подават запетая по запетая
        MySqlParameter[] ps = new MySqlParameter[]
        {
            new MySqlParameter("@leagueId", leagueId),
            new MySqlParameter("@roundNo", roundNo),
            new MySqlParameter("@homeId", homeId),
            new MySqlParameter("@awayId", awayId),
            new MySqlParameter("@date", date)
        };

        Db.ExecuteNonQuery(sql, ps);
    }

    // Взема готовата програма с JOIN-ове за имената на отборите
    public DataTable GetSchedule(int leagueId)
    {
        string sql = @"SELECT m.RoundNo AS 'Кръг', hc.Name AS 'Домакин', ac.Name AS 'Гост', m.MatchDate AS 'Дата'
                       FROM matches m
                       JOIN clubs hc ON m.HomeClubId = hc.ClubId
                       JOIN clubs ac ON m.AwayClubId = ac.ClubId
                       WHERE m.LeagueId = @id
                       ORDER BY m.RoundNo ASC, m.MatchId ASC";

        // КОРИГИРАНО: Параметърът е сложен в масив []
        return Db.GetDataTable(sql, new MySqlParameter[] { new MySqlParameter("@id", leagueId) });
    }
}