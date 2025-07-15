using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ParkingLotManagement.Data;
using ParkingLotManagement.Models;
using ParkingLotManagement.Services.Interfaces;


namespace ParkingLotManagement.Logs;

[Route("api/[controller]")]
[ApiController]
public class LogsController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly ILogService _logService;

    public LogsController(ApplicationDbContext context, IMapper mapper, ILogService logService)
    {
        _context = context;
        _mapper = mapper;
        _logService = logService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<LogsWebDto>>> GetLogs()
    {
        var logs = await _context.Logs.ToListAsync();
        return Ok(_mapper.Map<List<LogsWebDto>>(logs));
    }

    [HttpGet("date/{date}")]
    public async Task<ActionResult<IEnumerable<LogsWebDto>>> GetLogsByDate(DateTime date)
    {
        var logs = await _context.Logs
            .Where(l => l.CheckInTime.Date == date.Date)
            .ToListAsync();

        return Ok(_mapper.Map<List<LogsWebDto>>(logs));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<LogsWebDto>> GetLog(int id)
    {
        var log = await _context.Logs.FindAsync(id);
        if (log == null)
            return NotFound();

        return _mapper.Map<LogsWebDto>(log);
    }

    [HttpPost]
    public ActionResult<LogsWebDto> CreateLog(LogsWebDto dto)
    {
        var log = _mapper.Map<Log>(dto);
        var created = _logService.CreateLog(log);

        return CreatedAtAction(nameof(GetLog), new { id = created.Id }, _mapper.Map<LogsWebDto>(created));
    }
}