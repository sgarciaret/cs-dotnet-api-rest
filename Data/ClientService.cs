using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

using CSApiRestPractice.Domain;

namespace CSApiRestPractice.Data {

    public class ClientService : DbContext {

        public ClientService(DbContextOptions<ClientService> options) : base(options) {

        }

        public DbSet<Client> ClientDao { get; set; }

        public async Task<Client?> GetClient(int id) {

            return await ClientDao.FirstOrDefaultAsync(x => x.ClientId == id);

        }

        public async Task<List<Client>> GetClients() {

            List<Client> clients = ClientDao.Select(client => client).ToList();

            return clients;

        }

        public async Task<Client> SaveClient(Client client) {

            Client clientToSave = new Client(
                    client.FirstName,
                    client.LastName,
                    client.Email,
                    client.PhoneNumber
                );

            EntityEntry<Client> response = await ClientDao.AddAsync(clientToSave);

            await SaveChangesAsync();

            return await GetClient(response.Entity.ClientId);

        }

        public async Task<Client> UpdateClient(int id, Client client) {

            Client clientToUpdate = new Client(
                id,
                client.FirstName,
                client.LastName,
                client.Email,
                client.PhoneNumber
                );

            ClientDao.Update(clientToUpdate);

            await SaveChangesAsync();

            return clientToUpdate;

        }

        public async Task<Boolean> DeleteClient(int id) {

            Client clientToDelete = await this.GetClient(id);

            ClientDao.Remove(clientToDelete);

            SaveChanges();

            return true;

        }

    }

}
