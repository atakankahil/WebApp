using System;
using System.ComponentModel.DataAnnotations;

namespace App.Web.Models.Domain
{
    public class Category
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

    }
}
