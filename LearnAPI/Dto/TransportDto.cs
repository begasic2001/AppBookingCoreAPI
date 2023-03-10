using LearnAPI.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace TourBooking.Dto
{
    public class TransportDto : Entity
    {
        public string TransportName { get; set; }
    }
}
