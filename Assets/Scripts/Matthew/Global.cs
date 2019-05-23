using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "GlobalBlackboard")]
public class Global : ScriptableObject
{

    public void CreatePlayer(GameObject prefab)
    {
        Instantiate(prefab);
    }

}
