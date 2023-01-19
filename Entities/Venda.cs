using TechTestPaymentApi.Enums;

namespace TechTestPaymentApi.Entities
{
    public class Venda
    {
        public int Id { get; set; }
        public int VendedorId { get; set; }
        public DateTime Data { get; set; }
        public string Itens { get; set; }
        public StatusDePedido Status { get; set; }
    }
}
