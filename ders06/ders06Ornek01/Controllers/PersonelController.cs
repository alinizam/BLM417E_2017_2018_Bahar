using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ders06Ornek01.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ders06Ornek01.Controllers
{
    public class PersonelController : Controller
    {
        // GET: /<controller>/
        personelDBContext _context=new personelDBContext();

        public PersonelController(){
            //personeller.Add(new Personel() { pId = 1, adi = "Ahmet", soyadi = "AK" });
            //personeller.Add(new Personel() { pId = 2, adi = "Mehmet", soyadi = "Yeşil" });
            //personeller.Add(new Personel() { pId = 3, adi = "Ayşe", soyadi = "Personel" });
        }

        public IActionResult Index()
        {
            ViewBag.adi = "Ahmet AK";
            ViewData["ad"] = "Kemal Sarı";
            Personel p = new Personel() {PId=1, Adi="Ahmet", Soyadi="AK" };
            return View(p);
        }

        List<Personel> personeller = new List<Personel>();
        /*public IActionResult Liste()
        {
            return View(personeller);
        }*/

        public IActionResult Liste(string searchString)
        {
            //List<Personel> personelTempList= personeller;
            List<Personel> personelTempList = _context.Personel.ToList();
            if (!String.IsNullOrEmpty(searchString)) {
                personelTempList = personelTempList.Where(p => p.Adi.Contains(searchString)).ToList();
            }
            return View(personelTempList);
        }

        public string IndexString()
        {
            return "FSM";
        }
    }
}
