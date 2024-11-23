namespace Caso3.DTOs
{
    public class MenuDto
    {
        public int MenuId { get; set; }
        public int RestauranteId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string ImagenUrl { get; set; }
    }
}
