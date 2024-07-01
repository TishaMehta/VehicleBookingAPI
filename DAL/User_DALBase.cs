using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System.Data.Common;
using System.Data;
using VehicleBookingAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace VehicleBookingAPI.DAL
{
    public class User_DALBase : DAL_Helpers
    {
        #region PR_SELECT_ALL_USER

        public List<UserModel> PR_SELECT_ALL_USER()
        {

            SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
            DbCommand dbcommand = sqlDatabase.GetStoredProcCommand("PR_SELECT_ALL_USER");
            List<UserModel> userModels = new List<UserModel>();
            using (IDataReader dr = sqlDatabase.ExecuteReader(dbcommand))
            {
                while (dr.Read())
                {
                    UserModel userModel = new UserModel();
                    userModel.UserID = Convert.ToInt32(dr["UserID"].ToString());
                    userModel.FirstName = dr["FirstName"].ToString();
                    userModel.LastName = dr["LastName"].ToString();
                    userModel.Email = dr["Email"].ToString();
                    userModel.PhoneNumber = dr["PhoneNumber"].ToString();
                    userModel.Address = dr["Address"].ToString();

                   userModel.Password = dr["Password"].ToString();
                    userModel.IsAdmin = Convert.ToBoolean(dr["IsAdmin"].ToString());
                    userModel.Created = Convert.ToDateTime(dr["Created"].ToString());
                    userModel.Modified = Convert.ToDateTime(dr["Modified"].ToString());

                    userModels.Add(userModel);
                }
                return userModels;
            }




        }

        #endregion

        #region PR_SELECT_BY_PK_USER
        public UserModel PR_SELECT_BY_PK_USER(int UserID)
        {


            SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
            DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_SELECT_BY_PK_USER");
            sqlDatabase.AddInParameter(dbCommand, "@UserID", SqlDbType.Int, UserID);
            UserModel userModel = new UserModel();
            using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
            {
                while (dr.Read())
                {
                    userModel.UserID = Convert.ToInt32(dr["UserID"].ToString());
                    userModel.FirstName = dr["FirstName"].ToString();
                    userModel.LastName = dr["LastName"].ToString();
                    userModel.Email = dr["Email"].ToString();
                    userModel.PhoneNumber = dr["PhoneNumber"].ToString();
                    userModel.Address = dr["Address"].ToString();
                    userModel.Password = dr["Password"].ToString();
                    userModel.IsAdmin = Convert.ToBoolean(dr["IsAdmin"].ToString());
                    userModel.Created = Convert.ToDateTime(dr["Created"].ToString());
                    userModel.Modified = Convert.ToDateTime(dr["Modified"].ToString());
                }


            }
            return userModel;

        }
        #endregion

        #region PR_DELETE_USER

        public bool PR_DELETE_USER(int UserID)
        {
            SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
            DbCommand cmd = sqlDatabase.GetStoredProcCommand("PR_DELETE_USER");
            sqlDatabase.AddInParameter(cmd, "@UserID", SqlDbType.Int, UserID);
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
       
        #region PR_USER_INSERT
        public bool PR_USER_INSERT(UserModel userModel)
        {
            SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
            DbCommand cmd = sqlDatabase.GetStoredProcCommand("PR_USER_INSERT");
            sqlDatabase.AddInParameter(cmd, "@FirstName", SqlDbType.VarChar, userModel.FirstName);
            sqlDatabase.AddInParameter(cmd, "@LastName", SqlDbType.VarChar, userModel.LastName);
            sqlDatabase.AddInParameter(cmd, "@Email", SqlDbType.VarChar, userModel.Email);
            sqlDatabase.AddInParameter(cmd, "@PhoneNumber", SqlDbType.VarChar, userModel.PhoneNumber);
            sqlDatabase.AddInParameter(cmd, "@Address", SqlDbType.VarChar, userModel.Address);
            sqlDatabase.AddInParameter(cmd, "@Password", SqlDbType.VarChar, userModel.Password);
            sqlDatabase.AddInParameter(cmd, "@IsAdmin", SqlDbType.VarChar, userModel.IsAdmin);

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

        #region PR_UPDATE_USER
        public bool PR_UPDATE_USER(int UserID, UserModel userModel)
        {
            SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
            DbCommand cmd = sqlDatabase.GetStoredProcCommand("PR_UPDATE_USER");
            sqlDatabase.AddInParameter(cmd, "@UserID", SqlDbType.Int, userModel.UserID);

            sqlDatabase.AddInParameter(cmd, "@FirstName", SqlDbType.VarChar, userModel.FirstName);
            sqlDatabase.AddInParameter(cmd, "@LastName", SqlDbType.VarChar, userModel.LastName);
            sqlDatabase.AddInParameter(cmd, "@Email", SqlDbType.VarChar, userModel.Email);
            sqlDatabase.AddInParameter(cmd, "@PhoneNumber", SqlDbType.VarChar, userModel.PhoneNumber);
            sqlDatabase.AddInParameter(cmd, "@Address", SqlDbType.VarChar, userModel.Address);
            sqlDatabase.AddInParameter(cmd, "@Password", SqlDbType.VarChar, userModel.Password);
            sqlDatabase.AddInParameter(cmd, "@IsAdmin", SqlDbType.VarChar, userModel.IsAdmin);
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

        #region API_User_Register
        public bool PR_User_Register(string FirstName, string LastName, string Email, string PhoneNumber,string Password)
        {
            SqlDatabase sqlDatabase = new SqlDatabase(ConnString);
            DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_User_Register");
            sqlDatabase.AddInParameter(dbCommand, "@FirstName", SqlDbType.VarChar, FirstName);
            sqlDatabase.AddInParameter(dbCommand, "@LastName", SqlDbType.VarChar, LastName);
            sqlDatabase.AddInParameter(dbCommand, "@Email", SqlDbType.VarChar, Email);
            sqlDatabase.AddInParameter(dbCommand, "@PhoneNumber", SqlDbType.VarChar, PhoneNumber);
            //sqlDatabase.AddInParameter(dbCommand, "@Address", SqlDbType.VarChar, Address);
            sqlDatabase.AddInParameter(dbCommand, "@Password", SqlDbType.VarChar, Password);

            if (Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand)))
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


