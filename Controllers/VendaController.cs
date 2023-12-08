using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechTestPaymentApi.Context;
using TechTestPaymentApi.Entities;
using TechTestPaymentApi.Enums;


namespace TechTestPaymentApi.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class VendaController : ControllerBase
    {
            string Nome;
            int Idade;
            string Cidade;
        
        private void constructorTeste(string nome, int idade, string cidade){
            Cidade = cidade;
            Nome = nome;
            Idade = idade;
            
        }
        private readonly LojinhaContext _context;

        public VendaController(LojinhaContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create(Venda venda)
        {

            _context.Add(venda);

            _context.SaveChanges();
            return Ok(venda);
        }
        [HttpGet("{idVenda}")]
        public IActionResult ObterPorIdVenda(int idVenda)
        {
            var venda = _context.Vendas.Find(idVenda);

            if (venda == null)
                return NotFound();


            return Ok(venda);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Venda venda)
        {
            var vendaBanco = _context.Vendas.Find(id);
            
            if (vendaBanco.Status == Enums.StatusDePedido.Aguardando_Pagamento)

            {
                if (venda.Status == Enums.StatusDePedido.Pagamento_Aprovado)
                    vendaBanco.Status = venda.Status;
                if (venda.Status == Enums.StatusDePedido.Cancelada)
                    vendaBanco.Status = venda.Status;
            }
            if (vendaBanco.Status == Enums.StatusDePedido.Pagamento_Aprovado)
            {
                if (venda.Status == Enums.StatusDePedido.Enviado_Para_Transportadora)
                    vendaBanco.Status = venda.Status;
                if (venda.Status == Enums.StatusDePedido.Cancelada)
                    vendaBanco.Status = venda.Status;
            }
            if (vendaBanco.Status == Enums.StatusDePedido.Enviado_Para_Transportadora)
            {
                if (venda.Status == Enums.StatusDePedido.Entregue)
                    vendaBanco.Status = venda.Status;
            }

            _context.Vendas.Update(vendaBanco);
            _context.SaveChanges();
            return Ok(venda);
        }
    }
}
