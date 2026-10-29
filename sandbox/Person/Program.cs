using System;

class Program
{
    public static void Main()
    {
        Person myPerson = new Person("Hera", "Hysi", 20, 144.02);
        Console.WriteLine(myPerson.GetPersonInformation());

        Doctor myDoctor = new Doctor("Dorjan", "Hysi", 49, 170.02, "Periodontal probe");
        Console.WriteLine(myDoctor.GetPersonInformation());
        Console.WriteLine(myDoctor.GetDoctorInformation());

        Police myPolice = new Police("Gary", "Goodman", 61, 180.0, "gun");
        Console.WriteLine(myPolice.GetPersonInformation());
        Console.WriteLine(myPolice.GetPoliceInformation());



        // Method 2
        // List<Person> myPeople = new List<Person>();
        // myPeople.Add(myPerson);
        // myPeople.Add(myDoctor);
        // myPeople.Add(myPolice);


        // Method 3
        //     List<Person> myPeople = new List<Person>
        //     {
        //         new Person("Hera", "Hysi", 20, 144.02),
        //         new Doctor("Dorjan", "Hysi", 49, 170.02, "periodontal probe"),
        //         new Police("Gary", "Goodman", 61, 181, "Guns")
        //     };

        //     foreach(Person person in myPeople)
        //     {
        //         Console.WriteLine(person.GetPersonInformation());
        //     }
        // }
    }


    class Person
    {
        private string _firstName;
        private string _lastName;
        private int _age;
        private double _weight;


        public Person(string firstName, string lastName, int age, double weight)
        {
            this._firstName = firstName;
            this._lastName = lastName;
            this._age = age;
            this._weight = weight;
        }


        public string GetPersonInformation()
        {
            return $"{_firstName} {_lastName} is {_age} years old and weighs {_weight}";
        }
    }



    class Doctor : Person
    {
        private string _tools;

        public Doctor(string firstName, string lastName, int age, double weight, string tools) : base(firstName, lastName, age, weight)
        {
            _tools = tools;
        }


        public string GetDoctorInformation()
        {
            return $"{_tools} : {GetPersonInformation()}";
        }
    }


    class Police : Person
    {
        private string _weapons;

        public Police(string firstName, string lastName, int age, double weight, string weapons) : base(firstName, lastName, age, weight)
        {
            _weapons = weapons;
        }


        public string GetPoliceInformation()
        {
            return $"Police: Weapons: {_weapons} : {GetPersonInformation()}";
        }
    }
}