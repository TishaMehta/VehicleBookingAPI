namespace VehicleBookingAPI.Models
{
    public class VehiclesModel
    {
        public int VehicleId { get; set; }
        public string? VehicleName { get; set;}
        public int VehicleTypeID { get; set;}
        //public string? VehicleImage { get; set; }
        public string? VehicleTypeName { get; set; }
        public string? RegistrationNumber { get; set;}   
        public int NumberOfPassenger { get; set;}
        public string? Status { get; set;}
        public decimal ChargePerKM { get; set;}
        public string? Created { get; set; }
        public string? Modified { get; set; }
    }
}
