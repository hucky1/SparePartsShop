using SparePartsShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SparePartsShop.Services.Data
{
    public class ClientsRepository
    {
        private AppDBContext _context;
        public ClientsRepository(AppDBContext context)
        {
            _context = context;
        }
        public IEnumerable<Client> GetClients() =>
            _context.Clients;
        public Client GetClient(int id) =>
            _context.Clients.FirstOrDefault(x => x.Id == id);
    } 
}
