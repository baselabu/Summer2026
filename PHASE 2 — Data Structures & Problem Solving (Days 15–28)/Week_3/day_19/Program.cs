using day_19;

LinkedList ls = new LinkedList();
ls.Add(1);
ls.Add(2);
ls.Add(3);
ls.Add(4);
ls.Add(5);

ls.Print();
ls.PrintReverse();
ls.ShowHead();
ls.ShowTail();
ls.Add(6);
ls.ShowTail();
ls.Remove(3);
ls.Print();
ls.Contains(3);
ls.Contains(4);
ls.CountNodes();