namespace Caso3.DTOs
{
    public class PagoDto
    {
        public int PagoId { get; set; }
        public int PedidoId { get; set; }
        public decimal Monto { get; set; }
        public string MetodoPago { get; set; }
        public DateTime FechaPago { get; set; }
    }
}
