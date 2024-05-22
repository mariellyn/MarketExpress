using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MarketExpress.Data;
using MarketExpress.Models;

namespace MarketExpress.Repository
{
    public class ClientRepository : IClientRepository
    {
        private readonly BancoContext _bancoContext;
        public ClientRepository( BancoContext bancoContext) 
        { 
            this._bancoContext = bancoContext;
        }

        public ClientModel ListId(int id)
        {
            return _bancoContext.Clients.FirstOrDefault(x => x.Id == id);
        }
        public List<ClientModel> SearchAll()
        {
            return _bancoContext.Clients.ToList();
        }
        public ClientModel Add(ClientModel client)
        {
            _bancoContext.Clients.Add(client);
            _bancoContext.SaveChanges();
            return client;
        }

        public ClientModel Update(ClientModel client)
        {
            ClientModel clientDB = ListId(client.Id);

            if (clientDB == null) throw new System.Exception("There was an error updating the client");

            clientDB.Name = client.Name;
            clientDB.Email = client.Email;
            clientDB.Phone = client.Phone;
            clientDB.BirthDate = client.BirthDate;
            clientDB.Adress = client.Adress;
            clientDB.Locality = client.Locality;
            clientDB.PostalCode = client.PostalCode;
            clientDB.NIF = client.NIF;
            clientDB.CustumerNumber = client.CustumerNumber;

            _bancoContext.Clients.Update(clientDB);
            _bancoContext.SaveChanges();
            return clientDB;
        }

        public bool Delete(int id)
        {
            ClientModel clientDB = ListId(id);

            if (clientDB == null) throw new System.Exception("There was an error deleting the client");

            _bancoContext.Clients.Remove(clientDB);
            _bancoContext.SaveChanges();

            return true;
        }
    }
}
