﻿using System;
using System.Collections.Generic;

namespace Hotel_Booking_System.Models;

public partial class User
{
    public int UserId { get; set; }

    public string? Password { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Email { get; set; }
}
