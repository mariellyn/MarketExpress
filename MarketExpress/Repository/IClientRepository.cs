using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketExpress.Models;

namespace MarketExpress.Repository
{
    public interface IClientRepository
    {
        ClientModel ListId (int id);
        List<ClientModel> SearchAll();
        ClientModel Add(ClientModel client);
        ClientModel Update(ClientModel client);
        bool Delete(int id);
    }
}
