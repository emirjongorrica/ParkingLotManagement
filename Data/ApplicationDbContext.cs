﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ParkingLotManagement.Models;

namespace ParkingLotManagement.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<ParkingSpot> ParkingSpots { get; set; }
    public DbSet<PricingPlan> PricingPlans { get; set; }
    public DbSet<Subscriber> Subscribers { get; set; }
    public DbSet<Subscription> Subscriptions { get; set; }
    public DbSet<Log> Logs { get; set; }

}