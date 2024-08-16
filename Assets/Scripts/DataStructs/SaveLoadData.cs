using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SaveLoadData", menuName = "SaveLoadData")]
public class SaveLoadData : ScriptableObject
{
    public bool sceneFound;
    public bool SavedQuit;
}
