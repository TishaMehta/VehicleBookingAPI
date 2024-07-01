using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using VehicleBookingAPI.Models;

namespace VehicleBookingAPI.DAL
{
    public class Booking_DALBase:DAL_Helpers
    {
        #region PR_SELECT_ALL_Booking

        public List<BookingModel> PR_SELECT_ALL_Booking()
        {

            SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
            DbCommand dbcommand = sqlDatabase.GetStoredProcCommand("PR_SELECT_ALL_Booking");
            List<BookingModel> bookingModels = new List<BookingModel>();
            using (IDataReader dr = sqlDatabase.ExecuteReader(dbcommand))
            {
                while (dr.Read())
                {
                    BookingModel bookingModel = new BookingModel();
                    bookingModel.BookingID = Convert.ToInt32(dr["BookingID"].ToString());
                    bookingModel.UserID = Convert.ToInt32(dr["UserID"].ToString());
                    bookingModel.FirstName = dr["FirstName"].ToString();
                    bookingModel.VehicleID = Convert.ToInt32(dr["VehicleID"].ToString());
                    bookingModel.VehicleName = dr["VehicleName"].ToString();


                    bookingModel.PickupLocationID = Convert.ToInt32(dr["PickupLocationID"].ToString());
                    bookingModel.PickupLocationName = dr["PickupLocationName"].ToString();

                    bookingModel.DropOffLocationID = Convert.ToInt32(dr["DropoffLocationID"].ToString());
                    bookingModel.DropOffLocationName = dr["DropoffLocationName"].ToString();

                    bookingModel.PickupDate = Convert.ToDateTime(dr["PickupDate"].ToString());
                    bookingModel.DropOffDate = Convert.ToDateTime(dr["DropOffDate"].ToString());
                    //bookingModel.BookingStatus = dr["BookingStatus"].ToString();
                    //bookingModel.TotalCharge = Convert.ToDecimal(dr["TotalCharge"].ToString());
                    bookingModel.Created = Convert.ToDateTime(dr["Created"].ToString());
                    bookingModel.Modified = Convert.ToDateTime(dr["Modified"].ToString());

                    bookingModels.Add(bookingModel);
                }
                return bookingModels;
            }




        }

        #endregion

        #region PR_SELECT_BY_PK_Booking
        public BookingModel PR_SELECT_BY_PK_Booking(int BookingID)
        {


            SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
            DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_SELECT_BY_PK_Booking");
            sqlDatabase.AddInParameter(dbCommand, "@BookingID", SqlDbType.Int, BookingID);
            BookingModel bookingModel = new BookingModel();
            using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
            {
                while (dr.Read())
                {
                    bookingModel.BookingID = Convert.ToInt32(dr["BookingID"].ToString());
                    bookingModel.UserID = Convert.ToInt32(dr["UserID"].ToString());
                    bookingModel.VehicleID = Convert.ToInt32(dr["VehicleID"].ToString());
                    bookingModel.PickupLocationID = Convert.ToInt32(dr["PickupLocationID"].ToString());
                    //bookingModel.PickupLocationName = dr["LocationName"].ToString();

                    bookingModel.DropOffLocationID = Convert.ToInt32(dr["DropOffLocationID"].ToString());
                    //bookingModel.DropOffLocationName = dr["LocationName"].ToString();

                    bookingModel.PickupDate = Convert.ToDateTime(dr["PickupDate"].ToString());
                    bookingModel.DropOffDate = Convert.ToDateTime(dr["DropOffDate"].ToString());
                    //bookingModel.BookingStatus = dr["BookingStatus"].ToString();
                    //bookingModel.TotalCharge = Convert.ToDecimal(dr["TotalCharge"].ToString());
                    bookingModel.Created = Convert.ToDateTime(dr["Created"].ToString());
                    bookingModel.Modified = Convert.ToDateTime(dr["Modified"].ToString());
                }


            }
            return bookingModel;

        }
        #endregion

        #region PR_DELETE_BOOKING

        public bool PR_DELETE_BOOKING(int BookingID)
        {
            SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
            DbCommand cmd = sqlDatabase.GetStoredProcCommand("PR_DELETE_BOOKING");
            sqlDatabase.AddInParameter(cmd, "@BookingID", SqlDbType.Int, BookingID);
            if (Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(cmd)))
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
            SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
            DbCommand cmd = sqlDatabase.GetStoredProcCommand("PR_BOOKING_INSERT");
            sqlDatabase.AddInParameter(cmd, "@UserID", SqlDbType.Int, bookingModel.UserID);
            //sqlDatabase.AddInParameter(cmd, "@FirstName", SqlDbType.Int, bookingModel.FirstName);

            sqlDatabase.AddInParameter(cmd, "@VehicleID", SqlDbType.Int, bookingModel.VehicleID);
            sqlDatabase.AddInParameter(cmd, "@PickupLocationID", SqlDbType.Int, bookingModel.PickupLocationID);
            sqlDatabase.AddInParameter(cmd, "@DropOffLocationID", SqlDbType.Int, bookingModel.DropOffLocationID);

            sqlDatabase.AddInParameter(cmd, "@PickupDate", SqlDbType.DateTime, bookingModel.PickupDate);
            sqlDatabase.AddInParameter(cmd, "@DropOffDate", SqlDbType.DateTime, bookingModel.DropOffDate);
            //sqlDatabase.AddInParameter(cmd, "@BookingStatus", SqlDbType.VarChar, bookingModel.BookingStatus);
            //sqlDatabase.AddInParameter(cmd, "@TotalCharge", SqlDbType.Decimal, bookingModel.TotalCharge);
            


            if (Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(cmd)))
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
            SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
            DbCommand cmd = sqlDatabase.GetStoredProcCommand("PR_UPDATE_BOOKING");
            sqlDatabase.AddInParameter(cmd, "@BookingID", SqlDbType.Int, bookingModel.BookingID);
            sqlDatabase.AddInParameter(cmd, "@UserID", SqlDbType.Int, bookingModel.UserID);
            sqlDatabase.AddInParameter(cmd, "@VehicleID", SqlDbType.Int, bookingModel.VehicleID);
            sqlDatabase.AddInParameter(cmd, "@PickupLocationID", SqlDbType.Int, bookingModel.PickupLocationID);
            sqlDatabase.AddInParameter(cmd, "@DropoffLocationID", SqlDbType.Int, bookingModel.DropOffLocationID);
            sqlDatabase.AddInParameter(cmd, "@PickupDate", SqlDbType.DateTime, bookingModel.PickupDate);
            sqlDatabase.AddInParameter(cmd, "@DropOffDate", SqlDbType.DateTime, bookingModel.DropOffDate);
            //sqlDatabase.AddInParameter(cmd, "@BookingStatus", SqlDbType.VarChar, bookingModel.BookingStatus);
            //sqlDatabase.AddInParameter(cmd, "@TotalCharge", SqlDbType.Decimal, bookingModel.TotalCharge);

            if (Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(cmd)))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        #endregion  }

        #region PR_SELECT_BY_FK_Customer
        public List<BookingModel> PR_SELECT_BY_PK_Booking_UserID(int UserID)
        {
            List<BookingModel> bookingModels = new List<BookingModel>();

            SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
            DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_SELECT_BY_PK_Booking_UserID"); // Assuming you have a stored procedure for this
            sqlDatabase.AddInParameter(dbCommand, "@UserID", SqlDbType.Int, UserID);

            using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
            {
                while (dr.Read())
                {
                    BookingModel bookingModel = new BookingModel();

                    bookingModel.BookingID = Convert.ToInt32(dr["BookingID"]);
                    bookingModel.UserID = Convert.ToInt32(dr["UserID"]);
                    bookingModel.VehicleID = Convert.ToInt32(dr["VehicleID"]);
                    bookingModel.VehicleName = (dr["VehicleName"]).ToString();

                    bookingModel.PickupLocationID = Convert.ToInt32(dr["PickupLocationID"]);
                    // Populate other properties as needed

                    bookingModels.Add(bookingModel);
                }
            }

            return bookingModels;
        }
        #endregion

    }
}
