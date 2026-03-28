public class PersonQueue
{
    private readonly List<Person> _queue = new();

    public int Length => _queue.Count;

    /// <summary>
    /// Add a person to the BACK of the queue (FIFO)
    /// </summary>
    public void Enqueue(Person person)
    {
        // Use Add to put the person at the end of the list
        _queue.Add(person); 
    }

    /// <summary>
    /// Remove a person from the FRONT of the queue
    /// </summary>
    public Person Dequeue()
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException("Queue is empty.");
        }

        // Get the person at the front (index 0)
        var person = _queue[0];
        // Remove them from the front
        _queue.RemoveAt(0);
        
        return person;
    }

    public bool IsEmpty()
    {
        return Length == 0;
    }

    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}