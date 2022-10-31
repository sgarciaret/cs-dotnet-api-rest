using Microsoft.AspNetCore.Mvc;
using CSApiRestPractice.Domain;
using CSApiRestPractice.Data;

namespace CSApiRestPractice.Controllers {

    [ApiController]
    [Route("api/clients")]
    public class ClientController : ControllerBase {

        private readonly ClientService clientService;

        public ClientController(ClientService clientService) {

            this.clientService = clientService;

        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Client>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(List<Client>))]
        public async Task<IActionResult> GetClients() {

            List<Client> clients = await clientService.GetClients();

            return new OkObjectResult(clients);

        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type =typeof(Client))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Client))]
        public async Task<IActionResult> GetClient(int id) {

            Client client = await clientService.GetClient(id);

            return new OkObjectResult(client);

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Client))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Client))]
        public async Task<IActionResult> SaveClient(Client client) {

            Client clientSaved = await clientService.SaveClient(client);

            return new OkObjectResult(clientSaved);

        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Client))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Client))]
        public async Task<IActionResult> UpdateClient(int id, Client client) {

            Client clientUpdated = await clientService.UpdateClient(id, client);

            return new OkObjectResult(clientUpdated);

        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Boolean))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Boolean))]
        public async Task<IActionResult> DeleteClient(int id) {

            Boolean response = await clientService.DeleteClient(id);

            return new OkObjectResult(response);

        }

    }

}
