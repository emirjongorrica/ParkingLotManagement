using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ParkingLotManagement.Models
{
    public class Subscription
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Subscription Code")]
        public string Code { get; set; }

        [Required]
        [ForeignKey("Subscriber")]
        public int SubscriberId { get; set; }

        public Subscriber Subscriber { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Display(Name = "Discount Value")]
        [Range(0, double.MaxValue)]
        public decimal DiscountValue { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
