using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceObject : MonoBehaviour
{
    public Claim BeClaimed;
    public Material taken;
    private void Update()
    {
        if(BeClaimed.claimed)
        {
            gameObject.GetComponent<MeshRenderer>().material = taken;
        }
    }

}
