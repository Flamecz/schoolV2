using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "SavePlayerImages", menuName = "SavePlayerImages")]
public class SavePlayerImages : ScriptableObject
{
    public Sprite player, enemy;
    public Sprite cityPicture;
    public string cityName;
}
