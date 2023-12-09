namespace MementoDesignPattern_Task;

public class Originator
{
    private string state;

    public string State
    {
        get { return state; }
        set
        {
            Console.WriteLine($"Originator: Set state to {value}");
            state = value;
        }
    }

    public Memento CreateMemento()
    {
        Console.WriteLine("Originator: Creating Memento");
        return new Memento(state);
    }

    public void RestoreMemento(Memento memento)
    {
        state = memento.State;
        Console.WriteLine($"Originator: Restoring state to {state}");
    }
}

public class Memento
{
    public string State { get; private set; }

    public Memento(string state)
    {
        State = state;
    }
}

public class Caretaker
{
    public Memento Memento { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        Originator originator = new Originator();

        originator.State = "State 1";
        Caretaker caretaker = new Caretaker();
        caretaker.Memento = originator.CreateMemento();

        originator.State = "State 2";

        originator.RestoreMemento(caretaker.Memento);

    }
}
