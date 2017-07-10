using System.Collections;
using System.Collections.Generic;

public static class Configuration {
    public static class Contextual_Objects
    {
        public static List<string> Static_Objects = new List<string>();
        public static List<string> Trace_By_Tag_Name = new List<string>();

        public static bool Contextual_Objects_Attribute_Enabled = true;
        public static bool Contextual_Objects_Events_Enabled = true;
    }

    public static class User_Event
    {
        public static bool Callback_Function_Enabled = true;
        public static bool Touch_Enabled = true;
    }

    public static class Log
    {
        public static float Moving_Standard_Distance = 10.0f;
        public static bool Enabled = true;
    }
}
