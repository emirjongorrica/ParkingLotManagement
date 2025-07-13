using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkingLotManagement.Models;

public class Log
{
    public int Id { get; set; }

    [Required]
    [Display(Name = "Log Code")]
    public string Code { get; set; }

    [ForeignKey("Subscription")]
    public int? SubscriptionId { get; set; }  // Nullable

    public Subscription? Subscription { get; set; }

    [Required]
    [Display(Name = "Check-in Time")]
    public DateTime CheckInTime { get; set; }

    [Display(Name = "Check-out Time")]
    public DateTime? CheckOutTime { get; set; }

    [Range(0, double.MaxValue)]
    public decimal Price { get; set; } = 0;
}
