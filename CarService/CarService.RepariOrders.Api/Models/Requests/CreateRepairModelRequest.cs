using System;
using System.ComponentModel.DataAnnotations;

namespace CarService.RepariOrders.Api.Models.Requests
{
    public class CreateRepairModelRequest
    {
        [Required]
        public double Price { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public Guid CarId { get; set; }
    }
}
