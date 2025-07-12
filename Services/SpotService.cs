using ParkingLotManagement.Services.Interfaces;
using ParkingSlot.Data;

namespace ParkingLotManagement.Services
{
    public class SpotService : ISpotService
    {
        private readonly ApplicationDbContext _context;

        public SpotService(ApplicationDbContext context)
        {
            _context = context;
        }

        public int GetTotalSpotCount()
        {
            // Assume there's only one ParkingSpot row holding TotalSpots
            var spot = _context.ParkingSpots.FirstOrDefault();
            return spot?.TotalSpots ?? 0;
        }

        public int GetReservedSpotCount()
        {
            var today = DateTime.Today;
            return _context.Subscriptions.Count(s =>
                !s.IsDeleted &&
                s.StartDate <= today &&
                s.EndDate >= today);
        }

        public int GetRegularSpotCount()
        {
            return GetTotalSpotCount() - GetReservedSpotCount();
        }
    }
}
