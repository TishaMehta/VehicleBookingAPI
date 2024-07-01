using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using VehicleBookingAPI.Models;

namespace VehicleBookingAPI.DAL
{
    public class VehicleType_DALBase:DAL_Helpers
    {
        #region PR_SELECT_ALL_VehicalType

        public List<VehicleTypeModel> PR_SELECT_ALL_VehicalType()
        {

            SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
            DbCommand dbcommand = sqlDatabase.GetStoredProcCommand("PR_SELECT_ALL_VehicalType");
            List<VehicleTypeModel> vehicleTypeModels = new List<VehicleTypeModel>();
            using (IDataReader dr = sqlDatabase.ExecuteReader(dbcommand))
            {
                while (dr.Read())
                {
                    VehicleTypeModel vehicleTypeModel = new VehicleTypeModel();
                    vehicleTypeModel.VehicleTypeID = Convert.ToInt32(dr["VehicleTypeId"].ToString());
                    vehicleTypeModel.VehicleTypeName = dr["VehicleTypeName"].ToString();
                    vehicleTypeModel.Created = Convert.ToDateTime(dr["Created"].ToString());
                    vehicleTypeModel.Modified = Convert.ToDateTime(dr["Modified"].ToString());

                    vehicleTypeModels.Add(vehicleTypeModel);
                }
                return vehicleTypeModels;
            }
            List<VehicleTypeModel> filteredVehicleTypes = string.IsNullOrEmpty("PR_SELECT_ALL_VehicalType")
       ? vehicleTypeModels  // If no search term, return all vehicle types
       : vehicleTypeModels
           .Where(vt => vt.VehicleTypeName.Contains("PR_SELECT_ALL_VehicalType", StringComparison.OrdinalIgnoreCase))
           .ToList();

        }

        #endregion

        #region PR_SELECT_BY_PK_VehicalType
        public VehicleTypeModel PR_SELECT_BY_PK_VehicalType(int VehicleTypeID)
        {


            SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
            DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_SELECT_BY_PK_VehicalType");
            sqlDatabase.AddInParameter(dbCommand, "@VehicleTypeID", SqlDbType.Int, VehicleTypeID);
            VehicleTypeModel vehicleTypeModel = new VehicleTypeModel();
            using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
            {
                while (dr.Read())
                {
                    vehicleTypeModel.VehicleTypeID = Convert.ToInt32(dr["VehicleTypeId"].ToString());
                    vehicleTypeModel.VehicleTypeName = dr["VehicleTypeName"].ToString();
                    vehicleTypeModel.Created = Convert.ToDateTime(dr["Created"].ToString());
                    vehicleTypeModel.Modified = Convert.ToDateTime(dr["Modified"].ToString());
                }


            }
            return vehicleTypeModel;

        }
        #endregion

        #region PR_DELETE_VehicleType

        public bool PR_DELETE_VehicleType(int VehicleTypeID)
        {
            SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
            DbCommand cmd = sqlDatabase.GetStoredProcCommand("PR_DELETE_VehicleType");
            sqlDatabase.AddInParameter(cmd, "@VehicleTypeID", SqlDbType.Int, VehicleTypeID);
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

        #region PR_VehicalType_INSERT
        public bool PR_VehicalType_INSERT(VehicleTypeModel vehicleTypeModel)
        {
            SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
            DbCommand cmd = sqlDatabase.GetStoredProcCommand("PR_VehicalType_INSERT");
            sqlDatabase.AddInParameter(cmd, "@VehicleTypeName", SqlDbType.VarChar, vehicleTypeModel.VehicleTypeName);

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

        #region PR_UPDATE_VehicalType
        public bool PR_UPDATE_VehicalType(int VehicleTypeID, VehicleTypeModel vehicleTypeModel)
        {
            SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
            DbCommand cmd = sqlDatabase.GetStoredProcCommand("PR_UPDATE_VehicalType");
            sqlDatabase.AddInParameter(cmd, "@VehicleTypeId", SqlDbType.Int, vehicleTypeModel.VehicleTypeID);
            sqlDatabase.AddInParameter(cmd, "@VehicleTypeName", SqlDbType.VarChar, vehicleTypeModel.VehicleTypeName);
            
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
