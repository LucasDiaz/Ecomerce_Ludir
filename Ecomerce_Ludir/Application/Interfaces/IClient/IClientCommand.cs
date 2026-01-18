using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.IClient
{
    public interface IClientCommand
    {
        Task<Client> CreateUser(Client user);
        Task InsertUser(Client user);
        Task UpdateUser(Client user);
    }
}
