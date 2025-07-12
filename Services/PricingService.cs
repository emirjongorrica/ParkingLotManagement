using ParkingLotManagement.Models;
using ParkingLotManagement.Services.Interfaces;

namespace ParkingLotManagement.Services
{
    public class PricingService : IPricingService
    {
        public decimal CalculatePrice(DateTime checkIn, DateTime checkOut, PricingPlan plan)
        {
            // Placeholder logic
            return 0;
        }
    }
}
