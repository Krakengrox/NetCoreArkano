using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest.Modelos
{
    /// <summary>
    /// Modelo computador
    /// </summary>
    public class Computer
    {

        public int id { get; set; }
        [Required]
        public float memory { get; set; }
        [Required]
        public float processor { get; set; }
        [Required]
        [Range(1, 2)]
        public int diskType { get; set; }
        public int state { get; set; }

    }

}
