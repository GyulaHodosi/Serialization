using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SerializePeople
{
    enum Genders { Male, Female}

    [Serializable]
    class Person : ISerializable, IDeserializationCallback
    {
        string Name { get; set; }
        DateTime BirthDate { get; set; }
        Genders Gender { get; set; }
        [NonSerialized]
        private int age;
        int Age { get { return age; } set { age = value; } }

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

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Name", Name);
            info.AddValue("BirthDate", BirthDate);
            info.AddValue("Gender", Gender);
            info.AddValue("Age", Age);
        }

        public Person(SerializationInfo info, StreamingContext context)
        {
            Name = (string)info.GetValue("Name", typeof(string));
            BirthDate = (DateTime)info.GetValue("BirthDate", typeof(DateTime));
            Gender = (Genders)info.GetValue("Gender", typeof(Genders));
        }

        public void Serialize(string output)
        {
            Stream stream = File.Open(output, FileMode.Create);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            binaryFormatter.Serialize(stream, this);
            stream.Close();
        }

        public static Person Deserialize(string input)
        {
            Stream stream = File.Open(input, FileMode.Open);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            Person person = (Person)binaryFormatter.Deserialize(stream);
            stream.Close();

            return person;
        }

        public void OnDeserialization(object sender)
        {
            int now = int.Parse(DateTime.Now.ToString("yyyyMMdd"));
            int dob = int.Parse(BirthDate.ToString("yyyyMMdd"));
            Age = (now - dob) / 10000;
        }
    }
}
