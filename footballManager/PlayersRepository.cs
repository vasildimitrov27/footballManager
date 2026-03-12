using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;

public class PlayersRepository
{
    // Комбинирано четене с филтри
    public DataTable GetPlayers(int clubId = 0, string position = "All", string searchName = "")
    {
        string sql = @"
        SELECT p.PlayerId, p.FullName, p.BirthDate, p.Position, p.ShirtNumber, p.ClubId, c.Name AS ClubName
        FROM players p
        JOIN clubs c ON p.ClubId = c.ClubId
        WHERE 1=1";

        List<MySqlParameter> parameters = new List<MySqlParameter>();

        if (clubId > 0)
        {
            sql += " AND p.ClubId = @clubId";
            parameters.Add(new MySqlParameter("@clubId", clubId));
        }

        if (position != "All" && !string.IsNullOrEmpty(position))
        {
            sql += " AND p.Position = @position";
            parameters.Add(new MySqlParameter("@position", position));
        }

        if (!string.IsNullOrWhiteSpace(searchName))
        {
            sql += " AND p.FullName LIKE @searchName";
            parameters.Add(new MySqlParameter("@searchName", "%" + searchName + "%"));
        }

        sql += " ORDER BY p.PlayerId ASC";

        return Db.GetDataTable(sql, parameters.ToArray());
    }

    public bool Add(Player player)
    {
        string sql = "INSERT INTO players (ClubId, FullName, BirthDate, Position, ShirtNumber) VALUES (@clubId, @fullName, @birthDate, @position, @shirtNumber)";
        MySqlParameter[] ps = {
            new MySqlParameter("@clubId", player.ClubId),
            new MySqlParameter("@fullName", player.FullName),
            new MySqlParameter("@birthDate", player.BirthDate.ToString("yyyy-MM-dd")),
            new MySqlParameter("@position", player.Position),
            new MySqlParameter("@shirtNumber", player.ShirtNumber)
        };
        return Db.ExecuteNonQuery(sql, ps) > 0;
    }

    public bool Update(Player player)
    {
        string sql = "UPDATE players SET ClubId=@clubId, FullName=@fullName, BirthDate=@birthDate, Position=@position, ShirtNumber=@shirtNumber WHERE PlayerId=@id";
        MySqlParameter[] ps = {
            new MySqlParameter("@clubId", player.ClubId),
            new MySqlParameter("@fullName", player.FullName),
            new MySqlParameter("@birthDate", player.BirthDate.ToString("yyyy-MM-dd")),
            new MySqlParameter("@position", player.Position),
            new MySqlParameter("@shirtNumber", player.ShirtNumber),
            new MySqlParameter("@id", player.PlayerId)
        };
        return Db.ExecuteNonQuery(sql, ps) > 0;
    }

    public bool Delete(int id)
    {
        string sql = "DELETE FROM players WHERE PlayerId = @id";
        MySqlParameter[] ps = { new MySqlParameter("@id", id) };
        return Db.ExecuteNonQuery(sql, ps) > 0;
    }

    // Помощен метод за зареждане на ComboBox с клубове
    public DataTable GetClubsForDropdown()
    {
        return Db.GetDataTable("SELECT ClubId, Name FROM clubs ORDER BY Name");
    }
}