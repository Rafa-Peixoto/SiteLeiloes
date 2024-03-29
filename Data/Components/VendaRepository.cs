﻿using Microsoft.EntityFrameworkCore;
using SiteLeiloes.Data.Interfaces;
using SiteLeiloes.Models;

namespace SiteLeiloes.Data.Components
{
    public class VendaRepository : IVendaRepository
    {
        private readonly CarenseDBContext _context;
        private IEnumerable<Venda> _venda = new List<Venda>();
        public VendaRepository(CarenseDBContext context)
        {
            // Inicialize sua lista de vendas aqui, possivelmente carregando de um banco de dados
            _context = context;
        }

        public IEnumerable<Venda> GetAll()
        {
            return _context.Venda.ToList();
        }


        public Venda? GetById(int id)
        {
            return _context.Venda.FirstOrDefault(c => c.Id == id);
        }

        public bool Create(Venda venda)
        {
            try
            {
                _context.Venda.Add(venda);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public bool Update(Venda venda)
        {
            try
            {
                _context.Entry(venda).State = EntityState.Modified;
                return SaveChanges();
            }
            catch (Exception)
            {
                // Log the exception
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var venda = _context.Venda.FirstOrDefault(c => c.Id == id);
                if (venda == null)
                {
                    return false;
                }

                _context.Venda.Remove(venda);
                return SaveChanges();
            }
            catch (Exception)
            {
                // Log the exception
                return false;
            }
        }
    }
}
