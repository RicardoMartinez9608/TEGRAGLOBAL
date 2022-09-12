using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace API_TEGRA.Modelo
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Product { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
        [NotMapped]
        public ICollection<Box> Boxes { get; set; }

    }
}
