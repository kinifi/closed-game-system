using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TinyJSON;
#if UNITY_EDITOR
using UnityEditor;
#endif
using NUnit.Framework;

public class JSONLevelSaving {


	//list of all the prefabs in the scene
    public List<Entity> m_Entities = new List<Entity>();

	[Test]
	public void SaveScene() {
		
		SaveScene("JSONUnitTest");

	}

	//grab every GameObject in the scene and save it to an Entity then serialize it to json file
	public void SaveScene(string sceneName = "testScene")
	{
		//find all the GameObjects in the scene
		foreach (GameObject obj in Object.FindObjectsOfType(typeof(GameObject)))
		{
            //create a new object
            Entity newEntity = new Entity();
            //set the name. 
            newEntity.m_name = obj.name.ToLower();
            //set the position
            newEntity.m_position.x = obj.transform.position.x;
            newEntity.m_position.y = obj.transform.position.y;
            newEntity.m_position.z = obj.transform.position.z;
            //this object will not be static
            newEntity.m_static = false;
            //add the new Entity to the list of Entities 
            m_Entities.Add(newEntity);
		}

		
        //serialize all these objects into a pretty json string. Ture = pretty
        string sceneJSON = JSON.Dump(m_Entities, true);

        //create a save location thats inside of the Assets folder
        string saveLocation = Application.dataPath + "/" + sceneName + ".json";

        //save this into a file
        File.WriteAllText(saveLocation, sceneJSON);

	}


	private void RefreshDatabase()
	{
		#if UNITY_EDITOR
        //refresh the project view if we are in the editor only
        AssetDatabase.Refresh();
		#endif
	}


}
