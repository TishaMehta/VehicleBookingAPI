using VehicleBookingAPI.DAL;
using VehicleBookingAPI.Models;

namespace VehicleBookingAPI.BAL
{
    public class Booking_BALBase
    {
        #region PR_SELECT_ALL_Booking
        public List<BookingModel> PR_SELECT_ALL_Booking()
        {

            Booking_DALBase booking_DALBase = new Booking_DALBase();
            List<BookingModel> bookingModels = booking_DALBase.PR_SELECT_ALL_Booking();
            return bookingModels;
        }
        #endregion

        #region PR_SELECT_BY_PK_Booking
        public BookingModel PR_SELECT_BY_PK_Booking(int BookingID)
        {

            Booking_DALBase booking_DALBase = new Booking_DALBase();
            BookingModel bookingModel = booking_DALBase.PR_SELECT_BY_PK_Booking(BookingID);
            return bookingModel;


        }
        #endregion

        #region PR_DELETE_BOOKING
        public bool PR_DELETE_BOOKING(int BookingID)
        {
            Booking_DALBase dal = new Booking_DALBase();
            if (dal.PR_DELETE_BOOKING(BookingID))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region PR_BOOKING_INSERT
        public bool PR_BOOKING_INSERT(BookingModel bookingModel)
        {
            Booking_DALBase dal = new Booking_DALBase();
            if (dal.PR_BOOKING_INSERT(bookingModel))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region PR_UPDATE_BOOKING
        public bool PR_UPDATE_BOOKING(int BookingID, BookingModel bookingModel)
        {
            Booking_DALBase booking_DALBase = new Booking_DALBase();
            if (booking_DALBase.PR_UPDATE_BOOKING(BookingID, bookingModel))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region PR_SELECT_BY_PK_Booking_UserID
        public List<BookingModel> PR_SELECT_BY_PK_Booking_UserID(int UserID)
        {
            List<BookingModel> bookingModels = new List<BookingModel>();

            // Instantiate the Booking_DALBase object
            Booking_DALBase bookingDal = new Booking_DALBase();

            // Call the non-static method on the instance
            bookingModels = bookingDal.PR_SELECT_BY_PK_Booking_UserID(UserID);

            return bookingModels;
        }
        #endregion




    }
}
