using Microsoft.AspNetCore.Mvc;

namespace FlightBooking.ViewComponents.BoookingViewComponents
{
    public class _BookingAreaComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
