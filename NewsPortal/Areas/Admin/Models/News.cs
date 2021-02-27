using Microsoft.AspNetCore.Http;
using NewsPortal.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NewsPortal.Models {
    public class News : BaseEntity {

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        public string Image { get; set; }
        //public Category Category { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }

        public int? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }



    }
}
