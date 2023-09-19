using System.Collections.Concurrent;

namespace HomeWorkLibrarian;

public class Librarian
{
    private readonly ConcurrentDictionary<string, int> _library;

    public Librarian(ConcurrentDictionary<string, int> library)
    {
        _library = library ?? throw new ArgumentNullException(nameof(library));
    }

    public void AddBook(string bookName)
    {
        if (!_library.ContainsKey(bookName))
        {
            _library.TryAdd(bookName, 0);
        }
    }

    public void ShowBookList()
    {
        foreach (var bookPair in _library)
        {
            Console.WriteLine($"{bookPair.Key} - {bookPair.Value}%");
        }
    }

    public void Read()
    {
        if (_library.IsEmpty)
        {
            return;
        }
        foreach (var bookPair in _library)
        {
            if (bookPair.Value < 100)
            {
                _library.TryUpdate(bookPair.Key, bookPair.Value + 1, bookPair.Value);
            }
            else
            {
                _library.TryRemove(bookPair);
            }
        }
        Thread.Sleep(1000);
    }
}