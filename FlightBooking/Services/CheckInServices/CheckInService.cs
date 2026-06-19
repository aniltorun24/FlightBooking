using FlightBooking.Dtos.CheckInDtos;
using FlightBooking.Entities;
using FlightBooking.Settings;
using MongoDB.Driver;

namespace FlightBooking.Services.CheckInServices
{
    public class CheckInService : ICheckInService
    {
        private readonly IMongoCollection<Booking> _bookingCollection;
        private readonly IMongoCollection<CheckIn> _checkInCollection;

        public CheckInService(IDatabaseSettings databaseSettings)
        {
            var client = new MongoClient(databaseSettings.ConnectionString);
            var database = client.GetDatabase(databaseSettings.DatabaseName);
            _bookingCollection = database.GetCollection<Booking>(databaseSettings.BookingCollectionName);
            _checkInCollection = database.GetCollection<CheckIn>(databaseSettings.CheckInCollectionName);
        }

        public Task CompleteCheckInAsync(CompleteCheckInDto dto)
        {
          
        }

        
    }
}
