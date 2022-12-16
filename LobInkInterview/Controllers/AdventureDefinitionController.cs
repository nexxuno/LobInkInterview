using LobInkInterview.Contracts;
using LobInkInterview.DataAccess.Interfaces;
using LobInkInterview.DataAccess.Models;
using LobInkInterview.Services.Interfaces;
using Mapster;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LobInkInterview.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdventureDefinitionController : ControllerBase
    {
        private readonly ILogger<AdventureDefinitionController> _logger;
        private readonly IAdventureDefinitionsRepository adventureDefinitionsRepository;
        private readonly ISignatureHandler signatureHandler;

        public AdventureDefinitionController(ILogger<AdventureDefinitionController> logger, 
            IAdventureDefinitionsRepository adventureDefinitionsRepository,
            ISignatureHandler signatureHandler)
        {
            //usually I would use another layer (implementations would go in Services)
            //and I would inject the service here instead of the repository so that no BL (like mapping between objects) are in the controller methods

            _logger = logger;
            this.adventureDefinitionsRepository = adventureDefinitionsRepository;
            this.signatureHandler = signatureHandler;
        }

        // GET: api/<AdventureDefinitionController>
        [HttpGet]
        public async Task<IEnumerable<AdventureDefinitionResponse>> Get()
        {
            return (await adventureDefinitionsRepository.GetAllAsync()).Adapt<IEnumerable<AdventureDefinitionResponse>>();
        }

        // GET api/<AdventureDefinitionController>/5
        [HttpGet("{id}")]
        public async Task<Results<Ok<AdventureDefinitionResponse>, NotFound>> Get(Guid id)
        {
            var foundAdventure = await adventureDefinitionsRepository.GetAsync(id);
            var responseObject = foundAdventure.Adapt<AdventureDefinitionResponse>();
            return responseObject != null ? TypedResults.Ok(responseObject) : TypedResults.NotFound();
        }

        // POST api/<AdventureDefinitionController>
        [HttpPost]
        public async Task<AdventureDefinitionResponse> Post([FromBody] AdventureDefinitionRequest adventureDefinition)
        {
            var storageObject = adventureDefinition.Adapt<AdventureDefinitionDAL>();
            storageObject.Id = Guid.NewGuid();
            storageObject.Signature = signatureHandler.CreateSignature(adventureDefinition);
            await adventureDefinitionsRepository.CreateAsync(storageObject);
            var responseObject = storageObject.Adapt<AdventureDefinitionResponse>();
            return responseObject;
        }

        // PUT api/<AdventureDefinitionController>/5
        [HttpPut("{id}")]
        public async Task<Results<Ok<AdventureDefinitionResponse>, NotFound>> Put(Guid id, [FromBody] AdventureDefinitionRequest adventureDefinition)
        {
            var storageObject = adventureDefinition.Adapt<AdventureDefinitionDAL>();
            storageObject.Id = id;
            storageObject.Signature = signatureHandler.CreateSignature(adventureDefinition);
            var objectFound = await adventureDefinitionsRepository.UpdateAsync(storageObject);
            if(objectFound)
            {
                return TypedResults.Ok(storageObject.Adapt<AdventureDefinitionResponse>());
            }
            else
            {
                return TypedResults.NotFound();
            }
        }

        // DELETE api/<AdventureDefinitionController>/5
        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            //client doesn't care if the resource was already removed so we always return same code and we are idempotent
            await adventureDefinitionsRepository.DeleteAsync(id);
        }
    }
}
