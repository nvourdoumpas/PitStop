using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PitStop.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace PitStop.Core
{
    public static class PrepDb
    {
        #region public static void PrepPopulation(IApplicationBuilder app, bool isProd)
        public static void PrepPopulation(IApplicationBuilder app, bool isProd)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>(), isProd);
            }
        }
        #endregion
        #region private static void SeedData(AppDbContext? context, bool isProd)
        private static void SeedData(AppDbContext? context, bool isProd)
        {
            if (context != null && !isProd)
            {
                SeedCustomerData(context);
                context.SaveChanges();
            }
        }
        #endregion

        // Helper functions
        #region private static void SeedCustomerData(AppDbContext context)
        private static void SeedCustomerData(AppDbContext context)
        {
            string[] names = { "ΑΛΕΞΑΝΔΡΟΣ", "c", "ΚΩΝΣΤΑΝΤΙΝΟΣ", "ΓΙΩΡΓΟΣ", "ΠΑΝΑΓΙΩΤΗΣ", "ΝΙΚΟΛΑΟΣ", "ΙΩΑΝΝΗΣ", "ΒΑΣΙΛΗΣ", "ΧΡΗΣΤΟΣ", "ΣΤΑΥΡΟΣ" };
            string[] lastnames = { "ΠΑΠΑΔΟΠΟΥΛΟΣ", "ΠΑΠΠΑΣ", "ΚΑΡΑΓΙΑΝΝΗΣ", "ΒΛΑΧΟΣ", "ΙΩΑΝΝΙΔΗΣ", "ΟΙΚΟΝΟΜΟΥ", "ΠΑΠΑΓΕΩΡΓΙΟΥ", "ΜΑΚΡΗΣ", "ΚΩΝΣΤΑΝΤΙΝΙΔΗΣ", "ΔΗΜΟΠΟΥΛΟΣ" };
            string[] addresses = { "Λ. ΚΗΦΙΣΙΑΣ", "Λ. ΑΘΗΝΩΝ", "Λ. ΜΕΣΟΓΕΙΩΝ", "Λ. ΒΟΥΛΙΑΓΜΕΝΗΣ", "Λ. ΣΥΓΓΡΟΥ", "Λ. ΚΑΤΕΧΑΚΗ", "Λ. ΚΗΦΙΣΟΥ", "Λ. ΠΟΣΕΙΔΩΝΟΣ", "Λ. ΒΑΣΙΛΙΣΣΗΣ ΣΟΦΙΑΣ", "Λ. ΑΛΕΞΑΝΔΡΑΣ" };


            if (!context.Customers.Any())
            {
                Console.WriteLine("--> Seeding Customer Data...");

                Customer customer;
                Random random;
                for (int i = 0; i <= 50; i++)
                {
                    customer = new Customer();
                    random = new Random();

                    customer.CusTypeId = Convert.ToInt16(random.Next(1, 2)); // 1 or 2
                    customer.Name = names[random.Next(0, names.Length)]; // ΠΑΝΑΓΙΩΤΗΣ
                    customer.Lastname = lastnames[random.Next(0, lastnames.Length)]; // ΚΩΝΣΤΑΝΤΙΝΙΔΗΣ
                    customer.Address = $"{addresses[random.Next(0, lastnames.Length)]} {random.Next(1, 300)}"; // Λ. ΚΑΤΕΧΑΚΗ 32
                    customer.City = "ΑΘΗΝΑ";
                    customer.State = "ATTIKH";
                    customer.Telephone = "216" + random.Next(1000000, 9999999); // 2161234567
                    customer.Mobile = "696" + random.Next(1000000, 9999999); // 6961234567
                    customer.Email = $"{ConvertToGreeklish(customer.Name.Substring(0, 1).ToLower())}.{ConvertToGreeklish(customer.Lastname.ToLower())}@mail.com"; // p.konstantinidis@mail.com

                    context.Customers.Add(customer);
                }
            }
            else
            {
                Console.WriteLine("--> We already have customer data");
            }
        }
        #endregion
        #region public static string ConvertToGreeklish(string greekText)
        public static string ConvertToGreeklish(string greekText)
        {
            var result = new StringBuilder();

            foreach (char c in greekText)
            {
                if (GreekToGreeklishMap.TryGetValue(c, out string? greeklishChar))
                    result.Append(greeklishChar);
                else
                    result.Append(c); // Keep non-Greek characters as-is
            }

            return result.ToString();
        }
        #endregion

        // Helper map
        #region private static readonly Dictionary<char, string> GreekToGreeklishMap = new Dictionary<char, string>
        private static readonly Dictionary<char, string> GreekToGreeklishMap = new Dictionary<char, string>
        {
            { 'α', "a" }, { 'β', "v" }, { 'γ', "g" }, { 'δ', "d" }, { 'ε', "e" },
            { 'ζ', "z" }, { 'η', "i" }, { 'θ', "th" }, { 'ι', "i" }, { 'κ', "k" },
            { 'λ', "l" }, { 'μ', "m" }, { 'ν', "n" }, { 'ξ', "x" }, { 'ο', "o" },
            { 'π', "p" }, { 'ρ', "r" }, { 'σ', "s" }, { 'ς', "s" }, { 'τ', "t" },
            { 'υ', "y" }, { 'φ', "f" }, { 'χ', "x" }, { 'ψ', "ps" }, { 'ω', "o" },
            { 'Α', "A" }, { 'Β', "V" }, { 'Γ', "G" }, { 'Δ', "D" }, { 'Ε', "E" },
            { 'Ζ', "Z" }, { 'Η', "I" }, { 'Θ', "TH" }, { 'Ι', "I" }, { 'Κ', "K" },
            { 'Λ', "L" }, { 'Μ', "M" }, { 'Ν', "N" }, { 'Ξ', "X" }, { 'Ο', "O" },
            { 'Π', "P" }, { 'Ρ', "R" }, { 'Σ', "S" }, { 'Τ', "T" }, { 'Υ', "Y" },
            { 'Φ', "F" }, { 'Χ', "X" }, { 'Ψ', "PS" }, { 'Ω', "O" }
        };
        #endregion
    }
}
