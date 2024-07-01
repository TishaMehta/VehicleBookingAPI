using VehicleBookingAPI.DAL;
using VehicleBookingAPI.Models;

namespace VehicleBookingAPI.BAL
{
    public class Payment_BALBase
    {
        #region PR_SELECT_ALL_PAYMENT
        public List<PaymentModel> PR_SELECT_ALL_PAYMENT()
        {

            Payment_DALBAse payment_DALBAse = new Payment_DALBAse();
            List<PaymentModel> paymentModels = payment_DALBAse.PR_SELECT_ALL_PAYMENT();
            return paymentModels;
        }
        #endregion

        #region PR_SELECT_BY_PK_Payment
        public PaymentModel PR_SELECT_BY_PK_Payment(int PaymentID)
        {

            Payment_DALBAse payment_DALBAse = new Payment_DALBAse();
            PaymentModel paymentModel = payment_DALBAse.PR_SELECT_BY_PK_Payment(PaymentID);
            return paymentModel;


        }
        #endregion

        #region PR_DELETE_Payment
        public bool PR_DELETE_Payment(int PaymentID)
        {
            Payment_DALBAse dalPayment = new Payment_DALBAse();
            if (dalPayment.PR_DELETE_Payment(PaymentID))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region PR_Payment_INSERT
        public bool PR_Payment_INSERT(PaymentModel paymentModel)
        {
            Payment_DALBAse dalpayment = new Payment_DALBAse();
            if (dalpayment.PR_Payment_INSERT(paymentModel))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region PR_UPDATE_Payment
        public bool PR_UPDATE_Payment(int PaymentID, PaymentModel paymentModel)
        {
            Payment_DALBAse dalPayment = new Payment_DALBAse();
            if (dalPayment.PR_UPDATE_Payment(PaymentID, paymentModel))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion
    }


}
