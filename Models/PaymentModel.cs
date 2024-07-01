namespace VehicleBookingAPI.Models
{
    public class PaymentModel
    {
        public int PaymentID { get; set; }

        public int BookingID { get; set; }

        public decimal Amount { get; set; }

        public DateTime PaymentDate { get; set; }
        public string? PaymentStatus { get; set; }
        public string? PaymentMethod { get; set;}
        public DateTime Created { get; set;}
        public DateTime Modified { get; set; }
    }
}
