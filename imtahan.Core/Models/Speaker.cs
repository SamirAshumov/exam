using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace imtahan.Core.Models
{
    public class Speaker : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        public string Fullname { get; set; }
        [Required]
        [MaxLength(100)]
        public string Description { get; set; }

        public string? ImageURL { get; set; }

        [NotMapped]
        public IFormFile? ImageFile { get; set; }    

    }
}
