namespace assignment4;



public class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Data { get; set; }
        public Node(T t)
        {
            Next = null;
            Data = t;
        }
}


public class GenericList<T>
{
    private Node<T> head;
    private Node<T> tail;

    public GenericList()
    {
        tail = head = null;
    }

    public Node<T> Head
    {
        get => head;
    }

    public void Add(T t)
    {
        Node<T> n = new Node<T>(t);
        if (tail == null)
        {
            head = tail = n;

        }
        else
        {
            tail.Next = n;
            tail = n;
        }
    }

    public void ForEach(Action<T> action)
    {
        Node<T> current = head;
        while (current != null)
        {
            action(current.Data);
            current = current.Next;
        }
    }




}


public class Program1
{
    static void Main(string[] args)
    {
        GenericList<int> myList = new GenericList<int>();

        //先简单创建几个数据加进去
        myList.Add(100);
        myList.Add(150);
        myList.Add(200);

        myList.ForEach(item => Console.WriteLine(item));

        int min = myList.Head.Data;
        myList.ForEach(item =>
        {
            if (item < min)
                min = item;
        });
        Console.WriteLine($"Min: {min}");

        int max = myList.Head.Data;
        myList.ForEach(item =>
        {
            if (item > max)
                max = item;
        });
        Console.WriteLine($"Max: {max}");

        int sum = 0;
        myList.ForEach(item => sum += item);
        Console.WriteLine($"Sum: {sum}");


    }
}

