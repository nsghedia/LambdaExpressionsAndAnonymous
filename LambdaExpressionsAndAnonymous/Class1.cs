namespace LambdaExpressionsAndAnonymous
{
    public class Person
    {
        public string? Name { get; set; }
        public int Age { get; set; }
    }
    public class Class1
    {
        public delegate bool PersonDelegate(Person person);
        public static void FilterPeopleBaseOnAge()
        {
            Person person1 = new Person() { Name = "Neha", Age = 23 };
            Person person2 = new Person() { Name = "Megha", Age = 33 };
            Person person3 = new Person() { Name = "Sneha", Age = 73 };
            Person person4 = new Person() { Name = "Virat", Age = 19 };

            List<Person> personList = new List<Person>() { person1, person2, person3, person4 };

            DisplayPerson("Kids", personList, IsMinors);
            DisplayPerson("Adults", personList, IsAdult);
            DisplayPerson("Senoirs", personList, IsSenior);

        }

        static void DisplayPerson(string Title, List<Person> people, PersonDelegate personDelegateFilter)
        {
            if (people != null && people.Count > 0)
            {
                Console.WriteLine("\n" + Title + "\n");
                foreach (var item in people)
                {
                    if (personDelegateFilter(item))
                        Console.WriteLine($"{item.Name}'s age is {item.Age}");
                }
            }
        }

        static bool IsMinors(Person person)
        {
            return person.Age < 18;
        }

        static bool IsAdult(Person person)
        {
            return person.Age >= 18;
        }
        static bool IsSenior(Person person)
        {
            return person.Age >= 65;
        }

        public static void PredicareDelegate()
        {
            List<string> List = new List<string>() { "Neha", "Suresh", "Priyanka", "Chandrika", "Piyush" };

            foreach (var item in List)
                Console.WriteLine(item);

            Console.WriteLine("\nAfter removing string which contain 'e' character...\n");

            List.RemoveAll(x => x.Contains("e"));

            foreach (var item in List)
                Console.WriteLine(item);
        }

    }
}
