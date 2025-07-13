using AutoMapper;
using ParkingLotManagement.Models;

namespace ParkingLotManagement.Subscribers
{
    public class SubscribersProfile : Profile
    {
        public SubscribersProfile()
        {
            CreateMap<Subscriber, SubscribersWebDto>().ReverseMap();
        }
    }
}
