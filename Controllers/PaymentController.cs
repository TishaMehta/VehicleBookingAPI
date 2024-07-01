using Microsoft.AspNetCore.Mvc;
using VehicleBookingAPI.BAL;
using VehicleBookingAPI.Models;

namespace VehicleBookingAPI.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class PaymentController : Controller
    {
        #region Get All Payment
        [HttpGet]

        public IActionResult GetPayment()
        {
            Payment_BALBase bal = new Payment_BALBase();
            List<PaymentModel> payments = bal.PR_SELECT_ALL_PAYMENT();
            Dictionary<string, dynamic> response
                = new Dictionary<string, dynamic>();
            if (payments.Count > 0 && payments != null)
            {
                response.Add("status", true);
                response.Add("message", "Data Found.");
                response.Add("data", payments);
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

        #region Get Payment By ID
        [HttpGet("{PaymentID}")]
        public IActionResult GetPayment(int PaymentID)
        {
            Payment_BALBase bal = new Payment_BALBase();

            PaymentModel payment = bal.PR_SELECT_BY_PK_Payment(PaymentID);
            Dictionary<string, dynamic> response
            = new Dictionary<string, dynamic>();
            if (payment.BookingID != 0)
            {
                response.Add("status", true);
                response.Add("message", "Data Found");
                response.Add("data", payment);
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
        public IActionResult DeletePayment(int PaymentID)
        {
            Payment_BALBase payment = new Payment_BALBase();
            bool IsSuccess = payment.PR_DELETE_Payment(PaymentID);
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
        public IActionResult InsertPayment([FromForm] PaymentModel paymentModel)
        {
            Payment_BALBase payment = new Payment_BALBase();
            bool IsSuccess = payment.PR_Payment_INSERT(paymentModel);
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
        public IActionResult UpdatePayment(int PaymentID, [FromForm] PaymentModel paymentModel)
        {
            Payment_BALBase payment = new Payment_BALBase();
            paymentModel.PaymentID = PaymentID;

            bool IsSuccess = payment.PR_UPDATE_Payment(PaymentID, paymentModel);
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
