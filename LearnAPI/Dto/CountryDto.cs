﻿using LearnAPI.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace TourBooking.Dto
{
    public class CountryDto : Entity
    {
        public string CountryName { get; set; }
    }
}
