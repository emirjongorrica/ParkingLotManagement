using AutoMapper;
using ParkingLotManagement.Models;

namespace ParkingLotManagement.Logs;

public class LogsProfile : Profile
{
    public LogsProfile()
    {
        CreateMap<Log, LogsWebDto>().ReverseMap();
    }
}