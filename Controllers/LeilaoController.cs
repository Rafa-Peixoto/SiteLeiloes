using Microsoft.AspNetCore.Mvc;
using SiteLeiloes.Data.Interfaces; // Substitua com o namespace correto onde sua ILeilaoRepository está localizada
using SiteLeiloes.Models; // Substitua com o namespace correto onde sua modelo Leilao está localizada

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
        public async Task<ActionResult<IEnumerable<Leilao>>> GetAll()
        {
            var result = await _repository.GetAllAsync();
            return Ok(result);
        }

        // GET api/leilao/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Leilao>> GetById(int id)
        {
            var result = await _repository.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        //POST api/leilao
        [HttpPost]
        public async Task<ActionResult<Leilao>> Create(Leilao leilao)
        {
            try
            {
                await _repository.CreateAsync(leilao);
                await _repository.SaveChangesAsync();
                return CreatedAtAction(nameof(GetById), new { id = leilao.Id }, leilao);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //PUT api/leilao/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Leilao leilao)
        {
            if (id != leilao.Id)
            {
                return BadRequest();
            }

            try
            {
                await _repository.UpdateAsync(leilao);
                await _repository.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception e)
            {
                if (!await _repository.ExistsAsync(id))
                {
                    return NotFound();
                }
                return BadRequest(e.Message);
            }
        }

        //DELETE api/leilao/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var leilao = await _repository.GetByIdAsync(id);
                if (leilao == null)
                {
                    return NotFound();
                }

                await _repository.DeleteAsync(id);
                await _repository.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // POST api/leilao/submitBid
        [HttpPost("submitBid")]
        public async Task<ActionResult> SubmitBid([FromBody] BidModel bid)
        {
            try
            {
                var leilao = await _repository.GetByIdAsync(bid.AuctionId);
                if (leilao == null)
                {
                    return NotFound("Leilão não encontrado.");
                }

                if (bid.Value <= leilao.Valor)
                {
                    return BadRequest("O valor da licitação deve ser maior que o lance atual.");
                }

                // Atualize o lance atual aqui
                leilao.Valor = bid.Value;
                await _repository.UpdateAsync(leilao);
                await _repository.SaveChangesAsync();

                return Ok(new { success = true, message = "Lance recebido com sucesso!" });
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, e.Message);
            }
        }
    }

    // Defina o modelo BidModel no mesmo namespace que o controlador
    public class BidModel
    {
        public int AuctionId { get; set; }
        public float Value { get; set; }
    }
}
