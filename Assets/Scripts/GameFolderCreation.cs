using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class GameFolderCreation : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		
		CreateDirectory("GameLevels");
		CreateDirectory("GameSaves");
		RefreshDatabase();
	}
	
	//creates a directory with the given name in the Assets folder
	public void CreateDirectory(string name)
	{
		if(Directory.Exists(Application.dataPath + "/" + name) == false)
		{
			Directory.CreateDirectory(Application.dataPath + "/" + name);
			Debug.Log("Folder Created: " + name);
		}
		else
		{
			Debug.Log("Folder Already Exists: " + name);
		}
	}

	private void RefreshDatabase()
	{
		#if UNITY_EDITOR
        //refresh the project view if we are in the editor only
        AssetDatabase.Refresh();
		#endif
	}


}
