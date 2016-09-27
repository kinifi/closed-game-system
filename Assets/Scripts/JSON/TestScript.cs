using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TinyJSON;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class TestScript : MonoBehaviour {

    //the list of GameObjects we need to serialize
    public List<Entity> m_Entities = new List<Entity>();

    /// Context Menu allows you to right click a script and execute it from the inspector
    [ContextMenu("Json Class Test")]
    public void JSONTest()
    {
        //Create 5 GameObjects
        for (int i = 0; i < 5; i++)
        {
            //create a new object
            Entity newEntity = new Entity();
            //set the name. 
            newEntity.m_name = "name" + i;
            //set the position
            newEntity.m_position.x = i;
            newEntity.m_position.y = i;
            newEntity.m_position.z = i;
            //this object will not be static
            newEntity.m_static = false;
            //add the new Entity to the list of Entities 
            m_Entities.Add(newEntity);
        }

        //serialize all these objects into a pretty json string
        string testClassJson = JSON.Dump(m_Entities, true);

        //create a save location thats inside of the Assets folder
        string saveLocation = Application.dataPath + "/" + "JSONTest.json";

        //save this into a file
        File.WriteAllText(saveLocation, testClassJson);

#if UNITY_EDITOR
        //refresh the project view if we are in the editor only
        AssetDatabase.Refresh();
#endif

    }

}
