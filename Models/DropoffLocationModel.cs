namespace VehicleBookingAPI.Models
{
    public class DropoffLocationModel
    {
        public int DropoffLocationID { get; set; }

        public string? DropoffLocationName { get; set;}
        public string? DropoffLocationCode  { get; set;}
        public DateTime Created { get; set; }

        public DateTime Modified { get; set; } 
    }
}
