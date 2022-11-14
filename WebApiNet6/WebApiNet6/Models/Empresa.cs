namespace WebApiNet6.Models
{
    public class Empresa
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }       
        public ICollection<Producto> ? Producto { get; set; }
    }
}
