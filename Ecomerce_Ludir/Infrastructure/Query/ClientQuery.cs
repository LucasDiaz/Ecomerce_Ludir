using Application.Interfaces.IClient;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Query
{
    public class ClientQuery : IClientQuery
    {
        private readonly AppDBContextEcomerce _context;
        public ClientQuery(AppDBContextEcomerce context)
        {
            _context = context;
        }

        public async Task<List<Client>> GetAllUsers()
        {
            return await _context.Clients.Where(u => u.IsActive == true).ToListAsync();
        }

        public async Task<Client> GetByEmail(string email)
        {
            return await _context.Clients.FirstOrDefaultAsync(o => o.Email == email && o.IsActive == true);
        }

      

        public async Task<Client> GetClientByIdAsync(Guid clientId)
        {
            return await _context.Clients.FirstOrDefaultAsync(o => o.UserId ==clientId && o.IsActive == true);
        }

        public async Task<Client> GetByUsuario(string usuario)
        {
            return await _context.Clients
           .FirstOrDefaultAsync(o => o.UserName == usuario && o.IsActive == true);
        }
    }
}
