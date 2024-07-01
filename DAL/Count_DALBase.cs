using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using VehicleBookingAPI.Models;

namespace VehicleBookingAPI.DAL
{
    public class Count_DALBase: DAL_Helpers
    {
        #region PR_DASHBOARD_COUNTS

        public List<CountModel> PR_DASHBOARD_COUNTS()
        {

            SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
            DbCommand dbcommand = sqlDatabase.GetStoredProcCommand("PR_DASHBOARD_COUNTS");
            List<CountModel> countModels = new List<CountModel>();
            using (IDataReader dr = sqlDatabase.ExecuteReader(dbcommand))
            {
                while (dr.Read())
                {
                    CountModel countModel = new CountModel();
                    countModel.UserCount = dr["UserCount"].ToString();
                    countModel.VehiclesCount = dr["VehiclesCount"].ToString();
                    countModel.VehicleTypeCount = dr["VehicleTypeCount"].ToString();

                    countModel.BookingCount = dr["BookingCount"].ToString();
                    countModel.PaymentCount = dr["PaymentCount"].ToString();
                    countModel.PickupLocationCount = dr["PickupLocationCount"].ToString();
                    countModel.DropoffLocationCount = dr["DropoffLocationCount"].ToString();



                    countModels.Add(countModel);
                }
                return countModels;
            }




        }

        #endregion
    }
}
