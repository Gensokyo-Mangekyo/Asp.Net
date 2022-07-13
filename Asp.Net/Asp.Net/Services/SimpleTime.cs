using System;

public class SimpleTime : ITime
{
    public string Time => DateTime.Now.ToString("hh:mm:ss");
}