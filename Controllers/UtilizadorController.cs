﻿using Microsoft.AspNetCore.Mvc;
using SiteLeiloes.Data.Interfaces;
using SiteLeiloes.Models; // Substitua com o namespace correto onde sua modelo Utilizador está localizada
namespace SiteLeiloes.Controllers
{
    [ApiController]
    [Route("api/utilizador")]
    public class UtilizadorController : ControllerBase
    {
        private readonly IUtilizadorRepository _repository;

        public UtilizadorController(IUtilizadorRepository repository)
        {
            _repository = repository;
        }

        // GET api/utilizador
        [HttpGet]
        public ActionResult<IEnumerable<Utilizador>> GetAll()
        {
            var result = _repository.GetAll();
            return Ok(result);
        }


        // GET api/utilizador/{id}
        [HttpGet("{id}")]
        public ActionResult<IEnumerable<Utilizador>> GetById(int id)
        {
            var result = _repository.GetById(id);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        //POST api/utilizador
        [HttpPost("{id}")]
        public ActionResult<Utilizador> Create(Utilizador utilizador)
        {
            try
            {
                _repository.Create(utilizador);
                _repository.SaveChanges();
                return Ok(utilizador);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        //PUT api/utilizador/{id}
        [HttpPut("{id}")]
        public ActionResult<Utilizador> Update(int id, Utilizador utilizador)
        {
            try
            {
                var existingUtilizador = _repository.GetById(id);
                if (existingUtilizador == null)
                {
                    return NotFound();
                }

                existingUtilizador.Username = utilizador.Username;
                existingUtilizador.Password = utilizador.Password;
                //existingUtilizador.Nome = utilizador.Nome;
                //existingUtilizador.Idade = utilizador.Idade;
                //existingUtilizador.Email = utilizador.Email;
                //existingUtilizador.Telefone = utilizador.Telefone;
                //existingUtilizador.CC = utilizador.CC;
                //existingUtilizador.Nif = utilizador.Nif;
                //existingUtilizador.Avaliacao_total = utilizador.Avaliacao_total;
                //existingUtilizador.Nr_avaliacoes = utilizador.Nr_avaliacoes;

                _repository.Update(existingUtilizador);
                _repository.SaveChanges();

                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        //DELETE api/utilizador/{id}
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var utilizador = _repository.GetById(id);
            if (utilizador == null)
            {
                return NotFound();
            }

            _repository.Delete(id);
            _repository.SaveChanges();

            return NoContent();
        }
    }
}