using System.Collections;

SinglyLinkedList<int?> list = new();
list.AddToEnd(1);
list.AddToEnd(2);
list.AddToEnd(null);
list.AddToEnd(3);

Console.WriteLine($"Count: {list.Count}");
Console.WriteLine($"Contains 2: {list.Contains(2)}");
Console.WriteLine($"Contains 4: {list.Contains(4)}");
Console.WriteLine($"Remove 2: {list.Remove(2)}");
Console.WriteLine($"Contains 2: {list.Contains(2)}");
Console.WriteLine($"Count: {list.Count}");
Console.WriteLine(string.Join(" ", list));
Console.WriteLine($"Contains null: {list.Contains(null)}");
Console.WriteLine($"Remove null: {list.Remove(null)}");
Console.WriteLine($"Count: {list.Count}");
Console.WriteLine(string.Join(" ", list));

public class SinglyLinkedList<T> : ILinkedList<T?>
{
    private SinglyLinkedListNode? _head;
    private int _count;

    public int Count => _count;

    public bool IsReadOnly => false;

    public void Add(T? item) => AddToEnd(item);

    public void AddToEnd(T? item)
    {
        if (_head is null)
        {
            _head = new SinglyLinkedListNode(item);
        }
        else
        {
            var currentNode = _head;
            while (currentNode.Next is not null)
            {
                currentNode = currentNode.Next;
            }

            currentNode.Next = new SinglyLinkedListNode(item);
        }
        _count++;
    }

    public void AddToFront(T? item)
    {
        var newNode = new SinglyLinkedListNode(item, _head);
        _head = newNode;
        _count++;
    }

    public void Clear()
    {
        SinglyLinkedListNode? currentNode = _head;
        while (currentNode is not null)
        {
            var nextNode = currentNode.Next;
            currentNode.Next = null;
            currentNode = nextNode;
        }

        _head = null;
        _count = 0;
    }

    public bool Contains(T? item)
    {
        var currentNode = _head;
        while (currentNode is not null)
        {
            if (item?.Equals(currentNode.Value) ?? currentNode.Value is null)
            {
                return true;
            }
            currentNode = currentNode.Next;
        }
        
        return false;
    }

    public void CopyTo(T?[] array, int arrayIndex)
    {
        if (array is null)
        {
            throw new ArgumentNullException(nameof(array));
        }
        if (arrayIndex < 0 || arrayIndex > array.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(arrayIndex));
        }
        if (array.Length - arrayIndex < _count)
        {
            throw new ArgumentException("Not enough space in the array");
        }

        var currentNode = _head;
        while (currentNode is not null)
        {
            array[arrayIndex++] = currentNode.Value;
            currentNode = currentNode.Next;
        }
    }

    public bool Remove(T? item)
    {
        var currentNode = _head;
        SinglyLinkedListNode? previousNode = null;
        while (currentNode is not null)
        {
            if (item?.Equals(currentNode.Value) ?? currentNode.Value is null)
            {
                if (previousNode is null)
                {
                    _head = currentNode.Next;
                }
                else
                {
                    previousNode.Next = currentNode.Next;
                }
                currentNode.Next = null;
                _count--;
                return true;
            }
            previousNode = currentNode;
            currentNode = currentNode.Next;
        }
        return false;
    }

    public IEnumerator<T?> GetEnumerator()
    {
        var currentNode = _head;
        while (currentNode is not null)
        {
            yield return currentNode.Value;
            currentNode = currentNode.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }


    private class SinglyLinkedListNode
    {
        public T? Value { get; }
        public SinglyLinkedListNode? Next { get; set; }

        public SinglyLinkedListNode(T? value, SinglyLinkedListNode? next = null)
        {
            Value = value;
            Next = next;
        }

        public override string ToString() => $"Value: {Value}, Next: {(Next is null ? "null" : Next.Value)}";
    }
}

public interface ILinkedList<T> : ICollection<T>
{
    void AddToFront(T item);
    void AddToEnd(T item);
}
