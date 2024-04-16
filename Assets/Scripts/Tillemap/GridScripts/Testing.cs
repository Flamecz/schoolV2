using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Testing : MonoBehaviour {

    public int selectedMap;
    public int width, height;
    [SerializeField] private PathDebug pathDebug;
    [SerializeField] public PathVisual pathVisual;
    [SerializeField] private PlayerMovement characterPathfinding;
    public PathFinding pathfinding;
    public int set;
    public MapManager mapManager;

    private void Start()
    {
        pathfinding = new PathFinding(width, height);
        pathDebug.Setup(pathfinding.GetGrid());
        pathVisual.SetGrid(pathfinding.GetGrid());
        pathfinding.settedValue = set;
        string[] mapLayout = MapManager.Instance.GetMapLayout(selectedMap);
        pathVisual.UpdateGridFrom2DString(mapLayout);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mouseWorldPosition = GetMouseWorldPosition();
            pathfinding.GetGrid().GetXY(mouseWorldPosition, out int x, out int y);
            List<PathNode> path = pathfinding.FindPath(0, 0, x, y);
            if (path != null)
            {
                for (int i = 0; i < path.Count - 1; i++)
                {
                    Debug.DrawLine(new Vector3(path[i].x, path[i].y) * 10f + Vector3.one * 5f, new Vector3(path[i + 1].x, path[i + 1].y) * 10f + Vector3.one * 5f, Color.green, 5f);
                }
            }
            if(pathfinding.GetNode(x,y).isWalkable)
            {
                characterPathfinding.SetTargetPosition(mouseWorldPosition);
                pathfinding.RemoveCost();
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Vector3 mouseWorldPosition = GetMouseWorldPosition();
            pathfinding.GetGrid().GetXY(mouseWorldPosition, out int x, out int y);
            pathfinding.GetNode(x, y).SetIsWalkable(!pathfinding.GetNode(x, y).isWalkable);
        }
    }
    public static Vector3 GetMouseWorldPosition()
    {
        Vector3 vec = GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
        vec.z = 0f;
        return vec;
    }
    public static Vector3 GetMouseWorldPositionWithZ()
    {
        return GetMouseWorldPositionWithZ(Input.mousePosition, Camera.main);
    }
    public static Vector3 GetMouseWorldPositionWithZ(Camera worldCamera)
    {
        return GetMouseWorldPositionWithZ(Input.mousePosition, worldCamera);
    }
    public static Vector3 GetMouseWorldPositionWithZ(Vector3 screenPosition, Camera worldCamera)
    {
        Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
        return worldPosition;
    }
}
