using Agenda.Application.Constants;
using Agenda.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Agenda.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize(Roles = Roles.Admin)]
    public class InteractionController : MainController
    {
        private readonly IInteractionService _interactionService;

        public InteractionController(IInteractionService interactionService)
        {
            _interactionService = interactionService;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return OkCustomResponse(await _interactionService.RecoverAll());
        }

        [HttpGet("types")]
        public async Task<ActionResult> GetTypes()
        {
            return OkCustomResponse(await _interactionService.RecoverTypes());
        }

        [HttpGet("save-json")]
        public async Task<ActionResult> SaveJson()
        {
            await _interactionService.SaveJsonInteractionsAsync();
            return OkCustomResponse("Interations save in Json with success");
        }
    }
}
