﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace BaseLibrary.Util
{
    public class DictionarySerializer<TKey, TValue>
    {
        private readonly XmlSerializer _serializer = new XmlSerializer(typeof (Item[]),
            new XmlRootAttribute("Dictionary"));

        public Dictionary<TKey, TValue> Deserialize(string filename)
        {
            using (var stream = new FileStream(filename, FileMode.Open))
            using (var reader = XmlReader.Create(stream))
            {
                return ((Item[]) _serializer.Deserialize(reader)).ToDictionary(p => p.Key, p => p.Value);
            }
        }

        public void Serialize(string filename, Dictionary<TKey, TValue> dictionary)
        {
            using (var writer = new StreamWriter(filename))
            {
                _serializer.Serialize(writer, dictionary.Select(p => new Item {Key = p.Key, Value = p.Value}).ToArray());
            }
        }

        [XmlType(TypeName = "Item")]
        public class Item
        {
            [XmlAttribute("key")] public TKey Key;

            [XmlAttribute("value")] public TValue Value;
        }
    }
}