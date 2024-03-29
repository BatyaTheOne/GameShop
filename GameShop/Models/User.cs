﻿using System.Diagnostics.Eventing.Reader;
using System.Net.Cache;

namespace GameShop.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Age => CalculateAge();
        public string Loggin { get ; set; }
        public string Password { get; set; }
        public double? Score { get; set; } = 0;

        public bool IsAdmin { get; set; }

        private int CalculateAge()
        {
            DateTime today = DateTime.Today;

            int age = today.Year - DateOfBirth.Year;

            if (DateOfBirth > today.AddYears(-age))
                age--;

            return age;
        }
    }
}
