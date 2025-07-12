using System.ComponentModel.DataAnnotations;

namespace ParkingLotManagement.Models
{
    public class PricingPlan
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Hourly Pricing (€)")]
        public decimal HourlyPricing { get; set; }

        [Required]
        [Display(Name = "Daily Pricing (€)")]
        public decimal DailyPricing { get; set; }

        [Required]
        [Display(Name = "Minimum Billable Hours")]
        public int MinimumHours { get; set; }

        [Required]
        [Display(Name = "Plan Type")]
        public string Type { get; set; } // e.g., "weekday" or "weekend"
    }
}
