using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBlueprint : MonoBehaviour
{
    private RaycastHit hit;
    public GameObject Blueprint;
    Vector3 movePoint;

    private void Start()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit, 5000f, (1 << 8)))
        {
            transform.position = hit.point;
        }
    }
    private void Update()
    {
         Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray,out hit , 5000f, (1<< 8)))
            {
            transform.position = hit.point;
        }
        if(Input.GetMouseButton(0))
        {
            Instantiate(Blueprint, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
