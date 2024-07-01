using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using VehicleBookingAPI.Models;

namespace VehicleBookingAPI.DAL
{
    public class PickupLocation_DALBase : DAL_Helpers
    {
        #region PR_SELECT_ALL_Location

        public List<PickupLocation> PR_SELECT_ALL_PickupLocation()
        {

            SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
            DbCommand dbcommand = sqlDatabase.GetStoredProcCommand("PR_SELECT_ALL_PickupLocation");
            List<PickupLocation> pickupLocationModels = new List<PickupLocation>();
            using (IDataReader dr = sqlDatabase.ExecuteReader(dbcommand))
            {
                while (dr.Read())
                {
                    PickupLocation pickupLocationModel = new PickupLocation();
                    pickupLocationModel.PickupLocationID = Convert.ToInt32(dr["PickupLocationID"].ToString());

                    pickupLocationModel.PickupLocationName = dr["PickupLocationName"].ToString();
                    pickupLocationModel.PickupLocationCode = dr["PickupLocationCode"].ToString();
                    pickupLocationModel.Created = Convert.ToDateTime(dr["Created"].ToString());
                    pickupLocationModel.Modified = Convert.ToDateTime(dr["Modified"].ToString());

                    pickupLocationModels.Add(pickupLocationModel);
                }
                return pickupLocationModels;
            }




        }

        #endregion

        #region PR_SELECT_BY_PK_Location
        public PickupLocation PR_SELECT_BY_PK_PickupLocation(int PickupLocationID)
        {


            SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
            DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_SELECT_BY_PK_PickupLocation");
            sqlDatabase.AddInParameter(dbCommand, "@PickupLocationID", SqlDbType.Int, PickupLocationID);
            PickupLocation pickupLocationModel = new PickupLocation();
            using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
            {
                while (dr.Read())
                {
                    pickupLocationModel.PickupLocationID = Convert.ToInt32(dr["PickupLocationID"].ToString());

                    pickupLocationModel.PickupLocationName = dr["PickupLocationName"].ToString();
                    pickupLocationModel.PickupLocationCode = dr["PickupLocationCode"].ToString();
                    pickupLocationModel.Created = Convert.ToDateTime(dr["Created"].ToString());
                    pickupLocationModel.Modified = Convert.ToDateTime(dr["Modified"].ToString());
                }


            }
            return pickupLocationModel;

        }
        #endregion

        #region PR_DELETE_Location

        public bool PR_DELETE_PickupLocation(int PickupLocationID)
        {
            SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
            DbCommand cmd = sqlDatabase.GetStoredProcCommand("PR_DELETE_PickupLocation");
            sqlDatabase.AddInParameter(cmd, "@PickupLocationID", SqlDbType.Int, PickupLocationID);
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

        #region PR_PickupLocation_INSERT
        public bool PR_PickupLocation_INSERT(PickupLocation Pickuplocation)
        {
            SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
            DbCommand cmd = sqlDatabase.GetStoredProcCommand("PR_PickupLocation_INSERT");
            sqlDatabase.AddInParameter(cmd, "@PickupLocationName", SqlDbType.VarChar, Pickuplocation.PickupLocationName);
            sqlDatabase.AddInParameter(cmd, "@PickupLocationCode", SqlDbType.VarChar, Pickuplocation.PickupLocationCode);
            
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

        #region PR_UPDATE_Location
        public bool PR_UPDATE_PickupLocation(int LocationID, PickupLocation PickupLocationModel)
        {
            SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
            DbCommand cmd = sqlDatabase.GetStoredProcCommand("PR_UPDATE_PickupLocation");
            sqlDatabase.AddInParameter(cmd, "@PickupLocationID", SqlDbType.Int, PickupLocationModel.PickupLocationID);
            sqlDatabase.AddInParameter(cmd, "@PickupLocationName", SqlDbType.VarChar, PickupLocationModel.PickupLocationName);
            sqlDatabase.AddInParameter(cmd, "@PickupLocationCode", SqlDbType.VarChar, PickupLocationModel.PickupLocationCode);
           
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
