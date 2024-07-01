namespace VehicleBookingAPI.Models
{
    public class BookingModel
    {
        public int BookingID { get; set; }
        public int UserID { get; set; }
        public string? FirstName { get; set; }
        public int VehicleID { get; set; }
        public string? VehicleName { get; set; }
        public int PickupLocationID { get; set; }
        public string? PickupLocationName { get; set; }
        public int DropOffLocationID { get; set; }
        public string? DropOffLocationName { get; set; }
        public DateTime PickupDate { get; set; }
        public DateTime DropOffDate { get; set; }

        public string? BookingStatus { get; set; }
        public decimal? TotalCharge { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
