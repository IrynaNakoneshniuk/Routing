using Microsoft.AspNetCore.Mvc;


namespace Routing.Controllers
{
    public class GettimesuniversalController : Controller
    {
        [ActionName("Utc")]
        public IActionResult GetUtcTimes()
        {
            DateTime utcNow = DateTime.UtcNow;

            TimeZoneInfo cetTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time");
            DateTime cetNow = TimeZoneInfo.ConvertTimeFromUtc(utcNow, cetTimeZone);

            string formattedDateTime = cetNow.ToString("dd/MM/yyyy HH:mm:ss");

            return Content(formattedDateTime);
        }

        [ActionName("Time")]
        public IActionResult GetCurrentTimes(string id)
        {
            string resTime= DateTime.Now.ToString("dd/MM/yyyy HH:mm");

            if(id == "d") {
                var date = DateTime.Now.ToString("dd/MM/yyyy");
                resTime = $"Current date - {date}" ;
            }
            else if(id == "t")
            {
                var time = DateTime.Now.ToString("HH:mm:ss");
                resTime = $"Current time - {time}";
            }

            return Content(resTime);
        }
    }
}