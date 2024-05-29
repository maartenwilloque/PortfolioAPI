using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;

namespace portfolioapi.Functions
{
    public class GetLanguage
    {

        private readonly PortfolioContext _context;

        public GetLanguage(PortfolioContext context)
        {
            _context = context;
        }
        [FunctionName("GetLanguage")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "language")] HttpRequest req,
            ILogger log)
        {
            var languages = await _context.Languages.ToListAsync();
            return new OkObjectResult(languages);
        }
    }
}
