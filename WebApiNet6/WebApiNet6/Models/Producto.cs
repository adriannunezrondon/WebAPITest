namespace WebApiNet6.Models
{
    public class Producto
    {
        public int ID { get; set; }
        public string? Nombre { get; set; }
        public string? Categorias { get; set; }
        public string? Descripcion { get; set; }
        public float Precio { get; set; }
        public int Unidades { get; set; }
        public int EmpresaID { get; set; }

    }
}
