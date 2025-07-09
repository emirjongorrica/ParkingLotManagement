using System.ComponentModel.DataAnnotations;

namespace ParkingLotManagement.Models;

public class ParkingSpot
{
    public int Id { get; set; }

    [Required]
    [Display(Name = "Total Parking Spots")]
    public int TotalSpots { get; set; }
}