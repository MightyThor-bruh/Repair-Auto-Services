using AutoService.Models.Enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AutoService.Models
{
    public class ModelType
    {
        [Key]
        public ModelTypes Id { get; set; }
        [Required]
        public string Name { get; set; }

        public virtual ICollection<Model> Models { get; set; }
    }
}
