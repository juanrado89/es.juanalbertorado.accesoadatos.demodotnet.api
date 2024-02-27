using System.ComponentModel.DataAnnotations;

namespace es.juanalbertorado.accesoadatos.demodotnet.api.Entities
{
    public class Estudiante
    {
        [Key]
        public string Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }

        public DateOnly FechaNacimiento { get; set; }

        public List<Modulo> Modulos { get; set; }


        public Estudiante() { }

        public Estudiante(string Dni, string Nombre, string Apellidos, string FechaNacimiento)
        {
            this.Dni = Dni;
            this.Nombre = Nombre;
            this.Apellidos = Apellidos;
            this.FechaNacimiento = DateOnly.Parse(FechaNacimiento);
        }

        public int Edad
        {
            get
            {
                var periodo = DateTime.Now - new DateTime(this.FechaNacimiento.Year, this.FechaNacimiento.Month, this.FechaNacimiento.Day);
                return (new DateTime(1,1,1) + periodo).Year -1; 
            }
        }
    }
}
