using System.Data.Entity;
using MvcChallenge.Models;
using System.ComponentModel.DataAnnotations;
//using Microsoft.EntityFrameworkCore;

namespace MvcChallenge.Data
{
    public class MvcChallengeContext
    {

    }

    public class EmpDBContext : DbContext
    {
        public EmpDBContext() { }
        public DbSet<Empleado> Empleado { get; set; }
        public DbSet<cliente> Clientes { get; set; }
        public DbSet<Alumno> Alumno { get; set; }
    }
}
