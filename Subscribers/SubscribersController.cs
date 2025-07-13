using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkingLotManagement.Models;
using AutoMapper;
using ParkingLotManagement.Data;

namespace ParkingLotManagement.Subscribers;

[Route("api/[controller]")]
[ApiController]
public class SubscribersController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public SubscribersController(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<SubscribersWebDto>>> GetSubscribers()
    {
        var subscribers = await _context.Subscribers
            .Where(s => !s.IsDeleted)
            .ToListAsync();

        return Ok(_mapper.Map<List<SubscribersWebDto>>(subscribers));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<SubscribersWebDto>> GetSubscriber(int id)
    {
        var subscriber = await _context.Subscribers.FindAsync(id);
        if (subscriber == null || subscriber.IsDeleted)
            return NotFound();

        return _mapper.Map<SubscribersWebDto>(subscriber);
    }

    [HttpPost]
    public async Task<IActionResult> CreateSubscriber(SubscribersWebDto dto)
    {
        if (_context.Subscribers.Any(s => s.IdCardNumber == dto.IdCardNumber && !s.IsDeleted))
            return BadRequest("Subscriber with this ID card number already exists.");

        var subscriber = _mapper.Map<Subscriber>(dto);

        _context.Subscribers.Add(subscriber);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetSubscriber), new { id = subscriber.Id }, _mapper.Map<SubscribersWebDto>(subscriber));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSubscriber(int id)
    {
        var subscriber = await _context.Subscribers.FindAsync(id);
        if (subscriber == null)
            return NotFound();

        subscriber.IsDeleted = true;
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
