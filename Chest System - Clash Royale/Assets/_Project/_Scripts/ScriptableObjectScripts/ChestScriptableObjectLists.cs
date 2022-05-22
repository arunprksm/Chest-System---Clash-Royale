using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "ChestScriptableObjectLists",menuName = "ScriptableObjects/Create Chest Scriptable Object Lists")]
public class ChestScriptableObjectLists : ScriptableObject
{

    [System.Serializable]
    public class ChestLayout
    {
        public ChestTypes ChestTypes;
        public ChestScriptableObject ChestScriptableObject;
    }
    public ChestLayout[] ChestLayouts;
}
