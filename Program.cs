using System;
class GFG {
    public class Node {
        public int data;
        public Node next;
 
        public Node(int d)
        {
            this.data = d;
            this.next = null;
        }
    }
    Node? head;
    public void push(int new_data)
    {       
        Node? new_node = new Node(new_data); /*Allocate the Node and Put in the data*/
        new_node.next = head; /* 3. Make next of new Node as head */
        head = new_node;/* 4. Move the head to point to new Node */    
    }
    void printList(Node n)
    {
        while (n != null) {
            Console.Write(n.data);
            Console.Write(" ");
            n = n.next;
        }
    }
 
    // takes first and last node, do not break any links in the linked list
    
    Node partitionLast(Node start, Node end)
    {
        if (start == end || start == null || end == null)
            return start;
 
        Node pivot_prev = start;
        Node curr = start;
        int pivot = end.data;
 
        // iterate till one before the end,
        // no need to iterate till the end
        // because end is pivot
        int temp;
        while (start != end) {
 
            if (start.data > pivot) {
                // keep tracks of last modified item
                pivot_prev = curr;
                temp = curr.data;
                curr.data = start.data;
                start.data = temp;
                curr = curr.next;
            }
            start = start.next;
        }
 
        // swap the position of curr i.e.
        // next suitable index and pivot
        temp = curr.data;
        curr.data = pivot;
        end.data = temp;
 
        // return one previous to current
        // because current is now pointing to pivot
        return pivot_prev;
    }
 
    void sort(Node start, Node end)
    {
        if (start == end)
            return;
 
        // split list and partition recurse
        Node pivot_prev = partitionLast(start, end);
        sort(start, pivot_prev);
 
        // if pivot is picked and moved to the start, that means start and pivot is same so pick from next of pivot
        
        if (pivot_prev != null && pivot_prev == start)
            sort(pivot_prev.next, end);
 
        // if pivot is in between of the list, start from next of pivot, since we have pivot_prev, so we move two nodes
        
        else if (pivot_prev != null
                 && pivot_prev.next != null)
            sort(pivot_prev.next.next, end);
    }
    public void pop(){
        head = head.next;//if (list.head.next != null) {list.head=list.head.next;}
        
        Node N = this.head;
            while (N.next != null)
                N = N.next;

            // Function call
            this.sort(this.head, N);
    }
    // Driver Code
    public static void Main(String[] args)
    {
        GFG list = new GFG();
        string? pause;
        int n=16000;
        int m=33;
    
        var watch = new System.Diagnostics.Stopwatch();
        
        watch.Start();    
        
            list.push(n);    
            list.push(30);
            list.push(3);
            list.push(4);
            list.push(20);
            list.push(5);
            for(int i = 1; i<n; i++) { list.push(m);}
            list.push(1);
            list.push(30);
            list.push(3);
            list.push(4);
            list.push(20);
            
        watch.Stop();
 
        Console.WriteLine($"Execution Time QuickPush before sorting: {watch.ElapsedMilliseconds} ms for {n+11} elements");   
        
        pause = Console.ReadLine();
        Console.WriteLine("Linked List before sorting");
        pause = Console.ReadLine();
        list.printList(list.head);
 
        watch.Start();    
            list.pop();
            
        watch.Stop();
        
        Console.WriteLine($"\nExecution Time QuickPush sorting: {watch.ElapsedMilliseconds} ms for {n+11} elements");   
        pause = Console.ReadLine();
        Console.WriteLine("\nLinked List after sorting");
        pause = Console.ReadLine();
        list.printList(list.head);
    }
}

