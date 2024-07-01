using Microsoft.AspNetCore.Mvc;
using VehicleBookingAPI.BAL;
using VehicleBookingAPI.Models;

namespace VehicleBookingAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]

    public class UserController : Controller
    {
        private IConfiguration Configuration;
        public UserController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        #region Get All User
        [HttpGet]

        public IActionResult GetUSER()
        {
            User_BALBase bal = new User_BALBase();
            List<UserModel> user = bal.PR_SELECT_ALL_USER();
            Dictionary<string, dynamic> response
                = new Dictionary<string, dynamic>();
            if (user.Count > 0 && user != null)
            {
                response.Add("status", true);
                response.Add("message", "Data Found.");
                response.Add("data", user);
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
        [HttpGet("{UserID}")]
        public IActionResult GetUser(int UserID)
        {
            User_BALBase bal = new User_BALBase();

            UserModel user = bal.PR_SELECT_BY_PK_USER(UserID);
            Dictionary<string, dynamic> response
            = new Dictionary<string, dynamic>();
            if (user.UserID != 0)
            {
                response.Add("status", true);
                response.Add("message", "Data Found");
                response.Add("data", user);
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
        [HttpDelete("Delete1")]
        public IActionResult DeleteUser(int UserID)
        {
            User_BALBase balUser = new User_BALBase();
            bool IsSuccess = balUser.PR_DELETE_USER(UserID);
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

        //[HttpDelete("delete-many")]
        //public IActionResult DeleteMany([FromBody] List<int> ids)
        //{
        //    if (ids == null || ids.Count == 0)
        //    {
        //        return BadRequest("No IDs provided for deletion.");
        //    }

        //    try
        //    {
        //        Configuration.DeleteMany(ids);
        //        return Ok("Records deleted successfully.");
        //    }
        //    catch (Exception ex)
        //    {
        //        // Log the exception or handle it as needed
        //        return StatusCode(500, "Internal server error");
        //    }
        //}

        #region Insert
        [HttpPost]
        public IActionResult InsertUser([FromForm] UserModel userModel)
        {
            User_BALBase balUser = new User_BALBase();
            bool IsSuccess = balUser.PR_USER_INSERT(userModel);
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
        public IActionResult Update(int UserID, [FromForm] UserModel userModel)
        {
            User_BALBase balUser = new User_BALBase();
            userModel.UserID = UserID;

            bool IsSuccess = balUser.PR_UPDATE_USER(UserID,userModel);
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

        #region API_User_Register
        [HttpPost]
        public IActionResult Register(string FirstName, string LastName, string Email, string PhoneNumber, string Password)
        {
            User_BALBase bal = new User_BALBase();
            bool IsSuccess = bal.PR_User_Register(FirstName, LastName, Email, PhoneNumber, Password);
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (IsSuccess)
            {
                response.Add("status", true);
                response.Add("message", "Data Inserted Successfully");
                return Ok(response);
            }
            else
            {
                response.Add("status", false);
                response.Add("message", "Some Error Occured");
                return Ok(response);
            }
        }

        #endregion


    }
}
