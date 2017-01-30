using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Scratch.Models;
using Microsoft.Extensions.Options;
using System.IO;
using System.Collections;
using Microsoft.AspNetCore.Server.Kestrel.Internal.Networking;
using static Scratch.Controllers.ComicalController;

namespace Scratch.Controllers
{
    //[Route("api/email")]
    //[Produces("application/json")]
    public class ComicalController : Controller
    {
        string connection = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ComicDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        private ScratchDbContext context;

        public ComicalController(ScratchDbContext context)
        {
            this.context = context;
        }





        [HttpGet("api/Dork/{DorkID}")]
        public IActionResult Get(int DorkID)

        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (context == null)
            {
                return NotFound();
            }
            //Dork dork = context.Dorks.FirstOrDefault(m => m.DorkID == DorkID)
            var dorks = context.Dorks.Where(m => m.DorkID == DorkID);

            var comics = context.Comics.Where(m => m.DorkID == DorkID);

            IEnumerable dork = from d in dorks
                               join c in comics
                               on d.DorkID equals c.DorkID
                               where d.DorkID == c.DorkID
                               select new metaDork
                               {
                                   FirstName = d.FirstName,
                                   LastName=d.LastName,
                                   Character = c.Character,
                                   Issue= c.Issue

                               };
            foreach (metaDork m in dork)
            {
                Post(m);
            }
            return Ok(dork);


        }



        public async Task<Uri> Post(metaDork body)
        {
            HttpClient client = new HttpClient();
            //new Uri needs to be the base address for the service attempting to be called.
            client.BaseAddress = new Uri("");

            //clears headers
            client.DefaultRequestHeaders.Accept.Clear();

            //makes sure that the headers will except json format.
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));


            //change the path of Api to where you want the external service to be called
            string pathOfApi = " ";
            HttpResponseMessage response = await client.PostAsJsonAsync(pathOfApi, body);
            response.EnsureSuccessStatusCode();

            return response.Headers.Location;
        }
    }
}


