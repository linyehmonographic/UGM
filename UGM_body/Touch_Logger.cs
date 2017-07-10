using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Touch_Logger : MonoBehaviour {
    public UGM_Controller controller;

    Touch[] touches = new Touch[5];
    bool[] isMoving = new bool[5];
    TouchPhase[] lastPhase = new TouchPhase[5];
    Vector2[] beginTouchPositions = new Vector2[5];

    Camera currentCamera;

    Log_Writer logWriter;

    // Use this for initialization
    void Start () {
        logWriter = new Log_Writer(Application.persistentDataPath);

        if (!EventSystem.current)
        {
            Instantiate(gameObject.GetComponent<UGM_Controller>().EventSystem_prefab);
        }
		for(int i = 0; i < 5; ++i)
        {
            touches[i].fingerId = -1;
            lastPhase[i] = TouchPhase.Ended;
            isMoving[i] = false;
        }
        currentCamera = Camera.current;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(1/Time.deltaTime);
        if (Camera.current != currentCamera)
        {
            if (Camera.current)
            {
                if (!Camera.current.GetComponent<PhysicsRaycaster>())
                    Camera.current.gameObject.AddComponent<PhysicsRaycaster>();
                if (!Camera.current.GetComponent<Physics2DRaycaster>())
                    Camera.current.gameObject.AddComponent<Physics2DRaycaster>();
                if (!Camera.current.GetComponent<GraphicRaycaster>())
                    Camera.current.gameObject.AddComponent<GraphicRaycaster>();
            }
            currentCamera = Camera.current;
        }

        if (Input.touchCount > 0) {
            for (int i = 0; i < Input.touchCount; ++i)
            {
                int fingerId = Input.touches[i].fingerId;
                touches[fingerId] = Input.touches[i];

                if (touches[fingerId].phase != lastPhase[fingerId])
                {
                    if (touches[fingerId].phase == TouchPhase.Began)
                    {
                        string log = "FingerId: " + fingerId + ", Type: User_Event, TouchPhase: Began, x: " + touches[fingerId].position.x + ", y: " + touches[fingerId].position.y;
                        if (currentCamera)
                        {
                            PointerEventData ped = new PointerEventData(EventSystem.current);
                            ped.position = touches[fingerId].position;
                            List<RaycastResult> results = new List<RaycastResult>();
                            EventSystem.current.RaycastAll(ped, results);
                            for (int r = 0; r < results.Count; ++r)
                            {
                                log += ", GameObject_Name[" + r + "]: " + results[r].gameObject.name;
                            }
                        }
                        logWriter.Log(log);
                        beginTouchPositions[fingerId] = touches[fingerId].position;

                        Log_Active(fingerId);
                    }
                    /* 這邊的Ended因為touchCount -1 所以跑不進來
                    else if (touches[fingerId].phase == TouchPhase.Ended)
                    {
                        logWriter.Log("Type: User_Event, TouchPhase: Ended");
                        lastPhase[fingerId] = TouchPhase.Ended;
                        touches[i].fingerId = -1;
                    }
                    */
                    else if (touches[fingerId].phase == TouchPhase.Moved)
                    {
                        if (!isMoving[fingerId])
                        {
                            if (Vector2.Distance(beginTouchPositions[fingerId], touches[fingerId].position) > Configuration.Log.Moving_Standard_Distance)
                            {
                                isMoving[fingerId] = true;
                            }
                        }
                    }
                    /*
                    else if (touches[fingerId].phase == TouchPhase.Stationary)
                    {

                    }
                    */
                    else if (touches[fingerId].phase == TouchPhase.Canceled)
                    {
                        logWriter.Log("FingerId: " + touches[i].fingerId + ", Type: User_Event, TouchPhase: Canceled");
                    }
                    
                    lastPhase[fingerId] = touches[fingerId].phase;
                }

                if (isMoving[fingerId])
                {
                    logWriter.Log("FingerId: " + touches[fingerId].fingerId + ", Type: User_Event, TouchPhase: Moved, x: " + touches[fingerId].position.x + ", y: " + touches[fingerId].position.y);
                    Log_Active(fingerId);
                }
            }
            for(int i = 0; i < 5; ++i)
            {
                if(touches[i].fingerId != -1 && touches[i].phase == TouchPhase.Ended)
                {
                    logWriter.Log("FingerId: " + touches[i].fingerId + ", Type: User_Event, TouchPhase: Ended, x:" + touches[i].position.x + ", y: " + touches[i].position.y);
                    lastPhase[i] = TouchPhase.Ended;
                    touches[i].fingerId = -1;
                    isMoving[i] = false;
                }
            }
        }
        else
        {
            for (int i = 0; i < 5; ++i)
            {
                if (lastPhase[i] != TouchPhase.Ended)
                {
                    logWriter.Log("FingerId: " + touches[i].fingerId + ", Type: User_Event, TouchPhase: Ended, x:" + touches[i].position.x + ", y: " + touches[i].position.y);
                    lastPhase[i] = TouchPhase.Ended;
                }
                touches[i].fingerId = -1;
                isMoving[i] = false;
            }
        }
	}

    private void Log_Active(int fingerId)
    {
        for (int t = 0; t < controller.objects_has_traitor.Count; ++t)
        {
            if (controller.objects_has_traitor[t])
            {
                Vector3 pos = controller.objects_has_traitor[t].getPosition();
                logWriter.Contextual_Log("FingerId: " + fingerId + ", GameObject_Name: " + controller.objects_has_traitor[t].getName() + ", Position: " + pos.x + "," + pos.y + "," + pos.z);
            }
        }
    }

    public void Log_EventTrigger(string name, string e)
    {
        logWriter.Contextual_Log("GameObject_Name: " + name + ", CallbackFunction: " + e + " called");
    }
}
