using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Debugger : MonoBehaviour {

	private bool m_debuggerOn = false;

	public List<Log> m_logs = new List<Log>();

	private string m_viewingStackTrace = "Select A Log/Error/Warning to view the StackTrace";
	private Vector2 scrollPosition;

	// Use this for initialization
	void Start () {

		DontDestroyOnLoad(this.gameObject);
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		//check if the user has pressed tab or not to bring up the debugger
		if(Input.GetKeyDown(KeyCode.Tab))
		{
			ToggleDebugger();
		}
	}

	private void ToggleDebugger()
	{
		m_debuggerOn = !m_debuggerOn;
    	Debug.Log("Toggling Debugger");
	}

    void OnGUI()
    {

    	if(m_debuggerOn == false)
    		return;

		GUILayout.Box("", GUILayout.Width(Screen.width), GUILayout.Height(Screen.height));

    	GUILayout.BeginArea(new Rect(0,0, Screen.width, Screen.height));

    	GUILayout.Button(Application.productName + " | Tab = Open/Close Debugger | Copy & Pasting Stacktraces Allowed");

    	if(m_logs.Count != 0)
    	{

	    	GUILayout.BeginVertical();

	    	scrollPosition = GUILayout.BeginScrollView(scrollPosition);

	    	
		    	for (int i = 1; i <= m_logs.Count; i++)
		        {

		        	string colorStartString;
		        	//check what log type it is so we can assign a color to the log
		        	if(m_logs[i-1].type.ToString().ToLower() == "warning")
		        	{
		        		colorStartString = "yellow";
		        	}
		        	else if(m_logs[i-1].type.ToString().ToLower() == "log")
		        	{
		        		colorStartString = "white";
		        	}
		        	else
		        	{
		        		colorStartString = "red";
		        	}
		        	
		        	//put the log into a single string
		            string fullLog = "<color=" + colorStartString + ">" + m_logs[i-1].type.ToString() + "</color>" + " : " + m_logs[i-1].log;
		            
		            //display the log inside a button so we can select it and see the full stack trace
		            if(GUILayout.Button(fullLog))
		            {
		            	m_viewingStackTrace = m_logs[i-1].stackTrace;
		            }

		        }
	    	

	        GUILayout.EndScrollView();

	        GUILayout.TextArea(m_viewingStackTrace);

	        GUILayout.EndVertical();

    	}
    	else
    	{
    		GUILayout.Label("No Logs To Display");
    	}

    	GUILayout.EndArea();
    }


    void OnEnable() 
    {
        Application.logMessageReceived += HandleLog;
    }
    
    void OnDisable()
    {
        Application.logMessageReceived -= HandleLog;
    }
    
    void HandleLog(string logString, string stackTrace, LogType type) {
        
        Log newLog = new Log();
        newLog.log = logString;
        newLog.stackTrace = stackTrace;
        newLog.type = type;
        m_logs.Add(newLog);

    }

}
