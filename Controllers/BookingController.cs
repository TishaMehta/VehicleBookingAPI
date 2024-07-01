using Microsoft.AspNetCore.Mvc;
using VehicleBookingAPI.BAL;
using VehicleBookingAPI.Models;

namespace VehicleBookingAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class BookingController : Controller
    {
        #region Get All Booking
        [HttpGet]

        public IActionResult GetBooking()
        {
            Booking_BALBase bal = new Booking_BALBase();
            List<BookingModel> bookings = bal.PR_SELECT_ALL_Booking();
            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (bookings.Count > 0 && bookings != null)
            {
                response.Add("status", true);
                response.Add("message", "Data Found.");
                response.Add("data", bookings);
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
        [HttpGet("{BookingID}")]
        public IActionResult GetBooking(int BookingID)
        {
            Booking_BALBase bal = new Booking_BALBase();

            BookingModel bookingModel = bal.PR_SELECT_BY_PK_Booking(BookingID);
            Dictionary<string, dynamic> response
            = new Dictionary<string, dynamic>();
            if (bookingModel.BookingID != 0)
            {
                response.Add("status", true);
                response.Add("message", "Data Found");
                response.Add("data", bookingModel);
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
        public IActionResult DeleteBooking(int BookingID)
        {
            Booking_BALBase booking_BALBase = new Booking_BALBase();
            bool IsSuccess = booking_BALBase.PR_DELETE_BOOKING(BookingID);
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
        public IActionResult InsertBooking([FromForm] BookingModel bookingModel)
        {
            Booking_BALBase booking_BALBase = new Booking_BALBase();
            bool IsSuccess = booking_BALBase.PR_BOOKING_INSERT(bookingModel);
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
        public IActionResult UpdateBooking(int BookingID, [FromForm] BookingModel bookingModel)
        {
            Booking_BALBase booking_BALBase = new Booking_BALBase();
            bookingModel.BookingID = BookingID;

            bool IsSuccess = booking_BALBase.PR_UPDATE_BOOKING(BookingID, bookingModel);
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

        #region Get Booking By Foreign Key
        [HttpGet("ByCustomer/{UserID}")]
        public IActionResult GetBookingByUser(int UserID)
        {
            Booking_BALBase bal = new Booking_BALBase();

            // Assuming you have a method to select bookings by customer ID
            List<BookingModel> bookingModels = bal.PR_SELECT_BY_PK_Booking_UserID(UserID);

            Dictionary<string, dynamic> response = new Dictionary<string, dynamic>();
            if (bookingModels != null && bookingModels.Count > 0)
            {
                response.Add("status", true);
                response.Add("message", "Data Found");
                response.Add("data", bookingModels);
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


    }
}
