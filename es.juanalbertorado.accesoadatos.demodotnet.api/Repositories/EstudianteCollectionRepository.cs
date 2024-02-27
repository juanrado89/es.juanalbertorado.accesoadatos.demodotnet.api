using es.juanalbertorado.accesoadatos.demodotnet.api.Entities;

namespace es.juanalbertorado.accesoadatos.demodotnet.api.Repositories
{

    public class EstudianteCollectionRepository : IEstudianteRepository
    {
        List<Estudiante> data = new List<Estudiante>();

        public void add(Estudiante estudiante)
        {
            data.Add(estudiante);
        }

        public Estudiante? findByid(string id)
        {
            return data.FirstOrDefault(e => e.Dni.Equals(id));

        }
        public List<Estudiante> findAll()
        {
            return data.ToList();

        }
        public void removeById(string id)
        {
            data.RemoveAll(e => e.Dni.Equals(id));
        }
        public List<Estudiante> find(string? nombre, string? apellidos, int? edad)
        {
            IQueryable<Estudiante> query = data.AsQueryable();

            if (!string.IsNullOrWhiteSpace(nombre))
            {
                query = query.Where(e => e.Nombre.Contains(nombre));
            }
            if (!string.IsNullOrWhiteSpace(apellidos))
            {
                query = query.Where(e => e.Apellidos.Contains(apellidos));
            }
            if (edad.HasValue)
            {
                query = query.Where(e => e.Edad == edad.Value);
            }

            return query.ToList();
        }
    }
}
