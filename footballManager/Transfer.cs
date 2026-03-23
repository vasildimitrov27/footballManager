using System;

public class Transfer
{
    public int TransferId { get; set; }
    public int PlayerId { get; set; }
    public int? FromClubId { get; set; } // Nullable, ако е свободен агент
    public int ToClubId { get; set; }
    public DateTime TransferDate { get; set; }
    public decimal Fee { get; set; }
    public string Note { get; set; }
}