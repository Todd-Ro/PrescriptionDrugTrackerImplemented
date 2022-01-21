using System;
using System.Collections.Generic;

namespace PrescriptionDrugTracker.Models
{
    public class Prescription
    {
        static Dictionary<string, int> DrugLibrary =
            new Dictionary<string, int>()
            {
                {"Amoxicillin", 1 },
                {"Penicillin", 1 },
                {"Econazole", 3 },
                {"Clonidine", 1 },
                {"Azithromycin", 1 },
                {"Lisinopril", 1 },
                {"Propranolol", 1 },
                {"Lovastatin", 1 },
                {"Niacin", 3 },
                {"Omega-3", 3 },
                {"Provastatin", 1 }
            };

        public string DrugName { get; set; }
        public int Tier {get; set;}
        int Id;
        static int NextId = 0;

        static public Dictionary<string, int> GetDrugLibrary()
        {
            return DrugLibrary;
        }

        public Prescription(string drugName, int tier)
        {
            DrugName = drugName;
            Tier = tier;
            Id = NextId;
            NextId++;
        }

        public override bool Equals(object obj)
        {
            return obj is Prescription prescription &&
                    DrugName == prescription.DrugName;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(DrugName);
        }

        


    }
}
