using FlightBooking.Dtos.AgentDtos;

namespace FlightBooking.AgentServices
{
    public interface ITravelAgentService
    {
        //Task<string> GetRestaurantRecommendaionAsync(string cityName);

        Task<AgentResponseDto> AskAgentAsync(string prompt);
    }
}
