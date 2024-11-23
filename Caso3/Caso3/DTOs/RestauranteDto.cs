namespace Caso3.DTOs
{
    public class RestauranteDto
    {
        public int RestauranteId { get; set; } // Solo para PUT o DELETE
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
    }
}
