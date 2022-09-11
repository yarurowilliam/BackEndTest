using BackEnd.Domain.IRepositories;
using BackEnd.Domain.IServices;
using BackEnd.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEnd.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public async Task<Cliente> BuscarCliente(string identificacion)
        {
            return await _clienteRepository.BuscarCliente(identificacion);
        }

        public async Task CreateCliente(Cliente cliente)
        {
            await _clienteRepository.CreateCliente(cliente);
        }

        public async Task<Cliente> GetCliente(string identificacion)
        {
            return await _clienteRepository.GetCliente(identificacion);
        }

        public async Task<List<Cliente>> GetListClientes()
        {
            return await _clienteRepository.GetListClientes();
        }

        public async Task<List<Cliente>> GetListClientesFiltrada(string identificacion)
        {
            return await _clienteRepository.GetListClientesFiltrada(identificacion);
        }

        public async Task UpdateCliente(Cliente cliente)
        {
            await _clienteRepository.UpdateCliente(cliente);
        }
    }
}
