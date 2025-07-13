using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkingLotManagement.Data;
using ParkingLotManagement.Models;

namespace ParkingLotManagement.Subscriptions;

[Route("api/[controller]")]
[ApiController]
public class SubscriptionsController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public SubscriptionsController(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SubscriptionsWebDto>>> GetSubscriptions()
    {
        var subscriptions = await _context.Subscriptions
            .Where(s => !s.IsDeleted)
            .ToListAsync();

        return Ok(_mapper.Map<List<SubscriptionsWebDto>>(subscriptions));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SubscriptionsWebDto>> GetSubscription(int id)
    {
        var subscription = await _context.Subscriptions.FindAsync(id);
        if (subscription == null || subscription.IsDeleted)
            return NotFound();

        return _mapper.Map<SubscriptionsWebDto>(subscription);
    }

    [HttpPost]
    public async Task<IActionResult> CreateSubscription(SubscriptionsWebDto dto)
    {
        if (_context.Subscriptions.Any(s => s.Code == dto.Code && !s.IsDeleted))
            return BadRequest("Subscription code must be unique.");

        if (_context.Subscriptions.Any(s =>
            s.SubscriberId == dto.SubscriberId &&
            !s.IsDeleted &&
            s.StartDate <= dto.EndDate &&
            s.EndDate >= dto.StartDate))
        {
            return BadRequest("Subscriber already has an active subscription in this period.");
        }

        var subscription = _mapper.Map<Subscription>(dto);
        _context.Subscriptions.Add(subscription);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetSubscription), new { id = subscription.Id }, _mapper.Map<SubscriptionsWebDto>(subscription));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSubscription(int id)
    {
        var subscription = await _context.Subscriptions.FindAsync(id);
        if (subscription == null)
            return NotFound();

        subscription.IsDeleted = true;
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
