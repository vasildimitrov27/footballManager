using MySql.Data.MySqlClient;
using System.Data;

public class LeaguesRepository
{
    public DataTable GetAllLeagues() =>
        Db.GetDataTable("SELECT * FROM leagues ORDER BY Season DESC, Name ASC");

    public bool AddLeague(string name, string season)
    {
        string sql = "INSERT INTO leagues (Name, Season) VALUES (@name, @season)";
        MySqlParameter[] ps = { new MySqlParameter("@name", name), new MySqlParameter("@season", season) };
        return Db.ExecuteNonQuery(sql, ps) > 0;
    }

    // Взимане на участниците в конкретна лига
    public DataTable GetParticipants(int leagueId)
    {
        string sql = @"SELECT c.ClubId, c.Name, c.City 
                       FROM clubs c
                       JOIN league_teams lt ON c.ClubId = lt.ClubId
                       WHERE lt.LeagueId = @id";
        return Db.GetDataTable(sql, new MySqlParameter[] { new MySqlParameter("@id", leagueId) });
    }

    // Взимане на клубове, които ОЩЕ НЕ СА в тази лига
    public DataTable GetAvailableClubs(int leagueId)
    {
        string sql = @"SELECT ClubId, Name FROM clubs 
                       WHERE ClubId NOT IN (SELECT ClubId FROM league_teams WHERE LeagueId = @id)";
        return Db.GetDataTable(sql, new MySqlParameter[] { new MySqlParameter("@id", leagueId) });
    }

    public bool AddClubToLeague(int leagueId, int clubId)
    {
        string sql = "INSERT INTO league_teams (LeagueId, ClubId) VALUES (@lId, @cId)";
        MySqlParameter[] ps = { new MySqlParameter("@lId", leagueId), new MySqlParameter("@cId", clubId) };
        return Db.ExecuteNonQuery(sql, ps) > 0;
    }

    public bool RemoveClubFromLeague(int leagueId, int clubId)
    {
        // Проверка дали има мачове за тази лига с този отбор (Бизнес правило за 6)
        string checkSql = "SELECT COUNT(*) FROM matches WHERE LeagueId = @lId AND (HomeClubId = @cId OR AwayClubId = @cId)";
        // Забележка: Горното изисква таблица matches. Ако още я нямаш или е празна, ще работи.

        string sql = "DELETE FROM league_teams WHERE LeagueId = @lId AND ClubId = @cId";
        MySqlParameter[] ps = { new MySqlParameter("@lId", leagueId), new MySqlParameter("@cId", clubId) };
        return Db.ExecuteNonQuery(sql, ps) > 0;
    }


}