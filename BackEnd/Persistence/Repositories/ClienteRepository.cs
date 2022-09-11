using BackEnd.Domain.IRepositories;
using BackEnd.Domain.Models;
using BackEnd.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Persistence.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AplicationDbContext _context;
        public ClienteRepository(AplicationDbContext context)
        {
            _context = context;
        }


        public async Task<Cliente> BuscarCliente(string identificacion)
        {
            var cliente = await _context.Clientes.Where(x => x.Identificacion == identificacion).FirstOrDefaultAsync();
            return cliente;
        }

        public async Task CreateCliente(Cliente cliente)
        {
            _context.Add(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task<Cliente> GetCliente(string identificacion)
        {
            var cliente = await _context.Clientes.Where(x => x.Identificacion == identificacion).FirstOrDefaultAsync();
            return cliente;
        }

        public async Task<List<Cliente>> GetListClientes()
        {
            var listClientes = await _context.Clientes.Where(x => x.Identificacion != null).ToListAsync();
            return listClientes;
        }

        public async Task<List<Cliente>> GetListClientesFiltrada(string identificacion)
        {
            var listClientes = await _context.Clientes.Where(x => x.Identificacion == identificacion).ToListAsync();
            return listClientes;
        }

        public async Task UpdateCliente(Cliente cliente)
        {
            _context.Update(cliente);
            await _context.SaveChangesAsync();
        }
    }
}
