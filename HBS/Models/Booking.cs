using System;
using System.Collections.Generic;

namespace Hotel_Booking_System.Models;

public partial class Booking
{
    public int BookingId { get; set; }

    public string? FullName { get; set; }

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public string? CheckIn { get; set; }

    public string? CheckOut { get; set; }

    public int? Perons { get; set; }
}
