using es.juanalbertorado.accesoadatos.demodotnet.api.Dto;
using es.juanalbertorado.accesoadatos.demodotnet.api.Entities;
using es.juanalbertorado.accesoadatos.demodotnet.api.Repositories;
using es.juanalbertorado.accesoadatos.demodotnet.api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.ObjectModel;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace es.juanalbertorado.accesoadatos.demodotnet.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EstudianteController : ControllerBase
    {
        private readonly EstudianteService estudianteService;
        
        public EstudianteController(EstudianteService estudianteService)
        {
            this.estudianteService = estudianteService;
        }
        [HttpPost]
        [Route("add/id")]
        public ActionResult add(CrearEstudianteDto estudiante)
        {
            
            Estudiante nuevoEstudiante = new Estudiante(estudiante.Dni, estudiante.Nombre, estudiante.Apellidos, estudiante.FechaNacimiento);
            estudianteService.add(nuevoEstudiante);
            
            return Created();
        }
        [HttpGet]
        [Route("findall")]
        public ActionResult<Collection<Estudiante>> findAll() 
        {
            return Ok(estudianteService.findAll());
        }
        [HttpGet]
        [Route("find/id")]
        public ActionResult<Estudiante> findByid(string id)
        {
            Estudiante? estudiante = estudianteService.findByid(id);
            if (estudiante == null) 
            {
                return NotFound();
            }

            return Ok(estudiante);
        }
        [HttpDelete]
        [Route("remove/id")]
        public ActionResult removeById(string id)
        {
            estudianteService.removeById(id);
            return Ok();
        }

        [HttpPost]
        [Route("find-estudiante/id")]
        public ActionResult findEstudiante(FindEstudianteRequestDto request)
        {
            List<Estudiante> estudiantes = estudianteService.find(request.nombre,request.apellidos,request.edad);

            return Ok(estudiantes);
        }
    }

}
