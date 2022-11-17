using System;

namespace Double_Linked_List_Sample
{
    //Each node consists of the information part and a lik to the next node
    class Node
    {
        public int rollNumber;
        public string name;
        public Node next;
        public Node prev;
    }
    class DoubleLinkedList
    {
        Node start;
        public DoubleLinkedList()
        {
            start = null;
        }
        //adds a node in the list
        public void addNode()
        {
            int rollNo;
            string nm;
            Console.Write("\nEnter the roll number of the student : ");
            rollNo = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nEnter the name of the student : ");
            nm = Console.ReadLine();
            Node newnode = new Node();
            newnode.rollNumber = rollNo;
            newnode.name = nm;

            //if the node to be inserted is the first node
            if (start == null || rollNo <= start.rollNumber)
            {
                if ((start != null) && (rollNo == start.rollNumber))
                {
                    Console.WriteLine("\nDupplicate roll numbers not allowed");
                    return;
                }
                newnode.next = start;
                if (start != null)
                    start.prev = newnode;
                newnode.prev = null;
                start = newnode;
                return;
            }

            //locate the position of the new node in the list
            Node previous, current;
            for (current = previous = start; current != null && rollNo >= current.rollNumber; previous = current, current = current.next)
            {
                if (rollNo == current.rollNumber)
                {
                    Console.WriteLine("\nDuplicate roll numbers not allowed\n");
                    return;
                }

            }
            if (current == null)
            {
                newnode.next = current;
                previous.next = newnode;
                return;
            }
            current.prev = newnode;
            previous.next = newnode;

        }
        //deletes the specified node from the list
        public bool delNode(int rollNo)
        {
            Node previous, current;
            previous = current = null;
            //checks if the specified node is present in the list or not
            if (Search(rollNo, ref previous, ref current) == false)
                return false;
            if (current == start)
            {
                start = start.next;
                if (start != null)
                    start.prev = null;
                return true;
            }
            if (current.next == null)
            {
                previous.next = null;
                return true;
            }
            previous.next = current.next;
            current.next.prev = previous;
            return true;

        }
        //checks whether the specified node is present in the list or not
        public bool Search(int rollNo, ref Node previous, ref Node current)
        {
            for (previous = current = start; current != null && rollNo != current.rollNumber; previous = current, current = current.next)
            { }
            return (current != null);
        }
        //traverses the list
        public void traverse()
        {
            if (listEmpty())
                Console.WriteLine("\nList is empty.\n");
            else
            {
                Console.WriteLine("\nRecords in the ascending order of " + "roll number are:\n");
                Node currentNode;
                for (currentNode = start; currentNode != null;
                    currentNode = currentNode.next)
                    Console.Write(currentNode.rollNumber + " " + currentNode.name + "\n");
                Console.WriteLine();
            }
        }
        public void revtraverse()
        {
            if (listEmpty())
                Console.WriteLine("\nList is empty.\n");
            else
            {
                Console.WriteLine("\nRecords in the ascending order of " + "roll number are:\n");
                Node currentNode;
                for (currentNode = start; currentNode != null;
                    currentNode = currentNode.next)
                { }
                while (currentNode != null)
                {
                    Console.Write(currentNode.rollNumber + "  " + currentNode.name + "\n");
                    currentNode = currentNode.prev;
                }
                Console.Write(currentNode.rollNumber + " " + currentNode.name + "\n");
                Console.WriteLine();
            }
        }
        public bool listEmpty()
        {
            if (start == null)
                return true;
            else
                return false;
        }
        static void Main(string[] args)
        {
            DoubleLinkedList obj = new DoubleLinkedList();
            while (true)
            {
                try
                {
                    Console.WriteLine("\nMenu");
                    Console.WriteLine("1. Add a record to the list");
                    Console.WriteLine("2. Delete a record from the list");
                    Console.WriteLine("3. View all  records in the ascending order of roll number");
                    Console.WriteLine("4. View all  records in the ascending order of roll number");
                    Console.WriteLine("5. Search for a record in the list");
                    Console.WriteLine("6. Exit");
                    Console.Write("\nEnter your choice (1 - 6) : ");
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                obj.addNode();
                            }
                            break;
                        case '2':
                            {
                                if (obj.listEmpty())
                                {
                                    Console.WriteLine("\nList is empty");
                                    break;
                                }
                                Console.Write("\nEnter the roll number of the student" + " whose record is to be deleted : ");
                                int rollNo = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine();
                                if (obj.delNode(rollNo) == false)
                                    Console.WriteLine("Record with roll number" + rollNo + "deleted");
                                else
                                    Console.WriteLine("record not found");
                            }
                            break;
                        case '3':
                            {
                                obj.traverse();
                            }
                            break;
                        case '4':
                            {
                                if (obj.listEmpty() == true)
                                {
                                    Console.WriteLine("\nList is Empty");
                                    break;
                                }
                                Node previous, current;
                                previous = current = null;
                                Console.Write("\nEnter the roll number of the" + " strudent whose record is to be searched : ");
                                int num = Convert.ToInt32(Console.ReadLine());
                                if (obj.Search(num, ref previous, ref current) == false)
                                    Console.WriteLine("\nRecord not found.");
                                else
                                {
                                    Console.WriteLine("\nRecord found.");
                                    Console.WriteLine("\nRecord number : " + current.rollNumber);
                                    Console.WriteLine("\nName : " + current.name);
                                }
                            }
                            break;
                        case '5':
                            {
                                if (obj.listEmpty() == true)
                                {
                                    Console.WriteLine("\nList is empty");
                                    break;
                                }

                                Node prev, curr;
                                prev = curr = null;
                                Console.Write("\nEnter the roll number of the student whose record is to be searched : ");
                                int num = Convert.ToInt32(Console.ReadLine());
                                if (obj.Search(num, ref prev, ref curr) == false)
                                    Console.WriteLine("\nRecord not found.");
                                else
                                {
                                    Console.WriteLine("\nRecord found.");
                                    Console.WriteLine("\nRecord number : " + curr.rollNumber);
                                    Console.WriteLine("\nName : " + curr.name);
                                }
                            }
                            return;
                        case '6':
                            return;
                        default:
                            {
                                Console.WriteLine("\nInvalid option");
                                break;
                            }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("\nCheck for the value entered.");
                }
            }
        }
    }
}