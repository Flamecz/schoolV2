using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CameraMovement : MonoBehaviour
{
    public float panSpeed = 20f; // Speed of camera movement
    public float panBorderThickness = 10f; // Distance from edge of screen to start moving
    public Vector2 minBoundary; // Minimum boundary of the map
    public Vector2 maxBoundary; // Maximum boundary of the map
    public GameObject[] coliders;
    public GameObject playerMovement;

    private Camera orthographicCamera;
    public bool isInRange;
    public Claim[] questObject;
    public Quest quest;
    public int SendToQuest;
    public SaveDataObject SDO;
    public bool OnWay;
    private GameObject holdObject;
    void Start()
    {
        orthographicCamera = GetComponent<Camera>();
        float x = PlayerPrefs.GetFloat("PosX");
        float y = PlayerPrefs.GetFloat("PosY");

        orthographicCamera.transform.position = new Vector3(x, y, orthographicCamera.transform.position.z);
    }

    void Update()
    {
        // Move camera based on keyboard input (WASD)
        Vector3 keyboardInput = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        Vector3 panDirection = keyboardInput.normalized;

        // Move camera based on mouse position near screen edges
        if (Input.mousePosition.x < panBorderThickness && transform.position.x > minBoundary.x)
        {
            panDirection += Vector3.left;
        }
        if (Input.mousePosition.x > Screen.width - panBorderThickness && transform.position.x < maxBoundary.x)
        {
            panDirection += Vector3.right;
        }
        if (Input.mousePosition.y < panBorderThickness && transform.position.y > minBoundary.y)
        {
            panDirection += Vector3.down;
        }
        if (Input.mousePosition.y > Screen.height - panBorderThickness && transform.position.y < maxBoundary.y)
        {
            panDirection += Vector3.up;
        }

        // Normalize the pan direction to prevent faster diagonal movement
        panDirection.Normalize();

        // Convert screen movement to world movement
        Vector3 pan = orthographicCamera.ScreenToWorldPoint(panDirection) - orthographicCamera.ScreenToWorldPoint(Vector3.zero);

        // Move the camera, clamping the position within boundaries
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x + pan.x * panSpeed * Time.deltaTime, minBoundary.x, maxBoundary.x),
            Mathf.Clamp(transform.position.y + pan.y * panSpeed * Time.deltaTime, minBoundary.y, maxBoundary.y),
            transform.position.z
        );

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            OnWay = true;
            if (Physics.Raycast(ray, out hit))
            {
                GameObject hitObject = hit.collider.gameObject;
                Debug.Log("Hit object: " + hitObject.name);
                float distanceToTarget = Vector3.Distance(playerMovement.transform.position, hitObject.transform.position);
                Debug.Log(distanceToTarget);
                if (hitObject.tag == "hrad" && distanceToTarget < 17)
                {

                    if(FindObjectOfType<QuestControll>().Selected.QG.goalType == GoalType.GetTo)
                    {
                        FindObjectOfType<QuestControll>().Selected.QG.QuestGatherd();
                        bool isdone = FindObjectOfType<QuestControll>().Selected.QG.QuestDone();
                        if(isdone)
                        {
                            FindObjectOfType<QuestControll>().FinnishedQuest();
                        }
                    }
                    else
                    {
                        FindObjectOfType<AudioManager>().Stop("HeroesInWorld");
                        if (SDO.CityType == SaveDataObject.type.Castel)
                        {
                            FindObjectOfType<AudioManager>().Play("Castel");
                        }
                        else if (SDO.CityType == SaveDataObject.type.Castel)
                        {
                            FindObjectOfType<AudioManager>().Play("Rampart");
                        }
                        else if (SDO.CityType == SaveDataObject.type.Castel)
                        {
                            FindObjectOfType<AudioManager>().Play("undeadCityTheme");
                        }
                        SceneManager.LoadScene(1);
                    }
                }
                else if(hitObject.tag == "Suroviny" && distanceToTarget < 17)
                {
                    hitObject.GetComponent<ResourceObject>();
                    if(FindObjectOfType<QuestControll>().Selected.QG.goalType == GoalType.Gather)
                    {
                        FindObjectOfType<QuestControll>().Selected.QG.QuestGatherd();
                        
                    }
                    FindObjectOfType<ResourceManager>().ModifyResources("Gems", 1);
                    Destroy(hitObject.gameObject);
                }
                else if (hitObject.tag == "Suroviny" && distanceToTarget > 17)
                {
                    hitObject.GetComponent<ResourceObject>();
                    if (FindObjectOfType<QuestControll>().Selected.QG.goalType == GoalType.Gather)
                    {
                        FindObjectOfType<QuestControll>().Selected.QG.QuestGatherd();

                    }
                    FindObjectOfType<ResourceManager>().ModifyResources("Gems", 1);
                    holdObject = hitObject.gameObject;
                }
                else if (hitObject.tag == "Enemy" && distanceToTarget < 17)
                {
                    SceneManager.LoadScene(3);
                    FindObjectOfType<AudioManager>().Play("Battle");
                }
            }
        }
        if(!OnWay)
        {
            if(holdObject != null)
            {
                Destroy(holdObject);
                holdObject = null;
                OnWay = false;
            }
        }
    }
}
