using UnityEngine;
using System.Xml;

public class XML_Parser {
    public void Start_Parse()
    {
        XmlReader xmlReader = XmlReader.Create(Application.dataPath + "/Unity_Game_Monitor/UGM_Config.xml");
        XmlDocument xmlDocument = new XmlDocument();
        xmlDocument.Load(xmlReader);
        foreach (XmlNode Configurations in xmlDocument["UGM_Configuration"].ChildNodes)
        {
            if (Configurations.Name == "Contextual_Objects")
            {
                foreach (XmlNode config in Configurations.ChildNodes)
                {
                    if (config.Name == "Static_Objects")
                    {
                        foreach(XmlNode Object_Name in config.ChildNodes)
                        {
                            Configuration.Contextual_Objects.Static_Objects.Add(Object_Name.InnerText);
                        }
                    }
                    else if (config.Name == "Trace_By_Tag_Name")
                    {
                        foreach (XmlNode Object_Name in config.ChildNodes)
                        {
                            Configuration.Contextual_Objects.Trace_By_Tag_Name.Add(Object_Name.InnerText);
                        }
                    }
                    else if(config.Name == "Contextual_Objects_Attribute")
                    {
                        if(config.ChildNodes[0].Name == "Enabled")
                        {
                            if (config.ChildNodes[0].InnerText == "true")
                                Configuration.Contextual_Objects.Contextual_Objects_Attribute_Enabled = true;
                            else
                                Configuration.Contextual_Objects.Contextual_Objects_Attribute_Enabled = false;
                        }
                        else
                        {
                            printError("Xml tag name error: " + config.Name);
                        }
                    }
                    else if (config.Name == "Contextual_Objects_Events")
                    {
                        if (config.ChildNodes[0].Name == "Enabled")
                        {
                            if (config.ChildNodes[0].InnerText == "true")
                                Configuration.Contextual_Objects.Contextual_Objects_Events_Enabled = true;
                            else
                                Configuration.Contextual_Objects.Contextual_Objects_Events_Enabled = false;
                        }
                        else
                        {
                            printError("Xml tag name error: " + config.Name);
                        }
                    }
                    else
                    {
                        printError("Xml tag name error: " + config.Name);
                    }
                }
            }
            else if(Configurations.Name == "User_Event")
            {
                foreach(XmlNode config in Configurations.ChildNodes)
                {
                    if(config.Name == "Callback_Function")
                    {
                        if (config.ChildNodes[0].Name == "Enabled")
                        {
                            if (config.ChildNodes[0].InnerText == "true")
                                Configuration.User_Event.Callback_Function_Enabled = true;
                            else
                                Configuration.User_Event.Callback_Function_Enabled = false;
                        }
                        else
                            printError("Xml tag name error: " + config.ChildNodes[0].Name);
                    }
                    else if(config.Name == "Touch")
                    {
                        if (config.ChildNodes[0].Name == "Enabled")
                        {
                            if (config.ChildNodes[0].InnerText == "true")
                                Configuration.User_Event.Touch_Enabled = true;
                            else
                                Configuration.User_Event.Touch_Enabled = false;
                        }
                        else
                            printError("Xml tag name error: " + config.ChildNodes[0].Name);
                    }
                    else
                    {
                        printError("Xml tag name error: " + config.Name);
                    }
                }
            }
            else if (Configurations.Name == "Log")
            {
                foreach (XmlNode logChild in Configurations.ChildNodes)
                {
                    if (logChild.Name == "Enabled")
                    {
                        Configuration.Log.Enabled = logChild.InnerText == "true" ? true : false;
                    }
                    else if(logChild.Name == "Moving_Standard_Distance")
                    {
                        Configuration.Log.Moving_Standard_Distance = float.Parse(logChild.InnerText);
                    }
                    else
                    {
                        printError("Xml tag name error: " + logChild.Name);
                    }
                }
            }
            else
            {
                printError("Xml tag name error: " + Configurations.Name);
            }
        }
    }

    private void printError(string s)
    {
        Debug.Log(s);
    }
}
