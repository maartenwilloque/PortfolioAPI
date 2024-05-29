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
    public class GetPTag
    {

        private readonly PortfolioContext _context;

        public GetPTag(PortfolioContext context)
        {
            _context = context;
        }
        [FunctionName("GetPTag")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "ptag")] HttpRequest req,
            ILogger log)
        {
            var ptags = await _context.Ptags.ToListAsync();
            return new OkObjectResult(ptags);
        }
    }
}
