using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;

public class LevelSelectionMenu : MonoBehaviour {

	public string[] m_levels;

	private Vector2 scrollPosition;

	// Use this for initialization
	void Start ()
	{
		GetLevels();
	}
	
	public void OnGUI()
	{
		GUILayout.BeginArea(new Rect(Screen.width/3, 0, Screen.width/3, Screen.height));
		GUILayout.Label("Level Selection - " + m_levels.Length);
		GUILayout.BeginVertical();
		scrollPosition = GUILayout.BeginScrollView(scrollPosition);
		for (int i = 1; i <= m_levels.Length; i++)
        {
        	//check to make sure if we are in the editor we ignore .meta files
        	if(!m_levels[i-1].Contains(".meta"))
        	{
	        	if(GUILayout.Button(Path.GetFileNameWithoutExtension(m_levels[i-1]), GUILayout.Height(40), GUILayout.Width(Screen.width/3-40)))
	        	{
	        		Debug.Log("File Path: " + m_levels[i-1]);
	        	}
        	}
        }
        GUILayout.EndScrollView();
        GUILayout.EndVertical();
        GUILayout.EndArea();

	}

	public void GetLevels()
	{
		m_levels = Directory.GetFiles(Application.dataPath + "/GameLevels/", "*.json");

		Debug.Log("Levels Found: " + m_levels.Length);
	}

	public List<string> GetLevelNames()
	{

		List<string> levels = new List<string>();

	 	for (int i = 1; i <= m_levels.Length; i++)
        {
            levels.Add(m_levels[i]);
        }

        return levels;
	}

}
