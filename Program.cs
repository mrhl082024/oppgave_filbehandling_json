namespace oppgave_filbehandling_json;

class Program
{
    static void Main(string[] args)
    {
        string path = "whatIsThis.json";
        if (!File.Exists(path))
        {
            File.CreateText(path);
        }

    }
}
