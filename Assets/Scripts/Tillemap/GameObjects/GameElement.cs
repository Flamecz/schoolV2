using UnityEngine;
public class GameElement : MonoBehaviour
{
    public Grid grid;
    private int x;
    private int y;
    public int stamina = 1000; // Stamina variable
    private void Update()
    {
        FindObjectOfType<CameraController>().playerTransform = gameObject.GetComponent<Transform>();
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                GameObject tile = hit.collider.gameObject;
                Vector3Int targetTilePosition = grid.GetTilePosition(tile);
                int distance = CalculateDistance(targetTilePosition);   

                if (distance <= stamina)
                {
                    x = targetTilePosition.x;
                    y = targetTilePosition.y;
                    MoveToTile();
                    stamina -= distance; // Decrease stamina by the distance traveled
                }
            }

            // Debug raycast
            Debug.DrawRay(ray.origin, ray.direction * 10, Color.red);
        }
    }



    private void MoveToTile()
    {
        Vector3 newPosition = grid.CellToWorld(new Vector3Int(x, y, 0)) + new Vector3(grid.cellSizeModifier / 2, grid.cellSizeModifier / 2, 0);
        transform.position = newPosition;
    }

    private int CalculateDistance(Vector3Int targetTilePosition)
    {
        return Mathf.Abs(x - targetTilePosition.x) + Mathf.Abs(y - targetTilePosition.y);
    }
    public void SavePlayerData()
    {
        PlayerData playerData = new PlayerData(transform.position, transform.rotation);
        // Save the playerData to a file or PlayerPrefs
    }
}

