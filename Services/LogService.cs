using ParkingLotManagement.Models;
using ParkingLotManagement.Services.Interfaces;
using ParkingLotManagement.Data;

namespace ParkingLotManagement.Services;

public class LogService : ILogService
{
    private readonly ApplicationDbContext _context;
    private readonly IPricingService _pricingService;

    public LogService(ApplicationDbContext context, IPricingService pricingService)
    {
        _context = context;
        _pricingService = pricingService;
    }

    public Log CreateLog(Log log)
    {
        if (log.SubscriptionId != null)
        {
            log.Price = 0; // Subscribers park for free
        }
        else
        {
            // Determine pricing plan based on weekday/weekend
            var plan = _context.PricingPlans.FirstOrDefault(p =>
                p.Type.ToLower() == (log.CheckInTime.DayOfWeek == DayOfWeek.Saturday || log.CheckInTime.DayOfWeek == DayOfWeek.Sunday
                    ? "weekend"
                    : "weekday"));

            if (plan == null)
                throw new Exception("No pricing plan found for this day.");

            log.Price = _pricingService.CalculatePrice(log.CheckInTime, log.CheckOutTime ?? DateTime.Now, plan);
        }

        _context.Logs.Add(log);
        _context.SaveChanges();

        return log;
    }
}
