
using System.Collections.Generic;

public class Repository : IRepository
{
    public List<int> rep { get; set; }

    public Repository()
    {
        rep = new List<int>();
        rep.Add(15);
        rep.Add(5);
        rep.Add(3);
        rep.Add(1);
    }
}