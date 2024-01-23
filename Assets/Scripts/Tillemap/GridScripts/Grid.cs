using UnityEngine;
using UnityEngine.SceneManagement;
public class Grid : MonoBehaviour
{
    public int width = 10;
    public int height = 10;
    public GameObject tilePrefab;
    public float cellSizeModifier = 1f;
    private GameObject[,] gridArray;

    void Start()
    {
        gridArray = new GameObject[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                GameObject tile = Instantiate(tilePrefab, CellToWorld(new Vector3Int(x, y, 0)), Quaternion.identity);
                tile.transform.parent = transform;
                gridArray[x, y] = tile;
            }
        }
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            // Handle continuous input for movement
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null)
            {
                Debug.Log("yep");
                GameObject hitObject = hit.collider.gameObject;
                if (hitObject.CompareTag("hrad"))
                {
                    Debug.Log("Done");
                    SceneManager.LoadScene(1);
                }
                else
                {
                    Debug.Log("sup");
                    GameObject tile = hit.collider.gameObject;
                    Vector3Int tilePosition = GetTilePosition(hitObject);
                    MovePlayerToTileCenter(tilePosition);
                }

            }
        }
    }


    public Vector3 CellToWorld(Vector3 cellPosition)
    {
        return new Vector3(cellPosition.x * cellSizeModifier + cellSizeModifier / 2, cellPosition.y * cellSizeModifier + cellSizeModifier / 2, 0);
    }


    public Vector3Int GetTilePosition(GameObject tile)
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (gridArray[x, y] == tile)
                {
                    return new Vector3Int(x, y, 0);
                }
            }
        }

        return new Vector3Int(0, 0, 0);
    }

    private void MoveGameElement(Vector3Int tilePosition)
    {
        GameObject gameElement = transform.GetChild(0).gameObject;
        if (gameElement != null)
        {
            gameElement.transform.position = CellToWorld(tilePosition);
        }
    }
    private void MovePlayerToTileCenter(Vector3Int tilePosition)
    {
        GameObject player = transform.GetChild(0).gameObject;
        if (player != null)
        {
            Vector3 targetPosition = CellToWorld(tilePosition);
            Debug.Log("Moving to: " + targetPosition);

            // Snap the player to the center of the clicked tile
            player.transform.position = new Vector3(targetPosition.x, targetPosition.y, player.transform.position.z);

            Debug.Log("Player position after movement: " + player.transform.position);
        }
    }

}
