using MySql.Data.MySqlClient;
using System.Data;

public class ClubRepository
{
    public DataTable GetAllClubs()
    {
        return Db.GetDataTable("SELECT ClubId, Name, City FROM clubs ORDER BY Name");
    }

    public bool Add(Club club)
    {
        string sql = "INSERT INTO clubs (Name, City) VALUES (@name, @city)";
        MySqlParameter[] ps = {
            new MySqlParameter("@name", club.Name),
            new MySqlParameter("@city", club.City)
        };
        return Db.ExecuteNonQuery(sql, ps) > 0;
    }

    public bool Update(Club club)
    {
        string sql = "UPDATE clubs SET Name=@name, City=@city WHERE ClubId=@id";
        MySqlParameter[] ps = {
            new MySqlParameter("@name", club.Name),
            new MySqlParameter("@city", club.City),
            new MySqlParameter("@id", club.ClubId)
        };
        return Db.ExecuteNonQuery(sql, ps) > 0;
    }

    public bool Delete(int id)
    {
        // Опитай да промениш името на параметъра на @id, ако е било друго
        string sql = "DELETE FROM clubs WHERE ClubId = @id";
        MySqlParameter[] ps = { new MySqlParameter("@id", id) };

        int result = Db.ExecuteNonQuery(sql, ps);
        return result > 0;
    }
}