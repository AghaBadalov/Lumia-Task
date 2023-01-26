using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace LumiaTask.Models
{
    public class Setting
    {
        public int Id { get; set; }
        [Required]
        [StringLength(maximumLength:50)]
        public string Key { get; set; }
        [Required]
        [StringLength(maximumLength: 50)]
        public string Value { get; set; }
    }
}
