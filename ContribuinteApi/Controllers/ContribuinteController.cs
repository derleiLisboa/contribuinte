using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContribuinteApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace ContribuinteApi.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ContribuinteController : Controller {

        private readonly ApplicationDbContext _context;

        public ContribuinteController(ApplicationDbContext context) {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Contribuinte>> Get() {
            return _context.Contribuintes.ToList();
        }

        [HttpGet("{id}", Name = "GetContribuinte")]
        public ActionResult<Contribuinte> GetById(long id) {
            var contribuinte = _context.Contribuintes.Find(id);

            if (contribuinte == null)
                return NotFound();

            return contribuinte;
        }

        [HttpGet("ir_calculado/{salarioMinimo}")]
        public ActionResult<List<Contribuinte>> GetContribuintesIRCalculado(decimal salarioMinimo) {

            List<Contribuinte> contribuintes = _context.Contribuintes.ToList();

            foreach (Contribuinte contribuinte in contribuintes) {
                contribuinte.CalcularIR(salarioMinimo);
            }

            return contribuintes;
        }

        // POST api/<controller>
        [HttpPost]
        public IActionResult Create([FromBody]Contribuinte contribuinte) {

            _context.Contribuintes.Add(contribuinte);
            _context.SaveChanges();

            return CreatedAtRoute("GetContribuinte", new { id = contribuinte.Id }, contribuinte);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value) {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id) {
        }
    }
}
