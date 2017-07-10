using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UGM_Controller : MonoBehaviour {
    public GameObject EventSystem_prefab;
    public Touch_Logger touch_logger;
    public List<Traitor> objects_has_traitor;

    // Use this for initialization
    void Start () {
        XML_Parser parser = new XML_Parser();
        parser.Start_Parse();

        for(int i = 0; i < Configuration.Contextual_Objects.Static_Objects.Count; ++i)
        {
            GameObject go = GameObject.Find(Configuration.Contextual_Objects.Static_Objects[i]);
            if (go)
                objects_has_traitor.Add(go.AddComponent<Traitor>());
            else
                Debug.Log("UGM_Error: GameObject name '" + Configuration.Contextual_Objects.Static_Objects[i] + "' cannot be found.");
        }
        for (int i = 0; i < Configuration.Contextual_Objects.Trace_By_Tag_Name.Count; ++i)
        {
            try
            {
                GameObject[] gos = GameObject.FindGameObjectsWithTag(Configuration.Contextual_Objects.Trace_By_Tag_Name[i]);
                for (int j = 0; j < gos.Length; ++j)
                {
                    objects_has_traitor.Add(gos[i].AddComponent<Traitor>());
                }
            }
            catch (UnityException e)
            {
                Debug.Log("UGM_Error: Tag '" + Configuration.Contextual_Objects.Trace_By_Tag_Name[i] + "' is not defined.");
            }
        }
        for(int i = 0; i < objects_has_traitor.Count; ++i)
        {
            objects_has_traitor[i].controller = this;
        }

        touch_logger = gameObject.AddComponent<Touch_Logger>();
        touch_logger.controller = this;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
