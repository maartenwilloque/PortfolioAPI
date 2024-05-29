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
    public class GetKnowlegde
    {

        private readonly PortfolioContext _context;

        public GetKnowlegde(PortfolioContext context)
        {
            _context = context;
        }
        [FunctionName("GetKnowlegde")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "knowledge")] HttpRequest req,
            ILogger log)
        {
            var knowledges = await _context.Knowledges.ToListAsync();
            return new OkObjectResult(knowledges);
        }
    }
}
