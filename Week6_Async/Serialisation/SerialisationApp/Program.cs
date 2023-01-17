namespace SerialisationApp;

internal class Program
{
    private static readonly string _path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    private static ISerialise _serialiser;
    static void Main(string[] args)
    {
        _serialiser = new XMLSerialiser();
        Trainee joseph = new Trainee() { FirstName = "Joseph", LastName = "McCann", SpartaNo = 7 };
        _serialiser.SerialiseToFile<Trainee>($"{_path}/SpartaDocs/XMLJoe.xml", joseph);

        Course eng134 = new Course()
        {
            Title = "Engineering 134",
            Subject = "C# SDET",
            StartDate = new DateTime(2022, 11, 28)
        };

        eng134.AddTrainee(joseph);
        eng134.AddTrainee(new Trainee() { FirstName = "Ikra", LastName = "Dahir", SpartaNo = 10 });
        eng134.AddTrainee(new Trainee() { FirstName = "Mehdi", LastName = "Hamdi", SpartaNo = 5 });

        _serialiser.SerialiseToFile<Course>($"{_path}/SpartaDocs/Eng134.xml", eng134);

        _serialiser = new JSONSerialiser();
        _serialiser.SerialiseToFile<Course>($"{_path}/SpartaDocs/Eng134.json", eng134);
    }

    static void GetAndWriteJoe()
    {
        Trainee joseph = _serialiser.DeserialiseFromFile<Trainee>($"{_path}/SpartaDocs/XMLJoe.xml");

        Console.WriteLine(joseph);
    }
}