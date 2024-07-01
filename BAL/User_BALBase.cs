using VehicleBookingAPI.DAL;
using VehicleBookingAPI.Models;

namespace VehicleBookingAPI.BAL
{
    public class User_BALBase
    {

        #region PR_SELECT_ALL_USER
        public List<UserModel> PR_SELECT_ALL_USER()
        {

            User_DALBase user_DALBase = new User_DALBase();
            List<UserModel> userModels = user_DALBase.PR_SELECT_ALL_USER();
            return userModels;
        }
        #endregion

        #region PR_SELECT_BY_PK_USER
        public UserModel PR_SELECT_BY_PK_USER(int UserID)
        {

            User_DALBase user_DALBase = new User_DALBase();
            UserModel userModel = user_DALBase.PR_SELECT_BY_PK_USER(UserID);
            return userModel;


        }
        #endregion

        #region PR_DELETE_USER
        public bool PR_DELETE_USER(int UserID)
        {
            User_DALBase dalUser = new User_DALBase();
            if (dalUser.PR_DELETE_USER(UserID))
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
            User_DALBase dalUser = new User_DALBase();
            if (dalUser.PR_USER_INSERT(userModel))
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
            User_DALBase dalUser = new User_DALBase();
            if (dalUser.PR_UPDATE_USER(UserID, userModel))
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
        public bool PR_User_Register(string FirstName, string LastName, string Email, string PhoneNumber, string Password)
        {
            User_DALBase User_DALBase = new User_DALBase();
            if (User_DALBase.PR_User_Register(FirstName, LastName, Email, PhoneNumber,Password))
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
