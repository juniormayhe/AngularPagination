using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AngularPagination.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace AngularPagination.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailingController : ControllerBase
    {
        private readonly IMailingRepository repo;

        public MailingController(IMailingRepository repo)
        {
            this.repo = repo;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<PagedList<Recipient>> Get([FromQuery] RecipientParams recipientParams)
        {
            return repo.GetUsers(recipientParams);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
