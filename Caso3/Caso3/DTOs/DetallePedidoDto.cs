namespace Caso3.DTOs
{
    public class DetallePedidoDto
    {
        public int DetallePedidoId { get; set; }
        public int PedidoId { get; set; }
        public int MenuId { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }
    }
}
