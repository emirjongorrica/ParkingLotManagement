using AutoMapper;
using ParkingLotManagement.Models;

namespace ParkingLotManagement.Subscriptions;

public class SubscriptionsProfile : Profile
{
    public SubscriptionsProfile()
    {
        CreateMap<Subscription, SubscriptionsWebDto>().ReverseMap();
    }
}
