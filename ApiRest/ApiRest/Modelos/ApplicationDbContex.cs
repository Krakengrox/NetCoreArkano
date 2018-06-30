using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiRest.Modelos
{
    /// <summary>
    /// Generación de base de datos virtual
    /// </summary>
    public class ApplicationDbContex : DbContext
    {
        /// <summary>
        /// contenedor decomputadores
        /// </summary>
        public DbSet<Computer> Computers { get; set; }

        /// <summary>
        /// Inicialización de la clase con un parametro para configurar el dbcontext
        /// </summary>
        /// <param name="options"></param>
        public ApplicationDbContex(DbContextOptions<ApplicationDbContex> options)
            : base(options)
        {

        }
    }
}
