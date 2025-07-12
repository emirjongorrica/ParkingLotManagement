using System;
using System.ComponentModel.DataAnnotations;

namespace ParkingLotManagement.Models
{
    public class Subscriber
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "ID Card Number")]
        public string IdCardNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }

        [Required]
        [Display(Name = "Plate Number")]
        public string PlateNumber { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
