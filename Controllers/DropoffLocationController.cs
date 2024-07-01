using Microsoft.AspNetCore.Mvc;
using VehicleBookingAPI.BAL;
using VehicleBookingAPI.Models;

namespace VehicleBookingAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]

    public class DropoffLocationController : Controller
    {
        #region Get All DropoffLocation
        [HttpGet]

        public IActionResult GetDropoffLocation()
        {
            DropoffLocation_BALBase bal = new DropoffLocation_BALBase();
            List<DropoffLocationModel> dropoffLocations = bal.PR_SELECT_ALL_DropoffLocation();
            Dictionary<string, dynamic> response
                = new Dictionary<string, dynamic>();
            if (dropoffLocations.Count > 0 && dropoffLocations != null)
            {
                response.Add("status", true);
                response.Add("message", "Data Found.");
                response.Add("data", dropoffLocations);
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

        #region Get dropoffLocation By ID
        [HttpGet("{DropoffLocationID}")]
        public IActionResult GetDropoffLocation(int DropoffLocationID)
        {
            DropoffLocation_BALBase bal = new DropoffLocation_BALBase();

            DropoffLocationModel dropoffLocation = bal.PR_SELECT_BY_PK_DropoffLocation(DropoffLocationID);
            Dictionary<string, dynamic> response
            = new Dictionary<string, dynamic>();
            if (dropoffLocation.DropoffLocationID != 0)
            {
                response.Add("status", true);
                response.Add("message", "Data Found");
                response.Add("data", dropoffLocation);
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
        public IActionResult DeleteDropoffLocation(int DropoffLocationID)
        {
            DropoffLocation_BALBase dropoffLocation_BALBase = new DropoffLocation_BALBase();
            bool IsSuccess = dropoffLocation_BALBase.PR_DELETE_DropoffLocation(DropoffLocationID);
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
        public IActionResult InsertDropoffLocation([FromForm] DropoffLocationModel dropoffLocationModel)
        {
            DropoffLocation_BALBase dropoffLocation_BALBase = new DropoffLocation_BALBase();
            bool IsSuccess = dropoffLocation_BALBase.PR_DropoffLocation_INSERT(dropoffLocationModel);
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
        public IActionResult UpdateDropoffLocation(int DropffLocationID, [FromForm] DropoffLocationModel dropoffLocationModel)
        {
            DropoffLocation_BALBase dropoffLocation_BALBase = new DropoffLocation_BALBase();
            dropoffLocationModel.DropoffLocationID = DropffLocationID;

            bool IsSuccess = dropoffLocation_BALBase.PR_UPDATE_DropoffLocation(DropffLocationID, dropoffLocationModel);
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
