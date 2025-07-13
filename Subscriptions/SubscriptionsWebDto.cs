using System.ComponentModel.DataAnnotations;

namespace ParkingLotManagement.Subscriptions;

public class SubscriptionsWebDto
{
    public int Id { get; set; }

    [Required]
    public string Code { get; set; }

    [Required]
    public int SubscriberId { get; set; }

    [Required]
    public decimal Price { get; set; }

    public decimal DiscountValue { get; set; }

    [Required]
    public DateTime StartDate { get; set; }

    [Required]
    public DateTime EndDate { get; set; }
}
