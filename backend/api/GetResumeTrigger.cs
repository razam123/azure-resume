using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using Microsoft.Azure.Cosmos.Core;
using System.Text;

namespace Company.Function
{
    public static class GetResumeTrigger
    {
        [FunctionName("GetResumeTrigger")]
        public static  HttpResponseMessage Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            [CosmosDB(databaseName:"AzureResume",containerName:"Counter",Connection = "ÄzureResumeConnectionString",Id = "1",PartitionKey = "1")] Counter counter, 
            [CosmosDB(databaseName:"AzureResume",containerName:"Counter",Connection = "ÄzureResumeConnectionString",Id = "1",PartitionKey = "1")] out Counter Updatecounter, 
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            Updatecounter =  counter ; 
              Updatecounter.Count +=  1 ;

              var JsonToReturn = JsonConvert.SerializeObject(counter);

            return new HttpResponseMessage(System.Net.HttpStatusCode.OK) 
            {
                Content = new StringContent(JsonToReturn,Encoding.UTF8,"application/json")        
            };
        }
    }
}
