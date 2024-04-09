using Common.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Entities;


[Table("transaction_history")]
public class TransactionHistory
{
    [Key]
    public long TransactionId { get; set; }

    public int UserId { get; set; }

    public float Ammount { get; set; }

    public TransactionType TransactionType { get; set; }
}
