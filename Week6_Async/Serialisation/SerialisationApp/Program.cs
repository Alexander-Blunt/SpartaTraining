namespace SerialisationApp;

internal class Program
{
    private static readonly string _path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
    private static ISerialise _serialiser;
    static void Main(string[] args)
    {
        _serialiser = new XMLSerialiser();
        WriteJoe();
    }

    static void CreateJoe()
    {
        Trainee joseph = new Trainee() { FirstName = "Joseph", LastName = "McCann", SpartaNo = 7 };

        _serialiser.SerialiseToFile<Trainee>($"{_path}/SpartaDocs/XMLJoe.xml", joseph);
    }

    static void WriteJoe()
    {
        Trainee joseph = _serialiser.DeserialiseFromFile<Trainee>($"{_path}/SpartaDocs/XMLJoe.xml");

        Console.WriteLine(joseph);
    }
}