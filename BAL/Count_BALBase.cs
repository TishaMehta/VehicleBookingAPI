using VehicleBookingAPI.DAL;
using VehicleBookingAPI.Models;

namespace VehicleBookingAPI.BAL
{
    public class Count_BALBase
    {
        #region PR_DASHBOARD_COUNTS
        public List<CountModel> PR_DASHBOARD_COUNTS()
        {

            Count_DALBase count_DALBase = new Count_DALBase();
            List<CountModel> countModels = count_DALBase.PR_DASHBOARD_COUNTS();
            return countModels;
        }
        #endregion
    }
}
