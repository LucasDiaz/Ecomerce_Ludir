using Application.Interfaces.IClient;
using Domain.Entities;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Command
{
    public class ClientCommand: IClientCommand
    {
        private readonly AppDBContextEcomerce _context;
        public ClientCommand(AppDBContextEcomerce context)
        {
            _context = context;
        }

        public async Task<Client> CreateUser(Client user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task InsertUser(Client user)
        {
            _context.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUser(Client user)
        {
            _context.Update(user);
            await _context.SaveChangesAsync();
        }
    }
    
}
