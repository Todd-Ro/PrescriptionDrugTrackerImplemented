using Microsoft.AspNetCore.Mvc;
using PrescriptionDrugTracker.Models;
using System.Collections.Generic;

namespace PrescriptionDrugTracker.Controllers
{
    public class PrescriptionController : Controller
    {
        List<Prescription> AllDrugs;

        public IActionResult Index()
        {
            if(AllDrugs is null)
            {
                GenerateAllDrugs();
            }
            ViewBag.druglist = AllDrugs;
            return View();
        }

        [HttpGet]
        public IActionResult SelectMeds()
        {
            if (AllDrugs is null)
            {
                GenerateAllDrugs();
            }
            ViewBag.druglist = AllDrugs;
            return View();
        }

        static List<Prescription> SelectedDrugs = new List<Prescription>();

        [HttpPost]
        public IActionResult MySelected(string drugname)
        {
            Prescription SelectedDrug = new Prescription(drugname,
                Prescription.GetDrugLibrary()[drugname]);
            if(!(SelectedDrugs.Contains(SelectedDrug)))
            {
                SelectedDrugs.Add(SelectedDrug);
            }
            ViewBag.mydruglist = SelectedDrugs;
            return View();
        }

        List<Prescription> GenerateAllDrugs()
        {
            Dictionary<string, int> DrugsDict = Prescription.GetDrugLibrary();
            List<Prescription> ret = new List<Prescription>();
            foreach(string s in DrugsDict.Keys)
            {
                ret.Add(new Prescription(s, DrugsDict[s]));
            }
            AllDrugs = ret;
            return ret;
        }

    }
}
