namespace assignment.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Shopperss")]
    public partial class Shopperss
    {
        [Key]
        public int Price { get; set; }

        [Required]
        [StringLength(10)]
        public string Stock { get; set; }

        [Required]
        [StringLength(10)]
        public string Staff { get; set; }

        [Required]
        [StringLength(10)]
        public string Accessories { get; set; }

        public virtual Shopper Shopper { get; set; }
    }
}
