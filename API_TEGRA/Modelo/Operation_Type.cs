using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace API_TEGRA.Modelo
{
    public class Operation_Type
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Operation_Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created_At { get; set; }
        public DateTime Updated_At { get; set; }
        [NotMapped]
        public ICollection<Operation> Operations { get; set; }

    }
}
