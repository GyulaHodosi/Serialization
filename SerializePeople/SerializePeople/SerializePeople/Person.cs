using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerializePeople
{
    enum Genders { Male, Female}
    class Person
    {
        string Name { get; set; }
        DateTime BirthDate { get; set; }
        Genders Gender { get; set; }
        int Age { get; set; }

        public Person(string name, DateTime birthDate, Genders gender)
        {
            Name = name;
            BirthDate = birthDate;
            Gender = gender;
            int now = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
            int dob = int.Parse(birthDate.ToString("yyyyMMdd"));
            Age = (now - dob) / 10000;
        }

        public override string ToString()
        {
            return $"Name: {Name}\nGender: {Gender}\nBirthDate: {BirthDate}\nAge: {Age}";
        }
    }
}
