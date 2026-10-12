using FlightBooking.Dtos.NoShowDtos;

namespace FlightBooking.Services.NoShowService
{
    public class OverBookingRecommendationService
    {
        private readonly NoShowService _noShowService;

        public OverBookingRecommendationService(NoShowService mongoNoShowService)
        {
            _noShowService = mongoNoShowService;
        }

        public async Task<OverBookingRecommendationResult> GenerateRecommendationAsync(string flightDate, string flightSlot, int passengerCount, int capacity)
        {
            var slotRates = await _noShowService.GetSlotBasedNoShowRatesAsync();

            double noShowRate = 0;

            if (slotRates.ContainsKey(flightSlot))
            {
                noShowRate = slotRates[flightSlot];
            }

            int expectedNoShowPassenger = (int)Math.Round(passengerCount * (noShowRate / 100));

            int recommendedMaxSale = capacity + expectedNoShowPassenger;

            int extraSellableSeat = recommendedMaxSale - capacity;

            string riskLevel = "Low";

            if (noShowRate >= 7)
                riskLevel = "High";

            else if (noShowRate >= 5)
                riskLevel = "Medium";

            string recommendation =
                riskLevel switch
                {
                    "High" =>
                        "Agresif overbooking uygulanabilir",

                    "Medium" =>
                        "Kontrollü overbooking önerilir",

                    _ =>
                        "Standart satış politikası önerilir"
                };

            return new OverBookingRecommendationResult
            {
                FlightDate = flightDate,
                FlightSlot = flightSlot,
                ForecastPassengerCount = passengerCount,
                Capacity = capacity,
                ExpectedNoShowRate = noShowRate,
                ExpectedNoShowPassenger = expectedNoShowPassenger,
                RecommendedMaxTicketSale = recommendedMaxSale,
                ExtraSellableSeatCount = extraSellableSeat,
                RiskLevel = riskLevel,
                Recommendation = recommendation
            };
        }
    }
}
