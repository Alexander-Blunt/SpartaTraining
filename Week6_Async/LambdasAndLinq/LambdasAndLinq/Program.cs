namespace LambdasAndLinq;

internal class Program
{
    static void Main(string[] args)
    {
        // Language Integrated Queries
        var nums = new List<int> { 3, 7, 1, 2, 8, 3, 0, 4, 5 };

        var numsCount = nums.Count();

        int countEven = nums.Count(IsEven);

        List<Person> people = new List<Person> {
            new Person { Name = "Cathy", Age = 40, City = "Ottawa"},
            new Person { Name = "Nish", Age = 55,City = "Birmingham"},
            new Person { Name = "Martin", Age = 20, City = "London"}
        };

        int countYoungPeople = people.Count(IsYoung);

        // Anonymous method using delegates (obsolete)
        int countDEven = nums.Count(
            delegate (int num)
            {
                // Return type is inferred.
                return num % 2 == 0;
            });

        // Lambda expressions
        // given something => return something
        int sumOfSquares = nums.Sum(x => x * x);

        int countLEven = nums.Count(n => n % 2 == 0);


        // In order to execute a LINQ query you must have a queryable object, then
        // define a query and finally execute the query by iterating through it
        var peopleInLondonQuery = people.Where(p => p.City == "London");
        var peopleInLondon = peopleInLondonQuery.ToList();

        var peopleByAge = people.OrderBy(p => p.Age);

        foreach (var person in peopleByAge)
        {
            Console.WriteLine(person);
        }

        var namesOfThoseOver20 = people.Where(p => p.Age > 20).Select(p => p.Name).ToList();

        string newString = ModifyString("Hello World", s => s.Replace(" ", "_").ToUpper());
    }

    private static string ModifyString(string str, Func<string, string> strModify)
    {
        return strModify(str);
    }

    // Can create our own method to count evens.
    private static void CountEvens(List<int> nums)
    {
        int countEven = 0;
        foreach (int num in nums)
        {
            if (IsEven(num)) countEven++;
        }
    }

    private static bool IsYoung(Person p)
    {
        return p.Age < 30;
    }

    private static bool IsEven(int num)
    {
        return num % 2 == 0;
    }
}