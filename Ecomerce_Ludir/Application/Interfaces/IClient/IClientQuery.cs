using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IClient
{
    public interface IClientQuery
    {
        Task<Client> GetClientByIdAsync(Guid clientId);
        Task<List<Client>> GetAllUsers();
        Task<Client> GetByUsuario(string usuario);
        Task<Client> GetByEmail(string email);
    }
}
