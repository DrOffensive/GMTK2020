using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public static class XMLSaver
{
    public static void SaveXML<T> (T data, string path, string filename, string filetype = "xml")
    {
        XmlSerializer serializer = new XmlSerializer(typeof(T));

        string directory = Application.dataPath + "/" + path;
        CheckFolder(directory);
        string fullPath = directory + "/" + filename + "." + filetype;

        try
        {
            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                serializer.Serialize(stream, data);
                Debug.Log($"Saved {filename}.{filetype} to {fullPath}");
            }
        } catch (System.Exception e)
        {
            Debug.LogError("XmlSaver.SaveXML() => " + e);
        }
    }

    static void CheckFolder (string path)
    {
        Debug.Log($"Checking Directory: {path}");
        string[] folders = path.Split('/', '\\');
        if (folders.Length < 2)
            return;

        string currentPath = folders[0];
        for(int i = 1; i < folders.Length; i++)
        {
            currentPath += "/" + folders[i];
            Debug.Log($"Checking folder: {currentPath}");
            if (!Directory.Exists(currentPath))
                Directory.CreateDirectory(currentPath);
        }
    }
}
