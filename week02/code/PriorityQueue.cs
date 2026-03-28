public class PriorityQueue
{
    private List<PriorityItem> _queue = new();

    public void Enqueue(string value, int priority)
    {
        var newNode = new PriorityItem(value, priority);
        _queue.Add(newNode);
    }

    public string Dequeue()
    {
        if (_queue.Count == 0)
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        // BUG FIX 1 & 2: Search the entire list and keep the FIRST high priority item found
        var highPriorityIndex = 0;
        for (int index = 1; index < _queue.Count; index++) // Corrected loop limit
        {
            // Use '>' instead of '>=' to ensure FIFO for same priorities
            if (_queue[index].Priority > _queue[highPriorityIndex].Priority)
            {
                highPriorityIndex = index;
            }
        }

        // BUG FIX 3: Actually remove the item from the list before returning
        var value = _queue[highPriorityIndex].Value;
        _queue.RemoveAt(highPriorityIndex); 
        
        return value;
    }

    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}