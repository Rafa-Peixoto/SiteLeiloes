using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using SiteLeiloes.Models; // Substitua com o namespace correto onde sua modelo Leilao está localizada
using SiteLeiloes.Data.Components; // Substitua com o namespace correto onde sua LeilaoRepository está localizada
using SiteLeiloes.Data;
using SiteLeiloes.Data.Interfaces;
namespace SiteLeiloes.Controllers
{
    [ApiController]
    [Route("api/leilao")]
    public class LeilaoController : ControllerBase
    {
        private readonly ILeilaoRepository _repository;

        public LeilaoController(ILeilaoRepository repository)
        {
            _repository = repository;
        }

        // GET api/leilao
        [HttpGet]
        public ActionResult<IEnumerable<Leilao>> GetAll()
        {
            var result = _repository.GetAll();
            return Ok(result);
        }


        // GET api/leilao/{id}
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Leilao>> GetById(int id)
        {
            var result = _repository.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        //POST api/leilao
        [HttpPost("{id}")]
        public ActionResult<Leilao> Create(Leilao leilao)
        {
            try
            {
                _repository.Create(leilao);
                _repository.SaveChanges();
                return Ok(leilao);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        //PUT api/leilao/{id}
        [HttpPut("{id}")]
        public ActionResult<Leilao> Update(int id, Leilao leilao)
        {
            try
            {
                var existingLeilao = _repository.GetById(id);
                if (existingLeilao == null)
                {
                    return NotFound();
                }

                existingLeilao.Preco_minimo = leilao.Preco_minimo;
                existingLeilao.Cliente = leilao.Cliente;
                existingLeilao.Valor = leilao.Valor;
                existingLeilao.Vendedor = leilao.Vendedor;
                existingLeilao.Carro = leilao.Carro;
                existingLeilao.Data_de_inicio = leilao.Data_de_inicio;
                existingLeilao.Data_de_fim = leilao.Data_de_fim;




                _repository.Update(existingLeilao);
                _repository.SaveChanges();

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        //DELETE api/leilao/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var leilao = _repository.GetById(id);
            if (leilao == null)
            {
                return NotFound();
            }

            _repository.Delete(id);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}