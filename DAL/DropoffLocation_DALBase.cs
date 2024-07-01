using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using VehicleBookingAPI.Models;

namespace VehicleBookingAPI.DAL
{
    public class DropoffLocation_DALBase : DAL_Helpers
    {
        #region PR_SELECT_ALL_DropoffLocation

        public List<DropoffLocationModel> PR_SELECT_ALL_PickupLocation()
        {

            SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
            DbCommand dbcommand = sqlDatabase.GetStoredProcCommand("PR_SELECT_ALL_DropoffLocation");
            List<DropoffLocationModel> dropoffLocationModels = new List<DropoffLocationModel>();
            using (IDataReader dr = sqlDatabase.ExecuteReader(dbcommand))
            {
                while (dr.Read())
                {
                    DropoffLocationModel dropoffLocationModel = new DropoffLocationModel();
                    dropoffLocationModel.DropoffLocationID = Convert.ToInt32(dr["DropoffLocationID"].ToString());

                    dropoffLocationModel.DropoffLocationName = dr["DropoffLocationName"].ToString();
                    dropoffLocationModel.DropoffLocationCode = dr["DropoffLocationCode"].ToString();
                    dropoffLocationModel.Created = Convert.ToDateTime(dr["Created"].ToString());
                    dropoffLocationModel.Modified = Convert.ToDateTime(dr["Modified"].ToString());

                    dropoffLocationModels.Add(dropoffLocationModel);
                }
                return dropoffLocationModels;
            }




        }

        #endregion

        #region PR_SELECT_BY_PK_DropoffLocation
        public DropoffLocationModel PR_SELECT_BY_PK_DropoffLocation(int DropoffLocationID)
        {


            SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
            DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_SELECT_BY_PK_DropoffLocation");
            sqlDatabase.AddInParameter(dbCommand, "@DropoffLocationID", SqlDbType.Int, DropoffLocationID);
            DropoffLocationModel dropoffLocationModel = new DropoffLocationModel();
            using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
            {
                while (dr.Read())
                {
                    dropoffLocationModel.DropoffLocationID = Convert.ToInt32(dr["DropoffLocationID"].ToString());

                    dropoffLocationModel.DropoffLocationName = dr["DropoffLocationName"].ToString();
                    dropoffLocationModel.DropoffLocationCode = dr["DropoffLocationCode"].ToString();
                    dropoffLocationModel.Created = Convert.ToDateTime(dr["Created"].ToString());
                    dropoffLocationModel.Modified = Convert.ToDateTime(dr["Modified"].ToString());
                }


            }
            return dropoffLocationModel;

        }
        #endregion

        #region PR_DELETE_DropoffLocation

        public bool PR_DELETE_DropoffLocation(int DropoffLocationID)
        {
            SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
            DbCommand cmd = sqlDatabase.GetStoredProcCommand("PR_DELETE_DropoffLocation");
            sqlDatabase.AddInParameter(cmd, "@DropoffLocationID", SqlDbType.Int, DropoffLocationID);
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

        #region PR_DropoffLocation_INSERT
        public bool PR_DropoffLocation_INSERT(DropoffLocationModel dropoffLocationModel)
        {
            SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
            DbCommand cmd = sqlDatabase.GetStoredProcCommand("PR_DropoffLocation_INSERT");
            sqlDatabase.AddInParameter(cmd, "@DropoffLocationName", SqlDbType.VarChar, dropoffLocationModel.DropoffLocationName);
            sqlDatabase.AddInParameter(cmd, "@DropoffLocationCode", SqlDbType.VarChar, dropoffLocationModel.DropoffLocationCode);

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

        #region PR_UPDATE_DropoffLocation
        public bool PR_UPDATE_DropoffLocation(int DropoffLocationID, DropoffLocationModel dropoffLocationModel)
        {
            SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
            DbCommand cmd = sqlDatabase.GetStoredProcCommand("PR_UPDATE_DropoffLocation");
            sqlDatabase.AddInParameter(cmd, "@DropoffLocationID", SqlDbType.Int, dropoffLocationModel.DropoffLocationID);
            sqlDatabase.AddInParameter(cmd, "@DropoffLocationName", SqlDbType.VarChar, dropoffLocationModel.DropoffLocationName);
            sqlDatabase.AddInParameter(cmd, "@DropoffLocationCode", SqlDbType.VarChar, dropoffLocationModel.DropoffLocationCode);

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
    }
}
