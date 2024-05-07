namespace adonet_db_videogame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Scegli un'opzione:");
            Console.WriteLine("1. Inserisci un videogioco");
            Console.WriteLine("2. Ricerca un videogioco per ID");
            Console.WriteLine("3. Ricerca un videogioco per parola");
            Console.WriteLine("4. Elimina un videogioco");
            Console.WriteLine("5. Esci");

            string choice = Console.ReadLine();

            switch (choice)
            {

                case "1":
                    InsertVideogame();
                    break;
                case "2":
                    GetVideogameById();
                    break;
                case "3":
                    GetVideogameByInput();
                    break;
                case "4":
                    DeleteVideogame();
                    break;
                case "5":
                    Console.WriteLine("Programma chiuso.");
                    break;
                default:
                    Console.WriteLine("Scelta non valida.");
                    break;
            }

            static void InsertVideogame()
            {
                try
                {
                    Console.Write("1. inserisci il nome : ");
                    string name = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(name))
                    {
                        throw new ArgumentException("Il nome non può essere vuoto.");
                    }

                    Console.Write("2. inserisci la trama : ");
                    string overview = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(overview))
                    {
                        throw new ArgumentException("la descrizione non può essere vuota.");
                    }

                    Console.WriteLine($"3. inserisci la data di rilascio (formato YYYY-MM-DD) : ");
                    DateTime releaseDate;
                    while (!DateTime.TryParse(Console.ReadLine(), out releaseDate))
                    {
                        Console.WriteLine("Data non valida, riprova.");
                        Console.WriteLine("Scrivi una data (formato YYYY-MM-DD)");
                    }

                    DateTime createdAt = DateTime.Now;
                    DateTime updatedAt = DateTime.Now;
                    int softwarehouseid = 1;

                    VideogameManagement.InsertVideogame(name, overview, releaseDate, createdAt, updatedAt, softwarehouseid);
                    Console.WriteLine("Aggiunta avvenuta con successo!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
               
            }

            static void GetVideogameById()
            {
                try
                {
                    Console.Write("Inserisci l'ID del videogioco:");
                    string input = Console.ReadLine();
                    if (!int.TryParse(input, out int id))
                    {
                        throw new FormatException("L'ID deve essere un numero intero.");
                    }
                    VideogameManagement.GetVideogameById(id);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
            }

            static void GetVideogameByInput()
            {
                try
                {
                    Console.Write("Inserisci parola chiave:");
                    string input = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(input))
                    {
                        throw new ArgumentException("la descrizione non può essere vuota.");
                    }
                    VideogameManagement.GetVideogameByInput(input);
                }
                catch(FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            static void DeleteVideogame()
            {
                try
                {
                    Console.WriteLine("Inserisci il nome del videogioco per confermare l'eliminazione");
                    string name = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(name))
                    {
                        throw new ArgumentException("la descrizione non può essere vuota.");
                    }
                    VideogameManagement.DeleteVideogame(name);
                    Console.WriteLine("Eliminazione avvenuta con successo!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
