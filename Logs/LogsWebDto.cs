using System.ComponentModel.DataAnnotations;

namespace ParkingLotManagement.Logs;

public class LogsWebDto
{
    public int Id { get; set; }

    [Required]
    public string Code { get; set; }

    public int? SubscriptionId { get; set; }

    [Required]
    public DateTime CheckInTime { get; set; }

    public DateTime? CheckOutTime { get; set; }

    public decimal Price { get; set; }
}
