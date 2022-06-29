using AutoService.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace AutoService.Models
{
    public class Model
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public double Power { get; set; }
        [Required]
        public double AccelerationSec { get; set; }

        public ModelTypes ModelTypeId { get; set; }
        public virtual ModelType Type { get; set; }
        public int ProducerId { get; set; }
        public virtual Producer Producer { get; set; }
    }
}
