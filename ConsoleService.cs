namespace HomeWorkLibrarian;

public class ConsoleService
{
    private readonly Librarian _librarian;

    public ConsoleService(Librarian librarian)
    {
        _librarian = librarian ?? throw new ArgumentNullException(nameof(librarian));
    }
    private static void PrintMainMenu()
    {
        Console.WriteLine("Меню:");
        Console.WriteLine("1 - Добавить книгу.");
        Console.WriteLine("2 - вывести список непрочитанного.");
        Console.WriteLine("3 - выйти");
    }
    public void StartListening()
    {
        while (true)
        {
            PrintMainMenu();
            MenuStates input;
            var isInt = int.TryParse(Console.ReadLine(), out int state);
            if (isInt)
            {
                input = (MenuStates)state;
            }
            else
            {
                input = MenuStates.None;
            }
            switch (input)
            {
                case MenuStates.None:
                    Console.WriteLine("Введено не число, попробуйте снова");
                    break;
                case MenuStates.AddBook:
                    Console.WriteLine("Введите название книги:");
                    _librarian.AddBook(Console.ReadLine());
                    break;
                case MenuStates.ShowList:
                    _librarian.ShowBookList();
                    break;
                case MenuStates.Exit:
                    return;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}