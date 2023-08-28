namespace Livraria.Shared.Presenters;

public class Presenter<T>
{
    public T? Data { get;  private set; }
    public List<string> Errors { get; private set; } = new();

    public Presenter(T data, List<string> errors)
    {
        Data = data;
        Errors = errors;
    }

    public Presenter(T data)
    {
        Data = data;
    }

    public Presenter(List<string> errors) => Errors = errors;

    public Presenter(string error) => Errors.Add(error);

    public string ErrorsToString() => Errors.Aggregate("", (current, error) => current + $"{error}\n");
   
}

