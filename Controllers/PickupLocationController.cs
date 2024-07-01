using Microsoft.AspNetCore.Mvc;
using VehicleBookingAPI.BAL;
using VehicleBookingAPI.Models;

namespace VehicleBookingAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]

    public class PickupLocationController : Controller
    {
        #region Get All Location
        [HttpGet]

        public IActionResult GetPickupLocation()
        {
            PickupLocation_BALBase bal = new PickupLocation_BALBase();
            List<PickupLocation> PickupLocations = bal.PR_SELECT_ALL_PickupLocation();
            Dictionary<string, dynamic> response
                = new Dictionary<string, dynamic>();
            if (PickupLocations.Count > 0 && PickupLocations != null)
            {
                response.Add("status", true);
                response.Add("message", "Data Found.");
                response.Add("data", PickupLocations);
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
        #endregion

        #region Get Location By ID
        [HttpGet("{PickupLocationID}")]
        public IActionResult GetPickupLocation(int PickupLocationID)
        {
            PickupLocation_BALBase bal = new PickupLocation_BALBase();

            PickupLocation Location = bal.PR_SELECT_BY_PK_PickupLocation(PickupLocationID);
            Dictionary<string, dynamic> response
            = new Dictionary<string, dynamic>();
            if (Location.PickupLocationID != 0)
            {
                response.Add("status", true);
                response.Add("message", "Data Found");
                response.Add("data", Location);
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Data Not Found");
                response.Add("data", null);
                return NotFound(response);
            }
        }
        #endregion

        #region DELETE
        [HttpDelete]
        public IActionResult DeletePickupLocation(int PickupLocatioID)
        {
            PickupLocation_BALBase ballocation = new PickupLocation_BALBase();
            bool IsSuccess = ballocation.PR_DELETE_PickupLocation(PickupLocatioID);
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (IsSuccess)
            {
                response.Add("Status", true);
                response.Add("message", "Data Deleted Sucessfully");
                return Ok(response);
            }
            else
            {
                response.Add("Status", false);
                response.Add("message", "Some Error Has been occured");
                return Ok(response);
            }
        }
        #endregion

        #region Insert
        [HttpPost]
        public IActionResult InsertLocation([FromForm] PickupLocation LocationModel)
        {
            PickupLocation_BALBase ballocation = new PickupLocation_BALBase();
            bool IsSuccess = ballocation.PR_PickupLocation_INSERT(LocationModel);
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (IsSuccess)
            {
                response.Add("Status", true);
                response.Add("message", "Data Insert Sucessfully");
                return Ok(response);
            }
            else
            {
                response.Add("Status", false);
                response.Add("message", "Some Error Has been occured");
                return Ok(response);
            }
        }

        #endregion

        #region Update
        [HttpPut]
        public IActionResult UpdatePickupLocation(int PickupLocationID, [FromForm] PickupLocation PickupLocationModel)
        {
            PickupLocation_BALBase balpickuplocation = new PickupLocation_BALBase();
            PickupLocationModel.PickupLocationID = PickupLocationID;

            bool IsSuccess = balpickuplocation.PR_UPDATE_PickupLocation(PickupLocationID, PickupLocationModel);
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (IsSuccess)
            {
                response.Add("Status", true);
                response.Add("message", "Data Update Sucessfully");
                return Ok(response);
            }
            else
            {
                response.Add("Status", false);
                response.Add("message", "Some Error Has been occured");
                return Ok(response);
            }
        }

        #endregion
    }
}
