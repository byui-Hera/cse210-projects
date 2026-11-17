class Program
{
    public static void DisplayPersonInformation(Person person)
    {
        Console.WriteLine(person.GetPersonInformation());
    }

    public static void Main()
    {
        Person myPerson = new("Hera", "Hysi", 20, 144.02);

        Doctor myDoctor = new("Dorjan", "Hysi", 49, 170.02, "Periodontal probe");

        Police myPolice = new("Gary", "Goodman", 61, 180.0, "gun");

        System.Collections.Generic.List<Person> myPeople = new()
        {
            myPerson,
            myDoctor,
            myPolice
        };

        foreach (Person person in myPeople)
        {
            DisplayPersonInformation(person);
        }
    }

    public class Person
    {
        private readonly string _firstName;
        private readonly string _lastName;
        private readonly int _age;
        private readonly double _weight;

        public Person(string firstName, string lastName, int age, double weight)
        {
            _firstName = firstName;
            _lastName = lastName;
            _age = age;
            _weight = weight;
        }

        public virtual string GetPersonInformation()
        {
            return $"{_firstName} {_lastName} is {_age} years old and weighs {_weight}";
        }
    }

    public class Doctor : Person
    {
        private readonly string _tools;

        public Doctor(string firstName, string lastName, int age, double weight, string tools)
            : base(firstName, lastName, age, weight)
        {
            _tools = tools;
        }

        public override string GetPersonInformation()
        {
            return $"{_tools} : {base.GetPersonInformation()}";
        }
    }

    public class Police : Person
    {
        private readonly string _weapons;

        public Police(string firstName, string lastName, int age, double weight, string weapons)
            : base(firstName, lastName, age, weight)
        {
            _weapons = weapons;
        }

        public override string GetPersonInformation()
        {
            return $"Police: Weapons: {_weapons} : {base.GetPersonInformation()}";
        }
    }
}