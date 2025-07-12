using ParkingLotManagement.Models;

namespace ParkingLotManagement.Services.Interfaces
{
    public interface ISubscriptionService
    {
        decimal CalculateSubscriptionPrice(int totalDays, decimal weekdayRate, decimal discount);
    }
}
