using Microsoft.AspNetCore.Mvc;
using VehicleBookingAPI.BAL;
using VehicleBookingAPI.Models;
using Microsoft.Extensions.Configuration.UserSecrets;

namespace VehicleBookingAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]

    public class VehiclesController : Controller
    {
        
            #region Get All Person
            [HttpGet]

            public IActionResult Get()
            {
                Vehicles_BALBase bal = new Vehicles_BALBase();
                List<VehiclesModel> vehicles = bal.PR_SELECT_ALL_Vehicles();
                Dictionary<string, dynamic> response
                    = new Dictionary<string, dynamic>();
                if (vehicles.Count > 0 && vehicles != null)
                {
                    response.Add("status", true);
                    response.Add("message", "Data Found.");
                    response.Add("data", vehicles);
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

            #region Get Person By ID
            [HttpGet("{VehicleID}")]
            public IActionResult Get(int VehicleID)
            {
                Vehicles_BALBase bal = new Vehicles_BALBase();

                VehiclesModel vehicles = bal.PR_SELECT_BY_PK_Vehicles(VehicleID);
                Dictionary<string, dynamic> response
                = new Dictionary<string, dynamic>();
                if (vehicles.VehicleId != 0)
                {
                    response.Add("status", true);
                    response.Add("message", "Data Found");
                    response.Add("data", vehicles);
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
        public IActionResult Delete(int VehicleID)
        {
            Vehicles_BALBase balVehicle = new Vehicles_BALBase();
            bool IsSuccess = balVehicle.PR_DELETE_Vehicles(VehicleID);
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
        public IActionResult Insert([FromForm] VehiclesModel vehicleModel)
        {
            Vehicles_BALBase balVehicle = new Vehicles_BALBase();
            bool IsSuccess = balVehicle.PR_VEHICAL_INSERT(vehicleModel);
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
        public IActionResult Update(int VehicleID, [FromForm] VehiclesModel vehicleModel)
        {
            Vehicles_BALBase balUser = new Vehicles_BALBase();
            vehicleModel.VehicleId = VehicleID;

            bool IsSuccess = balUser.PR_UPDATE_Vehicle(VehicleID, vehicleModel);
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

