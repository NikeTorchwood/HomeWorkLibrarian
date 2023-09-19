namespace HomeWorkLibrarian;

public class ReadingService
{
    private readonly Librarian _librarian;

    public ReadingService(Librarian librarian)
    {
        _librarian = librarian ?? throw new ArgumentNullException(nameof(librarian));
    }

    public void StartReading()
    {
        _librarian.Read();
    }
}