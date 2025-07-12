using System;
using ParkingLotManagement.Models;

namespace ParkingLotManagement.Services.Interfaces
{
    public interface IPricingService
    {
        decimal CalculatePrice(DateTime checkIn, DateTime checkOut, PricingPlan plan);
    }
}
