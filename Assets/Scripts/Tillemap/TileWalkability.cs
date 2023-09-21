using UnityEngine;
using UnityEngine.Tilemaps;

public class TileWalkability : MonoBehaviour
{
    public Tilemap walkableTilemap; // Reference to the walkable Tilemap
    public float moveSpeed = 5.0f;
    public Camera cam;

    private Vector3 targetPosition;
    private bool isMoving = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Cast a ray from the mouse click position into the world
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Debug.DrawRay(cam.transform.position,ray.direction);
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("Ray hit at point: " + hit.point);

                // Check if the clicked point is on a walkable tile
                Vector3Int cellPosition = walkableTilemap.WorldToCell(hit.point);
                TileBase tile = walkableTilemap.GetTile(cellPosition);

                if (tile != null)
                {
                    Debug.Log("Clicked on a walkable tile.");

                    // Calculate the target position based on the clicked tile
                    targetPosition = walkableTilemap.GetCellCenterWorld(cellPosition);
                    isMoving = true;
                }
                else
                {
                    Debug.Log("Clicked on a non-walkable tile.");
                }
            }
            else
            {
                Debug.Log("Ray did not hit anything.");
            }
        }

        if (isMoving)
        {
            // Move towards the target position
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

            // Check if we've reached the target position
            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                isMoving = false;
            }
        }
    }
}


