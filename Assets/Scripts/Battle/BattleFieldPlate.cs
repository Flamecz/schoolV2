using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleFieldPlate : MonoBehaviour
{

    public int selectedMap;
    public int width, height;
    [SerializeField] private PathDebug pathDebug;
    [SerializeField] private PathVisual pathVisual;
    [SerializeField] public FieldMovement unitPathfinding;
    public int set;
    public PathFinding pathfinding;

    public MapManager mapManager;
    public bool EnemyTurn;
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
