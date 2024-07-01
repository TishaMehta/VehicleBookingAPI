namespace VehicleBookingAPI.Models
{
    public class PickupLocation
    {
        public int PickupLocationID { get; set; }

        public string? PickupLocationName { get; set; }

        public string? PickupLocationCode { get; set; }

        public DateTime Created { get; set; }
        public DateTime Modified { get; set;}

    }
}
