using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public static class XMLLoader
{

    public static T LoadXML<T> (string path)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(T));
        
        using (FileStream stream = new FileStream(path, FileMode.Open))
        {
            T deserialized = (T)serializer.Deserialize(stream);
            Debug.Log($"Loaded {path}");
            return deserialized;
        }
        
    }

}
