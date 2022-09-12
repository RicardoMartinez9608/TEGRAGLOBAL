using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace API_TEGRA.Modelo
{
    public class Box
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Box { get; set; }
        public string Box_Number { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
        public Product Product { get; set; }
        public int Id_Product { get; set; }
        [NotMapped]
        public ICollection<Operation> Operations { get; set; }

    }
}
