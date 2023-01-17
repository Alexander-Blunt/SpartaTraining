using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace SerialisationApp
{
    internal class XMLSerialiser : ISerialise
    {
        public T DeserialiseFromFile<T>(string filePath)
        {
            Stream fileStream = File.OpenRead(filePath);

            XmlSerializer reader = new XmlSerializer(typeof(T));

            var deserialisedItem = (T)reader.Deserialize(fileStream);

            fileStream.Close();

            return deserialisedItem;
        }

        public void SerialiseToFile<T>(string filePath, T item)
        {
            FileStream fileStream = File.Create(filePath);
            // creating a binary formatter object to serialise the item to a file.
            XmlSerializer writer = new XmlSerializer(item.GetType());
            writer.Serialize(fileStream, item);

            fileStream.Close();
        }
    }
}
