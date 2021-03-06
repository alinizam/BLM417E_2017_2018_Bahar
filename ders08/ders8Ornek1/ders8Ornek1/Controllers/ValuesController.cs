﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ders8Ornek1.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace ders8Ornek1.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private personelDBContext _context;
        // GET api/values
        public ValuesController(personelDBContext dbcontext) {
            _context = dbcontext;
        }

        [HttpGet]
        public IEnumerable<Personel> Get(string filtre)
        {
            IEnumerable<Personel> personels=null;
            if (string.IsNullOrEmpty(filtre)) {
                personels = _context.Personel;
            }
            else {
                personels = _context.Personel.Where(p => p.Adi.Contains(filtre)).ToList();
            }
            return personels;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Personel Get(int id)
        {
            var personel = _context.Personel.Find(id);
            return personel;
        }

        // POST api/values
        /* [HttpPost]
         public ActionResult Post([FromQuery(Name="id")]int id, 
                               [FromQuery(Name = "adi")]string adi,
                               [FromQuery(Name = "soyadi")]string soyadi)
         {
             Personel p = new Personel();
             p.PId = id;
             p.Adi = adi;
             p.Soyadi = soyadi;
             _context.Personel.Add(p);
             _context.SaveChanges();
             return Ok();
         }*/

        [HttpPost] 
        public async Task<ActionResult> Post([FromBody]Personel p)
        {
            Console.WriteLine(p);
            _context.Personel.Add(p);
            await _context.SaveChangesAsync();
            return Ok();
        }


        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
