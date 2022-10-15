using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace baez2getmember
{
    public static class AddMember
    {
        [FunctionName("AddMember")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            string id = req.Query["id"];
            string name = req.Query["name"];
            string groupId = req.Query["groupid"];

            var isValid = !(string.IsNullOrWhiteSpace(id) ||
                string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(groupId));

            if (isValid)
            {
                var responseText = $"HTTP function recvd req with id: {id} name: {name} groupId: {groupId}";
                log.LogInformation(responseText);

                return new OkObjectResult(responseText);
            }

            var errorText = "Invalid input -please provide a valid a valid, id, name, groupId.";
            log.LogInformation(errorText);
            return new BadRequestObjectResult(errorText);
        }
    }
}
