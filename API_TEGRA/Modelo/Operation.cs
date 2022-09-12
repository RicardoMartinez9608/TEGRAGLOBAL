using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace API_TEGRA.Modelo
{
    public class Operation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Operation { get; set; }
        public Box Box { get; set; }
        public int Id_Box { get; set; }
        public int Quantity { get; set; }
        public DateTime Created_At { get;set; }
        public DateTime Updated_At { get;set; }
        public Operation_Type Operation_Type { get; set; }
        public int Id_Operation_Type { get; set; }

    }
}
