namespace FlightBooking.Dtos.RestaurantDtos
{
    public class RestaurantDto
    {
        public string PlaceId { get; set; }
        public string Name { get; set; }
        public string Adress { get; set; }
        public double? Rating { get; set; }
        public int? UserRatingCount { get; set; }
        public string PriceLevel { get; set; }
        public string GoogleMapsUrl { get; set; }
    }
}
