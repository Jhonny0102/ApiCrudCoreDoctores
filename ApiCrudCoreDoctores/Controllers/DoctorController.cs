using ApiCrudCoreDoctores.Models;
using ApiCrudCoreDoctores.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiCrudCoreDoctores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private RepositoryDoctor repo;
        public DoctorController(RepositoryDoctor repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<List<Doctor>>> GetDoctores()
        {
            return await this.repo.GetDoctoresAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Doctor>> FindDoctor(int id)
        {
            return await this.repo.FindDoctorAsync(id);
        }

        [HttpPost]
        public async Task<ActionResult> PostDoctor(Doctor doc)
        {
            await this.repo.InsertDoctorAsync(doc.IdDoctor, doc.Apellido, doc.Especialidad, doc.Salario, doc.IdHospital);
            return Ok();
        }

        [HttpPut]
        public async Task<ActionResult> PutDoctor(Doctor doc)
        {
            await this.repo.UpdateDoctorAsync(doc.IdDoctor, doc.Apellido, doc.Especialidad, doc.Salario, doc.IdHospital);
            return Ok();
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteDoctor(int id)
        {
            await this.repo.DeleteDoctorAsync(id);
            return Ok();
        }
    }
}
