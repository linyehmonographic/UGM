using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class Log_Writer{
    //private StreamWriter sw;
    private System.DateTime start_time;

    public Log_Writer(string path)
    {
        //sw = File.CreateText(path + "/UGM_Log " + System.DateTime.Now.ToString("yyyyMMdd HHmmss") + ".txt");
        Debug.Log("UGM LogStart" + " SceneName:" + SceneManager.GetActiveScene().name);
        start_time = System.DateTime.Now;
    }

    public void Log(string s)
    {
        Debug.Log(s);
    }

    public void UserEvent_Log(string s)
    {
        if (Configuration.Log.Enabled)
        {
            string log = "UGM " + get_time() + " User_Event( " + s + " );";
            Debug.Log(log);
            //sw.WriteLine(log);
            //sw.Flush();
        }
    }

    public void Contextual_Attribute(string s)
    {
        string log = "UGM " + get_time() + " Contextual_Attr( " + s + " );";
        Debug.Log(log);
        //sw.WriteLine(log);
        //sw.Flush();
    }

    public void Contextual_Event(string s)
    {
        string log = "UGM " + get_time() + " Contextual_Event( " + s + " );";
        Debug.Log(log);
    }

    private string get_time()
    {
        System.TimeSpan ts = System.DateTime.Now - start_time;
        return ts.Hours + ":" + ts.Minutes + ":" + ts.Seconds + "." + string.Format("{0:000}", ts.Milliseconds);
    }

    ~Log_Writer()
    {
        //sw.Flush();
        //sw.Close();
        Debug.Log("UGM LogEnd");
    }
}
