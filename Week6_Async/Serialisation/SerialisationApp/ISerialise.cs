using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerialisationApp;

internal interface ISerialise
{
    public T DeserialiseFromFile<T>(string filePath);
    public void SerialiseToFile<T>(string filePath, T item);
}
