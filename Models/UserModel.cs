namespace VehicleBookingAPI.Models
{
    public class UserModel
    {
        public int UserID { get; set; } 
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public string? Password { get; set; }
        public bool IsAdmin { get; set; }
        //public string? EvenDate { get; set; }
        //public string? Message { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }
    }
}
