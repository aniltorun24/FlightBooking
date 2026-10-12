using FlightBooking.Dtos.AgentDtos;

namespace FlightBooking.Tools.WeatherTool
{
    public interface IWeatherTool
    {
        Task<WeatherResultDto> GetWeatherAsync(string city);
    }
}
