using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationCreditsEvent : MonoBehaviour
{
     public void TriggerEvent()
    {
        FindObjectOfType<MenuUIContorler>().SetMainCanvas();
    }
}
