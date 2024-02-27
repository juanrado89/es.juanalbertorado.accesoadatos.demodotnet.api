namespace es.juanalbertorado.accesoadatos.demodotnet.api.Entities
{
    public class Modulo
    {
        public int id { get; set; }
        public string modulo { get; set; }
        public int horas { get; set; }
        public List<Estudiante> estudiantes { get; set; }
    }
}
