using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceIfColected : MonoBehaviour
{
    public Claim claim;
    private void Awake()
    {
        if(claim.claimed)
        {
            Destroy(gameObject);
        }
    }
}
