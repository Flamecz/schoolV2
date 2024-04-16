using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Days", menuName = "Days")]
public class Days : ScriptableObject
{
    public int days;
    public int weeks;
    private void Awake()
    {
        days = PlayerPrefs.GetInt("den");
    }
}
