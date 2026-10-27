using System;

class Program
{
    public static void Main()
    {
        Person myPerson = new Person("Hera", "Hysi", 20, 144.02);
        Console.WriteLine(myPerson.GetPersonInformation());

        Doctor myDoctor = new Doctor("Dorjan", "Hysi", 49, 170.02, "Periodontal probe");
        Console.WriteLine(myDoctor.GetDoctorInformation());

        Police police = new Police("Andi", "Hysi", 20, 102.02, "Knife");
        Console.WriteLine(police.GetPoliceInformation());
    }
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
    private string _tools;
    public Police(string firstName, string lastName, int age, double weight, string tools) : base(firstName, lastName, age, weight)
    {
        _tools = tools;
    }


    public string GetPoliceInformation()
    {
        return $"{_tools}: {GetPersonInformation()}";
    }
}