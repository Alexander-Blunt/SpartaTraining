using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LambdasAndLinq;

public class Person
{
    private int _age;
    public string Name { get; set; }
    // Lambda operator can be used to shorten code
    public int Age
    {
        get => _age;
        set => _age = value < 0 ? throw new ArgumentException() : value;
    }
    public string City { get; set; }
    public override string ToString() => $"{Name} - {City} - {Age}";
}
