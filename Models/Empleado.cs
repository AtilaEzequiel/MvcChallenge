using System.ComponentModel.DataAnnotations;
using System;
using System.Data.Entity;
using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore;
//using MvcMovie.Models;



namespace MvcChallenge.Models

{
    public class Empleado
    {
      //  [Key]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Departamento { get; set; }
        public double Salario { get; set; }

    }

    // clase debe estar separada
    public class EmpDBContext : DbContext
    {
        public EmpDBContext() { }
        public DbSet<Empleado> Empleado { get; set; }
        public DbSet<cliente> Clientes { get; set; }
    }

}
