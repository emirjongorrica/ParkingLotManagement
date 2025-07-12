using ParkingLotManagement.Models;
using ParkingLotManagement.Services.Interfaces;
using System;

namespace ParkingLotManagement.Services
{
    public class PricingService : IPricingService
    {
        public decimal CalculatePrice(DateTime checkIn, DateTime checkOut, PricingPlan plan)
        {
            var totalMinutes = (checkOut - checkIn).TotalMinutes;

            // 1. Grace Period
            if (totalMinutes <= 15)
                return 0;

            var totalHours = (decimal)(checkOut - checkIn).TotalHours;
            var fullDays = (int)totalHours / 24;
            var remainingHours = totalHours - (fullDays * 24);

            // 2. If within one day and hours ≤ min hours, charge hourly
            if (fullDays == 0 && remainingHours <= plan.MinimumHours)
            {
                return Math.Round(remainingHours * plan.HourlyPricing, 2);
            }

            // 3. If remaining hours are less than min hours, charge hourly
            if (remainingHours > 0 && remainingHours <= plan.MinimumHours)
            {
                return Math.Round((fullDays * plan.DailyPricing) + (remainingHours * plan.HourlyPricing), 2);
            }

            // 4. Else treat as additional day
            var totalDays = fullDays + 1;
            return Math.Round(totalDays * plan.DailyPricing, 2);
        }
    }
}
