using VehicleBookingAPI.DAL;
using VehicleBookingAPI.Models;
using static VehicleBookingAPI.DAL.Vehicles_DALBase;

namespace VehicleBookingAPI.BAL
{
    public class Vehicles_BALBase
    { 
        #region PR_SELECT_ALL_Vehicles
        public List<VehiclesModel> PR_SELECT_ALL_Vehicles()
            {

                Vehicles_DALBase vehicle_DALBase = new Vehicles_DALBase();
                List<VehiclesModel> vehiclesModels = vehicle_DALBase.PR_SELECT_ALL_Vehicles();
                return vehiclesModels;
            }
        #endregion

        #region PR_SELECT_BY_PK_Vehicles
        public VehiclesModel PR_SELECT_BY_PK_Vehicles(int VehicleID)
            {

                Vehicles_DALBase vehicle_DALBase = new Vehicles_DALBase();
                VehiclesModel vehiclesModels = vehicle_DALBase.PR_SELECT_BY_PK_Vehicles(VehicleID);
                return vehiclesModels;


            }
            #endregion

            #region API_User_Delete
            public bool PR_DELETE_Vehicles(int VehicleID)
            {
                Vehicles_DALBase dalVehicle = new Vehicles_DALBase();
                if (dalVehicle.PR_DELETE_Vehicles(VehicleID))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        #endregion

        #region API_User_Insert
        public bool PR_VEHICAL_INSERT(VehiclesModel vehicleModel)
        {
            Vehicles_DALBase dalVehicle = new Vehicles_DALBase();
            if (dalVehicle.PR_VEHICAL_INSERT(vehicleModel))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //public bool PR_VEHICAL_INSERT(VehiclesModel vehicleModel, IFormFile imageFile)
        //{
        //    try
        //    {
        //        // Perform any business logic checks or validations here before inserting

        //        // Call the repository method for inserting the vehicle
        //        return _vehicleRepository.PR_VEHICAL_INSERT(vehicleModel, imageFile);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Handle exceptions or log errors
        //        Console.WriteLine(ex.Message);
        //        return false;
        //    }
        //}
        #endregion

        #region API_User_Update
        public bool PR_UPDATE_Vehicle(int VehicleID, VehiclesModel vehicleModel)
        {
            Vehicles_DALBase dalVehicle = new Vehicles_DALBase();
            if (dalVehicle.PR_UPDATE_Vehicle(VehicleID, vehicleModel))
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

