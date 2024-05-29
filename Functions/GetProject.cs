using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using portfolioapi.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Newtonsoft.Json.Serialization;

namespace portfolioapi.Functions
{
    public class GetProject
    {

        private readonly PortfolioContext _context;

        public GetProject(PortfolioContext context)
        {
            _context = context;
        }
        [FunctionName("GetProject")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "project")] HttpRequest req,
            ILogger log)
        {
 
            var projects = await _context.Projects
                .Include(p => p.Tags)
                .ThenInclude(pt => pt.PTag)
                .ToListAsync();

            var result = projects.Select(p => new
            {
                id = p.Id,
                name = p.Name,
                developers = p.Developers,
                year = p.Year,
                summary = p.Summary,
                description = p.Description,
                projectLink = p.ProjectLink,
                pictures = p.Pictures,
                tags = p.Tags.Select(t => new
                {
                    id = t.PTag.Id,
                    key = t.PTag.Key,
                    color = t.PTag.Color,
                    icon = t.PTag.Icon,
                    type = t.PTag.Type
                }).ToList()
            });

            var jsonResult = new ContentResult
            {
                Content = JsonConvert.SerializeObject(result),
                ContentType = "application/json",
                StatusCode = 200
            };

            return jsonResult;
        }
    }
}
