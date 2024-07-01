using VehicleBookingAPI.DAL;
using VehicleBookingAPI.Models;

namespace VehicleBookingAPI.BAL
{
    public class DropoffLocation_BALBase
    {
        #region PR_SELECT_ALL_DropoffLocation
        public List<DropoffLocationModel> PR_SELECT_ALL_DropoffLocation()
        {

            DropoffLocation_DALBase dropoffLocation_DALBase = new DropoffLocation_DALBase();
            List<DropoffLocationModel> dropoffLocationModels = dropoffLocation_DALBase.PR_SELECT_ALL_PickupLocation();
            return dropoffLocationModels;
        }
        #endregion

        #region PR_SELECT_BY_PK_DropoffLocation
        public DropoffLocationModel PR_SELECT_BY_PK_DropoffLocation(int DropoffLocationID)
        {

            DropoffLocation_DALBase dropoffLocation_DALBase = new DropoffLocation_DALBase();
            DropoffLocationModel dropoffLocationModel = dropoffLocation_DALBase.PR_SELECT_BY_PK_DropoffLocation(DropoffLocationID);
            return dropoffLocationModel;


        }
        #endregion

        #region PR_DELETE_DropoffLocation
        public bool PR_DELETE_DropoffLocation(int DropoffLocationID)
        {
            DropoffLocation_DALBase dal = new DropoffLocation_DALBase();
            if (dal.PR_DELETE_DropoffLocation(DropoffLocationID))
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
            DropoffLocation_DALBase dal = new DropoffLocation_DALBase();
            if (dal.PR_DropoffLocation_INSERT(dropoffLocationModel))
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
            DropoffLocation_DALBase dropoffLocation_DALBase = new DropoffLocation_DALBase();
            if (dropoffLocation_DALBase.PR_UPDATE_DropoffLocation(DropoffLocationID, dropoffLocationModel))
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
