/*
 * Entity is how we serialize GameObjects by name, position, and static status. 
 * Using this to match with a prefab then instantiate the prefab would be the best way since we can't serialize all the data on a GameObject
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity {

    public Vector3 m_position;
    public string m_name;
    public bool m_static;
}
