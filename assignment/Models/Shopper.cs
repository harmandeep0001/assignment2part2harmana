namespace assignment.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Shopper
    {
        [Key]
        public int Stock { get; set; }

        [Required]
        [StringLength(10)]
        public string Products { get; set; }

        [Required]
        [StringLength(10)]
        public string Food { get; set; }

        [Required]
        [StringLength(10)]
        public string Medicine { get; set; }

        public virtual Shopperss Shopperss { get; set; }
    }
}
