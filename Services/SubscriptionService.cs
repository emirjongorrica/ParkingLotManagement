using ParkingLotManagement.Services.Interfaces;
using ParkingLotManagement.Data;

namespace ParkingLotManagement.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly ApplicationDbContext _context;

        public SubscriptionService(ApplicationDbContext context)
        {
            _context = context;
        }

        public decimal CalculateSubscriptionPrice(int totalDays, decimal weekdayRate, decimal discount)
        {
            var total = totalDays * weekdayRate;
            return Math.Max(0, total - discount); // Prevent negative price
        }

        public bool HasActiveSubscription(int subscriberId)
        {
            var today = DateTime.Today;
            return _context.Subscriptions.Any(s =>
                s.SubscriberId == subscriberId &&
                !s.IsDeleted &&
                s.StartDate <= today &&
                s.EndDate >= today);
        }

        public bool IsSubscriptionCodeUnique(string code)
        {
            return !_context.Subscriptions.Any(s => s.Code == code);
        }
    }
}
