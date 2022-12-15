using LobInkInterview.Contracts;
using LobInkInterview.DataAccess.Interfaces;
using LobInkInterview.DataAccess.Models;
using LobInkInterview.DataAccess.Repositories;
using LobInkInterview.Services;
using LobInkInterview.Services.Interfaces;
using Mapster;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LobInkInterview.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdventureController : ControllerBase
    {
        private readonly ILogger<AdventureController> logger;
        private readonly IAdventuresRepository adventuresRepository;
        private readonly ISignatureHandler signatureHandler;

        public AdventureController(ILogger<AdventureController> logger,
            IAdventuresRepository adventuresRepository,
            ISignatureHandler signatureHandler)
        {
            //usually I would use another layer (implementations would go in Services)
            //and I would inject the service here instead of the repository so that no BL are in the controller methods

            this.logger = logger;
            this.adventuresRepository = adventuresRepository;
            this.signatureHandler = signatureHandler;
        }

        // GET: api/<AdventureController>
        [HttpGet]
        public async Task<IEnumerable<AdventureResponse>> Get()
        {
            return (await adventuresRepository.GetAllAsync()).Adapt<IEnumerable<AdventureResponse>>();
        }

        // GET api/<AdventureController>/5
        [HttpGet("{id}")]
        public async Task<AdventureResponse> Get(Guid id)
        {
            var foundAdventure = await adventuresRepository.GetAsync(id);
            var responseObject = foundAdventure.Adapt<AdventureResponse>();
            return responseObject;
        }

        // POST api/<AdventureController>
        [HttpPost]
        public async Task<AdventureResponse> Post([FromBody] AdventureRequest adventure)
        {
            if (!signatureHandler.CheckSignature(adventure.Adapt<AdventureDefinitionRequest>(), adventure.Signature))
                throw new Exception("TODO!");

            var storageObject = adventure.Adapt<AdventureDAL>();
            storageObject.Id = Guid.NewGuid();
            await adventuresRepository.CreateAsync(storageObject);
            var responseObject = storageObject.Adapt<AdventureResponse>();
            return responseObject;
        }

        // PUT api/<AdventureController>/5
        [HttpPut("{id}")]
        public async Task Put(Guid id, [FromBody] AdventureRequest adventure)
        {
            if (!signatureHandler.CheckSignature(adventure.Adapt<AdventureDefinitionRequest>(), adventure.Signature))
                throw new Exception("TODO!");

            var storageObject = adventure.Adapt<AdventureDAL>();
            storageObject.Id = id;
            await adventuresRepository.UpdateAsync(storageObject);//TODO check true
        }

        // DELETE api/<AdventureController>/5
        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            //client doesn't care if the resource was already removed so we always return same code and we are idempotent
            await adventuresRepository.DeleteAsync(id);
        }
    }
}
