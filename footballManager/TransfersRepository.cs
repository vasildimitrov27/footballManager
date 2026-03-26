using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Windows.Forms;

public class TransfersRepository
{
    // Метод за взимане на историята с JOIN-ове
    public DataTable GetTransfersHistory(int? playerId = null)
    {
        string sql = @"
            SELECT t.TransferId, p.FullName AS PlayerName, 
                   c1.Name AS FromClub, c2.Name AS ToClub, 
                   t.TransferDate, t.Fee, t.Note
            FROM transfers t
            JOIN players p ON t.PlayerId = p.PlayerId
            LEFT JOIN clubs c1 ON t.FromClubId = c1.ClubId
            JOIN clubs c2 ON t.ToClubId = c2.ClubId";

        if (playerId.HasValue && playerId > 0)
            sql += " WHERE t.PlayerId = " + playerId.Value;

        sql += " ORDER BY t.TransferId ASC";
        return Db.GetDataTable(sql);
    }

    // КЛЮЧОВИЯТ МЕТОД: Трансфер в една транзакция
    public bool ExecuteTransfer(Transfer t)
    {
        using (var conn = Db.GetConnection())
        {
            conn.Open();
            MySqlTransaction transaction = conn.BeginTransaction();

            try
            {
                // 1. Записваме трансфера в историята
                string sqlInsert = @"INSERT INTO transfers (PlayerId, FromClubId, ToClubId, TransferDate, Fee, Note) 
                                   VALUES (@pId, @fromId, @toId, @date, @fee, @note)";
                MySqlCommand cmdInsert = new MySqlCommand(sqlInsert, conn, transaction);
                cmdInsert.Parameters.AddWithValue("@pId", t.PlayerId);
                cmdInsert.Parameters.AddWithValue("@fromId", (object)t.FromClubId ?? DBNull.Value);
                cmdInsert.Parameters.AddWithValue("@toId", t.ToClubId);
                cmdInsert.Parameters.AddWithValue("@date", t.TransferDate);
                cmdInsert.Parameters.AddWithValue("@fee", t.Fee);
                cmdInsert.Parameters.AddWithValue("@note", t.Note);
                cmdInsert.ExecuteNonQuery();

                // 2. Актуализираме текущия клуб на играча в таблица players
                string sqlUpdate = "UPDATE players SET ClubId = @newClubId WHERE PlayerId = @playerId";
                MySqlCommand cmdUpdate = new MySqlCommand(sqlUpdate, conn, transaction);
                cmdUpdate.Parameters.AddWithValue("@newClubId", t.ToClubId);
                cmdUpdate.Parameters.AddWithValue("@playerId", t.PlayerId);
                cmdUpdate.ExecuteNonQuery();

                // Ако всичко е наред - записваме окончателно
                transaction.Commit();
                return true;
            }
            catch (Exception ex)
            {
                // При грешка - отменяме всичко
                transaction.Rollback();
                MessageBox.Show("Трансферът пропадна: " + ex.Message);
                return false;
            }
        }
    }
}