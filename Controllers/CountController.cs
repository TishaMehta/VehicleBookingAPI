using Microsoft.AspNetCore.Mvc;
using VehicleBookingAPI.BAL;
using VehicleBookingAPI.Models;

namespace VehicleBookingAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]

    public class CountController : Controller
    {
        #region Get All Location
        [HttpGet]

        public IActionResult GetCount()
        {
            Count_BALBase bal = new Count_BALBase();
            List<CountModel> countModels = bal.PR_DASHBOARD_COUNTS();
            Dictionary<string, dynamic> response
                = new Dictionary<string, dynamic>();
            if (countModels.Count > 0 && countModels != null)
            {
                response.Add("status", true);
                response.Add("message", "Data Found.");
                response.Add("data", countModels);
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Data Not Found.");
                response.Add("data", null);
                return NotFound(response);
            }
        }
        #endregion    }
    }
}
