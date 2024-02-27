using es.juanalbertorado.accesoadatos.demodotnet.api.Entities;

namespace es.juanalbertorado.accesoadatos.demodotnet.api.Repositories
{
    public interface IEstudianteRepository
    {
        void add(Estudiante estudiante);
        List<Estudiante> find(string? nombre, string? apellidos, int? edad);
        List<Estudiante> findAll();
        Estudiante? findByid(string id);
        void removeById(string id);
    }
}