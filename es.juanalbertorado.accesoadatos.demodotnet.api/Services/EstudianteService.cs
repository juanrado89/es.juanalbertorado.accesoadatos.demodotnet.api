using es.juanalbertorado.accesoadatos.demodotnet.api.Entities;
using es.juanalbertorado.accesoadatos.demodotnet.api.Repositories;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace es.juanalbertorado.accesoadatos.demodotnet.api.Services
{
    public class EstudianteService
    {
        private readonly IEstudianteRepository estudianteRepository;
        public EstudianteService(IEstudianteRepository estudianteRepository)
        {
            this.estudianteRepository = estudianteRepository;
        }

        public void add(Estudiante estudiante)
        {
            estudianteRepository.add(estudiante);
        }

        public Estudiante? findByid(string id)
        {
            return estudianteRepository.findByid(id);

        }
        public List<Estudiante> findAll()
        {
            return estudianteRepository.findAll();

        }
        public void removeById(string id)
        {
            estudianteRepository.removeById(id);
        }
        public List<Estudiante> find(string? nombre, string? apellidos, int? edad) 
        {
            return estudianteRepository.find(nombre, apellidos, edad);
        }
    }
}
