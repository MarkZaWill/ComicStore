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

            if (context == null){
                return NotFound();
            }
            Dork dork = context.Dorks.FirstOrDefault(m => m.DorkID == DorkID);
            string newDork = dork.ToString();
            Post(newDork);
            //IQueryable Query = from d in context.Dorks
            //                   join c in context.Comics
            //            on d.DorkID equals c.DorkID
            //                   select new
            //                   {
            //                       d.FirstName,
            //                       d.LastName,
            //                       c.Character,
            //                       c.Issue        
            //                       //shipDate,
            //                       //TrackingNumber
            //                   };
            return Ok(dork);


        }

        [HttpPost]
        //public IActionResult POST(int DorkID)
        //{ 

        public async Task<IEnumerable<string>> Post(string dork)
        {
            var result = await GetExternalResponse();
            return  new string[] { result, dork };
        }

        static string _address = "http://abn-nws-ftp.studio.internal.com:8080/swagger-ui.html";
        private async Task<string> GetExternalResponse()
        {
            var client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(_address);
            var result = await response.Content.ReadAsStringAsync();
            return result;
        }
    

            }

            }


