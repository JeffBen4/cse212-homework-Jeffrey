using System.Collections;

public class LinkedList : IEnumerable<int>
{
    private Node? _head;
    private Node? _tail;

    /// <summary>
    /// Insert a new node at the front (i.e. the head) of the linked list.
    /// </summary>
    public void InsertHead(int value)
    {
        Node newNode = new(value);
        if (_head is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            newNode.Next = _head; 
            _head.Prev = newNode; 
            _head = newNode; 
        }
    }

    /// <summary>
    /// Problem 1: Insert a new node at the back (i.e. the tail) of the linked list.
    /// </summary>
    public void InsertTail(int value)
    {
        Node newNode = new(value);
        // Si la lista está vacía, el nuevo nodo es tanto el head como el tail.
        if (_tail is null)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            // Conectamos el nuevo nodo después del tail actual.
            newNode.Prev = _tail;
            _tail.Next = newNode;
            // El nuevo nodo se convierte en el nuevo tail.
            _tail = newNode;
        }
    }

    /// <summary>
    /// Remove the first node (i.e. the head) of the linked list.
    /// </summary>
    public void RemoveHead()
    {
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        else if (_head is not null)
        {
            _head.Next!.Prev = null; 
            _head = _head.Next; 
        }
    }

    /// <summary>
    /// Problem 2: Remove the last node (i.e. the tail) of the linked list.
    /// </summary>
    public void RemoveTail()
    {
        // Si la lista está vacía o tiene un solo elemento.
        if (_head == _tail)
        {
            _head = null;
            _tail = null;
        }
        else if (_tail is not null)
        {
            // El penúltimo nodo ahora no tendrá nada después de él.
            _tail.Prev!.Next = null;
            // El penúltimo nodo se convierte en el nuevo tail.
            _tail = _tail.Prev;
        }
    }

    /// <summary>
    /// Insert 'newValue' after the first occurrence of 'value' in the linked list.
    /// </summary>
    public void InsertAfter(int value, int newValue)
    {
        Node? curr = _head;
        while (curr is not null)
        {
            if (curr.Data == value)
            {
                if (curr == _tail)
                {
                    InsertTail(newValue);
                }
                else
                {
                    Node newNode = new(newValue);
                    newNode.Prev = curr; 
                    newNode.Next = curr.Next; 
                    curr.Next!.Prev = newNode; 
                    curr.Next = newNode; 
                }
                return; 
            }
            curr = curr.Next; 
        }
    }

    /// <summary>
    /// Problem 3: Remove the first node that contains 'value'.
    /// </summary>
    public void Remove(int value)
    {
        Node? curr = _head;
        while (curr is not null)
        {
            if (curr.Data == value)
            {
                // Si es el head, usamos la función ya existente.
                if (curr == _head)
                {
                    RemoveHead();
                }
                // Si es el tail, usamos la función ya existente.
                else if (curr == _tail)
                {
                    RemoveTail();
                }
                // Si está en el medio, conectamos los nodos de los lados entre sí.
                else
                {
                    curr.Prev!.Next = curr.Next;
                    curr.Next!.Prev = curr.Prev;
                }
                return; // Solo eliminamos el primero encontrado.
            }
            curr = curr.Next;
        }
    }

    /// <summary>
    /// Problem 4: Search for all instances of 'oldValue' and replace the value to 'newValue'.
    /// </summary>
    public void Replace(int oldValue, int newValue)
    {
        Node? curr = _head;
        while (curr is not null)
        {
            // Si coincide, reemplazamos los datos.
            if (curr.Data == oldValue)
            {
                curr.Data = newValue;
            }
            // No usamos return porque queremos reemplazar TODOS los que coincidan.
            curr = curr.Next;
        }
    }

    /// <summary>
    /// Yields all values in the linked list
    /// </summary>
    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    /// <summary>
    /// Iterate forward through the Linked List
    /// </summary>
    public IEnumerator<int> GetEnumerator()
    {
        var curr = _head; 
        while (curr is not null)
        {
            yield return curr.Data; 
            curr = curr.Next; 
        }
    }

    /// <summary>
    /// Problem 5: Iterate backward through the Linked List
    /// </summary>
    public IEnumerable<int> Reverse()
    {
        // Empezamos desde el tail para ir hacia atrás.
        var curr = _tail;
        while (curr is not null)
        {
            yield return curr.Data;
            // Usamos Prev para movernos hacia el inicio de la lista.
            curr = curr.Prev;
        }
    }

    public override string ToString()
    {
        return "<LinkedList>{" + string.Join(", ", this) + "}";
    }

    public Boolean HeadAndTailAreNull()
    {
        return _head is null && _tail is null;
    }

    public Boolean HeadAndTailAreNotNull()
    {
        return _head is not null && _tail is not null;
    }
}

public static class IntArrayExtensionMethods {
    public static string AsString(this IEnumerable array) {
        return "<IEnumerable>{" + string.Join(", ", array.Cast<int>()) + "}";
    }
}