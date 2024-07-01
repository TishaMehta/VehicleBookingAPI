using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using VehicleBookingAPI.Models;

namespace VehicleBookingAPI.DAL
{
    public class Payment_DALBAse:DAL_Helpers
    {

        #region PR_SELECT_ALL_PAYMENT

        public List<PaymentModel> PR_SELECT_ALL_PAYMENT()
        {

            SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
            DbCommand dbcommand = sqlDatabase.GetStoredProcCommand("PR_SELECT_ALL_PAYMENT");
            List<PaymentModel> paymentModels = new List<PaymentModel>();
            using (IDataReader dr = sqlDatabase.ExecuteReader(dbcommand))
            {
                while (dr.Read())
                {
                    PaymentModel paymentModel = new PaymentModel();
                    paymentModel.PaymentID = Convert.ToInt32(dr["PaymentID"].ToString());

                    paymentModel.BookingID = Convert.ToInt32(dr["BookingID"].ToString());

                    paymentModel.Amount = Convert.ToDecimal(dr["Amount"].ToString());
                    paymentModel.PaymentDate = Convert.ToDateTime(dr["PaymentDate"].ToString());
                    paymentModel.PaymentStatus = dr["PaymentStatus"].ToString();
                    paymentModel.PaymentMethod = dr["PaymentMethod"].ToString();

                    paymentModel.Created = Convert.ToDateTime(dr["Created"].ToString());
                    paymentModel.Modified = Convert.ToDateTime(dr["Modified"].ToString());

                    paymentModels.Add(paymentModel);
                }
                return paymentModels;
            }




        }

        #endregion

        #region PR_SELECT_BY_PK_Payment
        public PaymentModel PR_SELECT_BY_PK_Payment(int PaymentID)
        {


            SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
            DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_SELECT_BY_PK_Payment");
            sqlDatabase.AddInParameter(dbCommand, "@PaymentID", SqlDbType.Int, PaymentID);
            PaymentModel paymentModel = new PaymentModel();
            using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
            {
                while (dr.Read())
                {
                    paymentModel.PaymentID = Convert.ToInt32(dr["PaymentID"].ToString());
                    paymentModel.BookingID = Convert.ToInt32(dr["BookingID"].ToString());

                    paymentModel.Amount = Convert.ToDecimal(dr["Amount"].ToString());
                    paymentModel.PaymentDate = Convert.ToDateTime(dr["PaymentDate"].ToString());
                    paymentModel.PaymentStatus = dr["PaymentStatus"].ToString();
                    paymentModel.PaymentMethod = dr["PaymentMethod"].ToString();

                    paymentModel.Created = Convert.ToDateTime(dr["Created"].ToString());
                    paymentModel.Modified = Convert.ToDateTime(dr["Modified"].ToString());
                }


            }
            return paymentModel;

        }
        #endregion

        #region PR_DELETE_Payment

        public bool PR_DELETE_Payment(int PaymentID)
        {
            SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
            DbCommand cmd = sqlDatabase.GetStoredProcCommand("PR_DELETE_Payment");
            sqlDatabase.AddInParameter(cmd, "@PaymentID", SqlDbType.Int, PaymentID);
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

        #region PR_Payment_INSERT
        public bool PR_Payment_INSERT(PaymentModel paymentModel)
        {
            SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
            DbCommand cmd = sqlDatabase.GetStoredProcCommand("PR_Payment_INSERT");
            sqlDatabase.AddInParameter(cmd, "@BookingID", SqlDbType.Int, paymentModel.BookingID);
            sqlDatabase.AddInParameter(cmd, "@Amount", SqlDbType.Decimal, paymentModel.Amount);
            sqlDatabase.AddInParameter(cmd, "@PaymentDate", SqlDbType.DateTime, paymentModel.PaymentDate);
            sqlDatabase.AddInParameter(cmd, "@PaymentStatus", SqlDbType.VarChar, paymentModel.PaymentStatus);
            sqlDatabase.AddInParameter(cmd, "@PaymentMethod", SqlDbType.VarChar, paymentModel.PaymentMethod);
          
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

        #region PR_UPDATE_Payment
        public bool PR_UPDATE_Payment(int PaymentID, PaymentModel paymentModel)
        {
            SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
            DbCommand cmd = sqlDatabase.GetStoredProcCommand("PR_UPDATE_Payment");
            sqlDatabase.AddInParameter(cmd, "@PaymentID", SqlDbType.Int, paymentModel.PaymentID);
            sqlDatabase.AddInParameter(cmd, "@BookingID", SqlDbType.Int, paymentModel.BookingID);
            sqlDatabase.AddInParameter(cmd, "@Amount", SqlDbType.Decimal, paymentModel.Amount);
            sqlDatabase.AddInParameter(cmd, "@PaymentDate", SqlDbType.DateTime, paymentModel.PaymentDate);
            sqlDatabase.AddInParameter(cmd, "@PaymentStatus", SqlDbType.VarChar, paymentModel.PaymentStatus);
            sqlDatabase.AddInParameter(cmd, "@PaymentMethod", SqlDbType.VarChar, paymentModel.PaymentMethod);

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

    }
}

