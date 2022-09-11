using BackEnd.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Domain.IServices
{
    public interface IClienteService
    {
        Task CreateCliente(Cliente cliente);
        Task<List<Cliente>> GetListClientes();
        Task<List<Cliente>> GetListClientesFiltrada(string identificacion);
        Task UpdateCliente(Cliente cliente);
        Task<Cliente> GetCliente(string identificacion);
        Task<Cliente> BuscarCliente(string identificacion);
    }
}
