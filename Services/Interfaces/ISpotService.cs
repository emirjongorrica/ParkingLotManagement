namespace ParkingLotManagement.Services.Interfaces
{
    public interface ISpotService
    {
        int GetReservedSpotCount();
        int GetRegularSpotCount();
        int GetTotalSpotCount();
    }
}