using System;
using System.ComponentModel.DataAnnotations;

namespace ParkingLotManagement.Subscribers
{
    public class SubscribersWebDto
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string IdCardNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public DateTime Birthday { get; set; }

        [Required]
        public string PlateNumber { get; set; }
    }
}
