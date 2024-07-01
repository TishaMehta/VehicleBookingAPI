using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using VehicleBookingAPI.Models;
using System.Data.SqlClient;

namespace VehicleBookingAPI.DAL
{
    public class Vehicles_DALBase : DAL_Helpers
    {

        #region PR_SELECT_ALL_Vehicle

        public List<VehiclesModel> PR_SELECT_ALL_Vehicles()
        {

            SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
            DbCommand dbcommand = sqlDatabase.GetStoredProcCommand("PR_SELECT_ALL_Vehicles");
            List<VehiclesModel> vehicleModels = new List<VehiclesModel>();
            using (IDataReader dr = sqlDatabase.ExecuteReader(dbcommand))
            {
                while (dr.Read())
                {
                    VehiclesModel vehicleModel = new VehiclesModel();
                    vehicleModel.VehicleId = Convert.ToInt32(dr["VehicleId"].ToString());
                    //if (dr["VehicleImage"] != DBNull.Value)
                    //{
                    //    byte[] imageBytes = (byte[])dr["VehicleImage"];
                    //    vehicleModel.VehicleImage = Convert.ToBase64String(imageBytes);
                    //}
                    //else
                    //{
                    //    // Handle the case where VehicleImage is DBNull, e.g., set it to a default value
                    //    vehicleModel.VehicleImage = "DefaultBase64ImageString";
                    //}
                    vehicleModel.VehicleName = dr["VehicleName"].ToString();
                    vehicleModel.VehicleTypeID = Convert.ToInt32(dr["VehicleTypeID"].ToString());
                    vehicleModel.VehicleTypeName = dr["VehicleTypeName"].ToString();

                    vehicleModel.RegistrationNumber = dr["RegistrationNumber"].ToString();
                    vehicleModel.NumberOfPassenger = Convert.ToInt32(dr["NumberOfPassenger"].ToString());
                    vehicleModel.ChargePerKM = Convert.ToDecimal(dr["ChargePerKM"].ToString());

                    vehicleModel.Status = dr["Status"].ToString();
                    vehicleModel.Created = dr["Created"].ToString();
                    vehicleModel.Modified = dr["Modified"].ToString();

                    vehicleModels.Add(vehicleModel);
                }
                return vehicleModels;
            }




        }

        #endregion

        #region PR_SELECT_BY_PK_Vehicles
        public VehiclesModel PR_SELECT_BY_PK_Vehicles(int VehicleID)
        {


            SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
            DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_SELECT_BY_PK_Vehicles");
            sqlDatabase.AddInParameter(dbCommand, "@VehicleID", SqlDbType.Int, VehicleID);
            VehiclesModel vehicleModel = new VehiclesModel();
            using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
            {
                while (dr.Read())
                {
                    vehicleModel.VehicleId = Convert.ToInt32(dr["VehicleId"].ToString());
                    //if (dr["VehicleImage"] != DBNull.Value)
                    //{
                    //    byte[] imageBytes = (byte[])dr["VehicleImage"];
                    //    vehicleModel.VehicleImage = Convert.ToBase64String(imageBytes);
                    //}
                    //else
                    //{
                    //    // Handle the case where VehicleImage is DBNull, e.g., set it to a default value
                    //    vehicleModel.VehicleImage = "DefaultBase64ImageString";
                    //}
                    vehicleModel.VehicleName = dr["VehicleName"].ToString();
                    vehicleModel.VehicleTypeID = Convert.ToInt32(dr["VehicleTypeId"].ToString());
                    vehicleModel.VehicleTypeName = dr["VehicleTypeName"].ToString();

                    vehicleModel.RegistrationNumber = dr["RegistrationNumber"].ToString();
                    vehicleModel.NumberOfPassenger = Convert.ToInt32(dr["NumberOfPassenger"].ToString());
                    vehicleModel.ChargePerKM = Convert.ToDecimal(dr["ChargePerKM"].ToString());

                    vehicleModel.Status = dr["Status"].ToString();
                    vehicleModel.Created = dr["Created"].ToString();
                    vehicleModel.Modified = dr["Modified"].ToString();
                }


            }
            return vehicleModel;

        }
        #endregion

        #region PR_DELETE_Vehicles
        public bool PR_DELETE_Vehicles(int VehicleID)
        {
            SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
            DbCommand cmd = sqlDatabase.GetStoredProcCommand("PR_DELETE_Vehicles");
            sqlDatabase.AddInParameter(cmd, "@VehicleID", SqlDbType.Int, VehicleID);
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

        #region PR_VEHICAL_INSERT
        public bool PR_VEHICAL_INSERT(VehiclesModel vehicleModel)
        {
            SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
            DbCommand cmd = sqlDatabase.GetStoredProcCommand("PR_VEHICAL_INSERT");

            //sqlDatabase.AddInParameter(cmd, "@VehicleImage", SqlDbType.VarChar, vehicleModel.VehicleImage);

            sqlDatabase.AddInParameter(cmd, "@VehicleName", SqlDbType.VarChar, vehicleModel.VehicleName);
            sqlDatabase.AddInParameter(cmd, "@VehicleTypeID", SqlDbType.Int, vehicleModel.VehicleTypeID);
            sqlDatabase.AddInParameter(cmd, "@RegistrationNumber", SqlDbType.VarChar, vehicleModel.RegistrationNumber);
            sqlDatabase.AddInParameter(cmd, "@NumberOfPassenger", SqlDbType.Int, vehicleModel.NumberOfPassenger);
            sqlDatabase.AddInParameter(cmd, "@Status", SqlDbType.VarChar, vehicleModel.Status);
            sqlDatabase.AddInParameter(cmd, "@ChargePerKM", SqlDbType.Decimal, vehicleModel.ChargePerKM);

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

        #region PR_UPDATE_Vehicle
        public bool PR_UPDATE_Vehicle(int VehicleID, VehiclesModel vehicleModel)
        {
            SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
            DbCommand cmd = sqlDatabase.GetStoredProcCommand("PR_UPDATE_Vehicle");
            sqlDatabase.AddInParameter(cmd, "@VehicleID", SqlDbType.Int, vehicleModel.VehicleId);
            //sqlDatabase.AddInParameter(cmd, "@VehicleImage", SqlDbType.VarChar, vehicleModel.VehicleImage);

            sqlDatabase.AddInParameter(cmd, "@VehicleName", SqlDbType.VarChar, vehicleModel.VehicleName);
            sqlDatabase.AddInParameter(cmd, "@VehicleTypeID", SqlDbType.Int, vehicleModel.VehicleTypeID);
            sqlDatabase.AddInParameter(cmd, "@RegistrationNumber", SqlDbType.VarChar, vehicleModel.RegistrationNumber);
            sqlDatabase.AddInParameter(cmd, "@NumberOfPassenger", SqlDbType.Int, vehicleModel.NumberOfPassenger);
            sqlDatabase.AddInParameter(cmd, "@Status", SqlDbType.VarChar, vehicleModel.Status);
            sqlDatabase.AddInParameter(cmd, "@ChargePerKM", SqlDbType.Decimal, vehicleModel.ChargePerKM);
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
       
        //    public bool PR_VEHICAL_INSERT(VehiclesModel vehicleModel, IFormFile imageFile)
        //    {
        //        try
        //        {
        //            using (SqlConnection connection = new SqlConnection(ConnString))
        //            {
        //                connection.Open();

        //                using (SqlCommand cmd = new SqlCommand("PR_VEHICAL_INSERT", connection))
        //                {
        //                    cmd.CommandType = CommandType.StoredProcedure;

        //                    // Convert IFormFile to byte array
        //                    byte[] imageBytes = null;
        //                    using (var memoryStream = new MemoryStream())
        //                    {
        //                        imageFile.CopyTo(memoryStream);
        //                        imageBytes = memoryStream.ToArray();
        //                    }

        //                    // Add parameters to the stored procedure
        //                    cmd.Parameters.AddWithValue("@VehicleImage", imageBytes); // Assuming you are storing the image as a byte[]

        //                    cmd.Parameters.AddWithValue("@VehicleName", vehicleModel.VehicleName);
        //                    cmd.Parameters.AddWithValue("@VehicleTypeID", vehicleModel.VehicleTypeID);
        //                    cmd.Parameters.AddWithValue("@RegistrationNumber", vehicleModel.RegistrationNumber);
        //                    cmd.Parameters.AddWithValue("@NumberOfPassenger", vehicleModel.NumberOfPassenger);
        //                    cmd.Parameters.AddWithValue("@Status", vehicleModel.Status);
        //                    cmd.Parameters.AddWithValue("@ChargePerKM", vehicleModel.ChargePerKM);

        //                    int rowsAffected = cmd.ExecuteNonQuery();

        //                    return rowsAffected > 0;
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            // Handle exceptions or log errors
        //            Console.WriteLine(ex.Message);
        //            return false;
        //        }
        //    }

        //    public bool PR_UPDATE_Vehicle(int VehicleID, VehiclesModel vehicleModel, IFormFile imageFile)
        //    {
        //        try
        //        {
        //            using (SqlConnection connection = new SqlConnection(ConnString))
        //            {
        //                connection.Open();

        //                using (SqlCommand cmd = new SqlCommand("PR_UPDATE_Vehicle", connection))
        //                {
        //                    cmd.CommandType = CommandType.StoredProcedure;

        //                    // Convert IFormFile to byte array
        //                    byte[] imageBytes = null;
        //                    if (imageFile != null && imageFile.Length > 0)
        //                    {
        //                        using (var memoryStream = new MemoryStream())
        //                        {
        //                            imageFile.CopyTo(memoryStream);
        //                            imageBytes = memoryStream.ToArray();
        //                        }
        //                    }

        //                    // Add parameters to the stored procedure
        //                    cmd.Parameters.AddWithValue("@VehicleID", vehicleModel.VehicleId);
        //                    cmd.Parameters.AddWithValue("@VehicleImage", imageBytes); // Assuming you are storing the image as a byte[]
        //                    cmd.Parameters.AddWithValue("@VehicleName", vehicleModel.VehicleName);
        //                    cmd.Parameters.AddWithValue("@VehicleTypeID", vehicleModel.VehicleTypeID);
        //                    cmd.Parameters.AddWithValue("@RegistrationNumber", vehicleModel.RegistrationNumber);
        //                    cmd.Parameters.AddWithValue("@NumberOfPassenger", vehicleModel.NumberOfPassenger);
        //                    cmd.Parameters.AddWithValue("@Status", vehicleModel.Status);
        //                    cmd.Parameters.AddWithValue("@ChargePerKM", vehicleModel.ChargePerKM);

        //                    int rowsAffected = cmd.ExecuteNonQuery();

        //                    return rowsAffected > 0;
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            // Handle exceptions or log errors
        //            Console.WriteLine(ex.Message);
        //            return false;
        //        }
        //    }
        //}


    }
}













