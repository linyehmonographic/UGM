using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Log_Writer{
    private StreamWriter sw;

    public Log_Writer(string path)
    {
        sw = File.CreateText(path + "/UGM_Log " + System.DateTime.Now.ToString("yyyyMMdd HHmmss") + ".txt");
    }

    public void Log(string s)
    {
        if (Configuration.Log.Enabled)
        {
            string log = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:ffff") + " User_Event( " + s + " );";
            Debug.Log(log);
            sw.WriteLine(log);
            sw.Flush();
        }
    }

    public void Contextual_Log(string s)
    {
        string log = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss:ffff") + " Contextual_Log( " + s + " );";
        Debug.Log(log);
        sw.WriteLine(log);
        sw.Flush();
    }

    ~Log_Writer()
    {
        sw.Flush();
        sw.Close();
    }
}
