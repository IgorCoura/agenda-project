using System.Text;
using Agenda.Application.Constants;
using Agenda.Application.Interfaces;
using Agenda.Infrastructure.Storage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace Agenda.API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/Interaction")]
    [Authorize(Roles = Roles.Admin)]
    public class InteractionController : MainController
    {
        private readonly IInteractionService _interactionService;
        private readonly JsonStorageOptions _jsonStorageOptions;


        public InteractionController(IInteractionService interactionService, IOptions<JsonStorageOptions> options)
        {
            _interactionService = interactionService;
            _jsonStorageOptions = options.Value;
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

        [AllowAnonymous]
        [HttpGet("download")]
        public async Task<ActionResult> DownloadFile()
        {
            await _interactionService.SaveJsonInteractionsAsync();

            var filePath = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + _jsonStorageOptions.FilePath;

            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(filePath, out var contentType))
            {
                contentType = "application/octet-stream";
            }

            var bytes = await System.IO.File.ReadAllBytesAsync(filePath);
            return File(bytes, contentType, Path.GetFileName(filePath));
        }

    }
}
