namespace Caso3.DTOs
{
    public class PedidoDto
    {
        public int PedidoId { get; set; }
        public int UsuarioId { get; set; }
        public int RestauranteId { get; set; }
        public DateTime FechaPedido { get; set; }
        public decimal Total { get; set; }
        public string Estado { get; set; }
    }
}
