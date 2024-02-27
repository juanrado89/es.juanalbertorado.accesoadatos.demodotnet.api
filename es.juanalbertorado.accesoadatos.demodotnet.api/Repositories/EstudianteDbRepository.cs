using es.juanalbertorado.accesoadatos.demodotnet.api.DDBB;
using es.juanalbertorado.accesoadatos.demodotnet.api.Entities;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace es.juanalbertorado.accesoadatos.demodotnet.api.Repositories
{
    public class EstudianteDbRepository : IEstudianteRepository
    {
        private readonly DemoDotNetDbContext dbContext;
        public void add(Estudiante estudiante)
        {
            dbContext.Estudiantees.Add(estudiante);
            dbContext.SaveChanges();
        }

        public List<Estudiante> find(string? nombre, string? apellidos, int? edad)
        {
            IQueryable<Estudiante> query = dbContext.Estudiantees;

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

        public List<Estudiante> findAll()
        {
            return dbContext.Estudiantees.ToList();
        }

        public Estudiante? findByid(string id)
        {
            return dbContext.Estudiantees.Find(id);
        }

        public void removeById(string id)
        {
            Estudiante? estudiante = this.findByid(id);
            if (estudiante != null)
            {
                dbContext.Estudiantees.Remove(estudiante);
                dbContext.SaveChanges();
            }
        }
    }
}
