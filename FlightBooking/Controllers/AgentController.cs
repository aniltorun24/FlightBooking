using FlightBooking.AgentServices;
using FlightBooking.Dtos.AgentDtos;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace FlightBooking.Controllers
{
    public class AgentController : Controller
    {
        private readonly ITravelAgentService _travelAgentService;

        public AgentController(ITravelAgentService travelAgentService)
        {
            _travelAgentService = travelAgentService;
        }

        [HttpGet]
        public async Task<IActionResult> AskAgent()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AskAgent([FromBody]AgentPromptRequestDto dto)
        {
           var result = await _travelAgentService.AskAgentAsync(dto.prompt);
            return Json(result);
        }
    }
}
