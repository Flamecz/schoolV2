using UnityEngine;

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
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction);

            if (hit.collider != null)
            {
                GameObject tile = hit.collider.gameObject;
                Vector3Int tilePosition = GetTilePosition(tile);
                MoveGameElement(tilePosition);
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

        return new Vector3Int(-1, -1, 0);
    }

    private void MoveGameElement(Vector3Int tilePosition)
    {
        GameObject gameElement = transform.GetChild(0).gameObject;
        if (gameElement != null)
        {
            gameElement.transform.position = CellToWorld(tilePosition);
        }
    }
}
