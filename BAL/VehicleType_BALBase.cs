using VehicleBookingAPI.DAL;
using VehicleBookingAPI.Models;

namespace VehicleBookingAPI.BAL
{
    public class VehicleType_BALBase
    {
        #region PR_SELECT_ALL_VehicalType
        public List<VehicleTypeModel> PR_SELECT_ALL_VehicalType()
        {

            VehicleType_DALBase vehicleType_DALBase = new VehicleType_DALBase();
            List<VehicleTypeModel> vehicleTypeModels = vehicleType_DALBase.PR_SELECT_ALL_VehicalType();
            return vehicleTypeModels;
        }
        #endregion

        #region PR_SELECT_BY_PK_VehicleType
        public VehicleTypeModel PR_SELECT_BY_PK_VehicalType(int VehicleID)
        {

            VehicleType_DALBase vehicleType_DALBase = new VehicleType_DALBase();
            VehicleTypeModel vehicleTypeModel = vehicleType_DALBase.PR_SELECT_BY_PK_VehicalType(VehicleID);
            return vehicleTypeModel;


        }
        #endregion

        #region PR_DELETE_VehicleType
        public bool PR_DELETE_VehicleType(int VehicleTypeID)
        {
            VehicleType_DALBase dalVehicleType = new VehicleType_DALBase();
            if (dalVehicleType.PR_DELETE_VehicleType(VehicleTypeID))
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
            VehicleType_DALBase dalvehicleType = new VehicleType_DALBase();
            if (dalvehicleType.PR_VehicalType_INSERT(vehicleTypeModel))
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
            VehicleType_DALBase dalvehicleType = new VehicleType_DALBase();
            if (dalvehicleType.PR_UPDATE_VehicalType(VehicleTypeID, vehicleTypeModel))
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
