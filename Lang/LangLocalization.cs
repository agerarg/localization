using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class LangLocalization : MonoBehaviour
{
    public static LangLocalization instance;
    public string[] lenguageFiles;

    Dictionary<string, string> lang = new Dictionary<string, string>();

    void Awake()
    {
        instance = this;
        foreach (string textFile in lenguageFiles)
        {
            ReadString(textFile + ".txt");
        }
    }

    void Start()
    {
        
    }

    public string Get(string key,string extra="")
    {
        key = key.Trim();
        if (lang.ContainsKey(key))
        {
            string newstring = lang[key];
            if(extra.Length>0)
            {
                newstring = newstring.Replace("%", extra);
            }
            newstring = newstring.Replace("\r", "");
            return newstring;
        }
        return "";
    }

    public void ReadString(string lenguageFile)
    {
        string path = System.IO.Directory.GetCurrentDirectory() + "/Assets/Content/Lang/" + lenguageFile;
        if (!File.Exists(path))
        {
            Debug.LogError("Error en path:" + path);
        }
        StreamReader reader = new StreamReader(path);
        string everything = reader.ReadToEnd();

        string[] arr = everything.Split('\n');

        foreach (string line in arr)
        {
            if (line.Length > 5)
            {
                string[] mesg = line.Split('@');
           
                mesg[0] = mesg[0].Trim();
                lang.Add(mesg[0], mesg[1]);
            }
        }

        reader.Close();
    }
}
