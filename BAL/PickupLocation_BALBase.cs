using VehicleBookingAPI.DAL;
using VehicleBookingAPI.Models;

namespace VehicleBookingAPI.BAL
{
    public class PickupLocation_BALBase
    {
        #region PR_SELECT_ALL_Location
        public List<PickupLocation> PR_SELECT_ALL_PickupLocation()
        {

            PickupLocation_DALBase Location_DALBase = new PickupLocation_DALBase();
            List<PickupLocation> LocationModels = Location_DALBase.PR_SELECT_ALL_PickupLocation();
            return LocationModels;
        }
        #endregion

        #region PR_SELECT_BY_PK_Location
        public PickupLocation PR_SELECT_BY_PK_PickupLocation(int PickupLocationID)
        {

            PickupLocation_DALBase Location_DALBase = new PickupLocation_DALBase();
            PickupLocation LocationModel = Location_DALBase.PR_SELECT_BY_PK_PickupLocation(PickupLocationID);
            return LocationModel;


        }
        #endregion

        #region PR_DELETE_Location
        public bool PR_DELETE_PickupLocation(int LocationID)
        {
            PickupLocation_DALBase dallocation = new PickupLocation_DALBase();
            if (dallocation.PR_DELETE_PickupLocation(LocationID))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region PR_Location_INSERT
        public bool PR_PickupLocation_INSERT(PickupLocation LocationModel)
        {
            PickupLocation_DALBase dallocation = new PickupLocation_DALBase();
            if (dallocation.PR_PickupLocation_INSERT(LocationModel))
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
        public bool PR_UPDATE_PickupLocation(int LocationID, PickupLocation LocationModel)
        {
            PickupLocation_DALBase dallocation = new PickupLocation_DALBase();
            if (dallocation.PR_UPDATE_PickupLocation(LocationID, LocationModel))
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
