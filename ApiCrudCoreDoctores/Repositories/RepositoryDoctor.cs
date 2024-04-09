using ApiCrudCoreDoctores.Data;
using ApiCrudCoreDoctores.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop.Infrastructure;

namespace ApiCrudCoreDoctores.Repositories
{
    public class RepositoryDoctor
    {
        private DoctorContext context;
        public RepositoryDoctor(DoctorContext context)
        {
            this.context = context;
        }

        public async Task<List<Doctor>> GetDoctoresAsync()
        {
            return await this.context.Doctores.ToListAsync();
        }

        public async Task<Doctor> FindDoctorAsync(int id)
        {
            return await this.context.Doctores.FirstOrDefaultAsync(z => z.IdDoctor == id);
        }

        public async Task InsertDoctorAsync(int id, string apellido , string especialidad, int salario , int idhospital)
        {
            Doctor doct = new Doctor();
            doct.IdDoctor = id;
            doct.Apellido = apellido;
            doct.Especialidad = especialidad;
            doct.Salario = salario;
            doct.IdHospital = idhospital;
            this.context.Add(doct);
            await this.context.SaveChangesAsync();
        }

        public async Task UpdateDoctorAsync(int id, string apellido, string especialidad, int salario, int idhospital)
        {
            Doctor doct = await this.FindDoctorAsync(id);
            doct.Apellido = apellido;
            doct.Especialidad = especialidad;
            doct.Salario = salario;
            doct.IdHospital = idhospital;
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteDoctorAsync(int id)
        {
            Doctor doct = await this.FindDoctorAsync(id);
            this.context.Remove(doct);
            await this.context.SaveChangesAsync();
        }
    }
}
