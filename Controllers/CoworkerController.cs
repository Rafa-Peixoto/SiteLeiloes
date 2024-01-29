using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using SiteLeiloes.Models; // Substitua com o namespace correto onde sua modelo Coworker está localizada
using SiteLeiloes.Data.Components; // Substitua com o namespace correto onde sua CoworkerRepository está localizada
using SiteLeiloes.Data;
using SiteLeiloes.Data.Interfaces;
namespace SiteLeiloes.Controllers
{
    [ApiController]
    [Route("api/coworker")]
    public class CoworkerController : ControllerBase
    {
        private readonly ICoworkerRepository _repository;

        public CoworkerController(ICoworkerRepository repository)
        {
            _repository = repository;
        }

        // GET api/coworker
        [HttpGet]
        public ActionResult<IEnumerable<Coworker>> GetAll()
        {
            var result = _repository.GetAll();
            return Ok(result);
        }
        

        // GET api/coworker/{id}
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Coworker>> GetById(int id)
        {
            var result = _repository.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        
        //POST api/coworker
        [HttpPost("{id}")]
        public ActionResult<Coworker> Create(Coworker coworker)
        {
            try
            {
                _repository.Create(coworker);
                _repository.SaveChanges();
                return Ok(coworker);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        //PUT api/coworker/{id}
        [HttpPut("{id}")]
        public ActionResult<Coworker> Update(int id, Coworker coworker)
        {
            try
            {
                var existingCoworker = _repository.GetById(id);
                if (existingCoworker == null)
                {
                    return NotFound();
                }

                existingCoworker.FirstName = coworker.FirstName;
                existingCoworker.LastName = coworker.LastName;
                existingCoworker.Nif = coworker.Nif;

                _repository.Update(existingCoworker);
                _repository.SaveChanges();

                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        //DELETE api/coworkor/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var coworker = _repository.GetById(id);
            if (coworker == null)
            {
                return NotFound();
            }

            _repository.Delete(id);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}