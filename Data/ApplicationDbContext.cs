using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ParkingLotManagement.Models;

namespace ParkingSlot.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<ParkingSpot> ParkingSpots { get; set; }
    public DbSet<PricingPlan> PricingPlans { get; set; }
    public DbSet<Subscriber> Subscribers { get; set; }

}