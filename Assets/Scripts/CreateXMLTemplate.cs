using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[ExecuteAlways]
public class CreateXMLTemplate : MonoBehaviour
{

    public AdPopups data;
    public string path;

    public bool create = false;
    
    // Update is called once per frame
    void Update()
    {
        if(create)
        {
            create = false;
            Create();
        }
    }

    void Create ()
    {
        XMLSaver.SaveXML(data, path, "AdPopups");
        AssetDatabase.Refresh();
    }
}
