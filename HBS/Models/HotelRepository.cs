namespace Hotel_Booking_System.Models
{
    public class HotelRepository
    {
        public static List<Booking> bookings = new List<Booking>();

        public static void addBooking(Booking b)
        {
            bookings.Add(b);
        }
    }
}
