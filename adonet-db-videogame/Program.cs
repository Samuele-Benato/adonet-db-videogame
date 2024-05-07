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

            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    InsertVideogame();
                    break;
                case 2:
                    GetVideogameById();
                    break;
                case 3:
                    GetVideogameByInput();
                    break;
                case 4:
                    DeleteVideogame();
                    break;
                case 5:
                    Console.WriteLine("Programma chiuso.");
                    break;
                default:
                    Console.WriteLine("Scelta non valida.");
                    break;
            }

            static void InsertVideogame()
            {

                Console.Write("1. inserisci il nome : ");
                string name = Console.ReadLine();

                Console.Write("2. inserisci la trama : ");
                string overview = Console.ReadLine();

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
            }

            static void GetVideogameById()
            {  
                Console.WriteLine("Inserisci l'ID del videogioco:");
                int id = Convert.ToInt32(Console.ReadLine());
                VideogameManagement.GetVideogameById(id);
            }

            static void GetVideogameByInput()
            {
                Console.WriteLine("Inserisci parola chiave:");
                string input = Console.ReadLine();
                VideogameManagement.GetVideogameByInput(input);
            }

            static void DeleteVideogame()
            {
                Console.WriteLine("Inserisci il nome del videogioco per confermare l'eliminazione");
                string name = Console.ReadLine() ;
                VideogameManagement.DeleteVideogame(name);
            }
        }
    }
}
