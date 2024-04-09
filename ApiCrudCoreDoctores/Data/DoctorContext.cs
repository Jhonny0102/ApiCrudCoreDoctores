using ApiCrudCoreDoctores.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiCrudCoreDoctores.Data
{
    public class DoctorContext : DbContext
    {
        public DoctorContext(DbContextOptions<DoctorContext> options)
            :base(options){}

        public DbSet<Doctor> Doctores { get; set; }
    }
}
