using Microsoft.AspNetCore.Mvc;
using VehicleBookingAPI.BAL;
using VehicleBookingAPI.Models;

namespace VehicleBookingAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]

    public class VehicleTypeController : Controller
    {
        #region Get All VehicleType
        [HttpGet]

        public IActionResult GetUVehicleType()
        {
            VehicleType_BALBase bal = new VehicleType_BALBase();
            List<VehicleTypeModel> vehicleTypeModels = bal.PR_SELECT_ALL_VehicalType();
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (vehicleTypeModels.Count > 0 && vehicleTypeModels != null)
            {
                response.Add("status", true);
                response.Add("message", "Data Found.");
                response.Add("data", vehicleTypeModels);
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

        #region Get Booking By ID
        [HttpGet("{VehicleTypeID}")]
        public IActionResult GetBooking(int VehicleTypeID)
        {
            VehicleType_BALBase bal = new VehicleType_BALBase();

            VehicleTypeModel vehicleTypeModel = bal.PR_SELECT_BY_PK_VehicalType(VehicleTypeID);
            Dictionary<string, dynamic> response
            = new Dictionary<string, dynamic>();
            if (vehicleTypeModel.VehicleTypeID != 0)
            {
                response.Add("status", true);
                response.Add("message", "Data Found");
                response.Add("data", vehicleTypeModel);
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
        public IActionResult DeleteVehicleType(int VehicleTypeID)
        {
            VehicleType_BALBase bal = new VehicleType_BALBase();
            bool IsSuccess = bal.PR_DELETE_VehicleType(VehicleTypeID);
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
        public IActionResult InsertVehicleType([FromForm] VehicleTypeModel vehicleTypeModel)
        {
            VehicleType_BALBase bal = new VehicleType_BALBase();
            bool IsSuccess = bal.PR_VehicalType_INSERT(vehicleTypeModel);
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
        public IActionResult UpdateVehicleType(int VehicleTypeID, [FromForm] VehicleTypeModel vehicleTypeModel)
        {
            VehicleType_BALBase bal = new VehicleType_BALBase();
            vehicleTypeModel.VehicleTypeID = VehicleTypeID;

            bool IsSuccess = bal.PR_UPDATE_VehicalType(VehicleTypeID, vehicleTypeModel);
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
