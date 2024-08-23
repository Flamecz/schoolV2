using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PathVisual : MonoBehaviour
{

    public Grid<PathNode> grid;
    private Mesh mesh;
    private bool updateMesh;
    public GameObject ForestTile;
    public GameObject HradTile;
    public GameObject Buildings,Resources;
    public GameObject Enemy;
    public InvetorySaver enemyUnits;
    public Claim[] claimedResource;
    public Claim[] claimedBuilding;
    public Material[] nonClaimedbuild;
    public Material[] claimedbuild;
    public BuildingImage buildingImage;
    public DataForEnemy[] DataForEnemy;
    public EnemysToRemove[] enemysToRemove;
    public WhatDelete what;
    private int next = 0;
    private int enemyNext;
    private int nextBuilding;
    private void Awake()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
    }

    public void SetGrid(Grid<PathNode> grid)
    {
        this.grid = grid;
        UpdateVisual();
        grid.OnGridObjectChanged += Grid_OnGridValueChanged;
    }

    private void Grid_OnGridValueChanged(object sender, Grid<PathNode>.OnGridObjectChangedEventArgs e)
    {
        updateMesh = true;
    }

    private void LateUpdate()
    {
        if (updateMesh)
        {
            updateMesh = false;
            UpdateVisual();
        }
    }

    private void UpdateVisual()
    {
        CreateEmptyMeshArrays(grid.GetWidth() * grid.GetHeight(), out Vector3[] vertices, out Vector2[] uv, out int[] triangles);

        for (int x = 0; x < grid.GetWidth(); x++)
        {
            for (int y = 0; y < grid.GetHeight(); y++)
            {
                int index = x * grid.GetHeight() + y;
                Vector3 quadSize = new Vector3(1, 1) * grid.GetCellSize();

                PathNode pathNode = grid.GetGridObject(x, y);

                if (pathNode.isWalkable)
                {
                    quadSize = Vector3.zero;
                }

                AddToMeshArrays(vertices, uv, triangles, index, grid.GetWorldPosition(x, y) + quadSize * .5f, 0f, quadSize, Vector2.zero, Vector2.zero);
            }
        }

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
    }

    private static Quaternion[] cachedQuaternionEulerArr;
    private static void CacheQuaternionEuler()
    {
        if (cachedQuaternionEulerArr != null) return;
        cachedQuaternionEulerArr = new Quaternion[360];
        for (int i = 0; i < 360; i++)
        {
            cachedQuaternionEulerArr[i] = Quaternion.Euler(0, 0, i);
        }
    }
    private static Quaternion GetQuaternionEuler(float rotFloat)
    {
        int rot = Mathf.RoundToInt(rotFloat);
        rot = rot % 360;
        if (rot < 0) rot += 360;
        //if (rot >= 360) rot -= 360;
        if (cachedQuaternionEulerArr == null) CacheQuaternionEuler();
        return cachedQuaternionEulerArr[rot];
    }
    public static void CreateEmptyMeshArrays(int quadCount, out Vector3[] vertices, out Vector2[] uvs, out int[] triangles)
    {
        vertices = new Vector3[4 * quadCount];
        uvs = new Vector2[4 * quadCount];
        triangles = new int[6 * quadCount];
    }

    public static void AddToMeshArrays(Vector3[] vertices, Vector2[] uvs, int[] triangles, int index, Vector3 pos, float rot, Vector3 baseSize, Vector2 uv00, Vector2 uv11)
    {
        //Relocate vertices
        int vIndex = index * 4;
        int vIndex0 = vIndex;
        int vIndex1 = vIndex + 1;
        int vIndex2 = vIndex + 2;
        int vIndex3 = vIndex + 3;

        baseSize *= .5f;

        bool skewed = baseSize.x != baseSize.y;
        if (skewed)
        {
            vertices[vIndex0] = pos + GetQuaternionEuler(rot) * new Vector3(-baseSize.x, baseSize.y);
            vertices[vIndex1] = pos + GetQuaternionEuler(rot) * new Vector3(-baseSize.x, -baseSize.y);
            vertices[vIndex2] = pos + GetQuaternionEuler(rot) * new Vector3(baseSize.x, -baseSize.y);
            vertices[vIndex3] = pos + GetQuaternionEuler(rot) * baseSize;
        }
        else
        {
            vertices[vIndex0] = pos + GetQuaternionEuler(rot - 270) * baseSize;
            vertices[vIndex1] = pos + GetQuaternionEuler(rot - 180) * baseSize;
            vertices[vIndex2] = pos + GetQuaternionEuler(rot - 90) * baseSize;
            vertices[vIndex3] = pos + GetQuaternionEuler(rot - 0) * baseSize;
        }

        //Relocate UVs
        uvs[vIndex0] = new Vector2(uv00.x, uv11.y);
        uvs[vIndex1] = new Vector2(uv00.x, uv00.y);
        uvs[vIndex2] = new Vector2(uv11.x, uv00.y);
        uvs[vIndex3] = new Vector2(uv11.x, uv11.y);

        //Create triangles
        int tIndex = index * 6;

        triangles[tIndex + 0] = vIndex0;
        triangles[tIndex + 1] = vIndex3;
        triangles[tIndex + 2] = vIndex1;

        triangles[tIndex + 3] = vIndex1;
        triangles[tIndex + 4] = vIndex3;
        triangles[tIndex + 5] = vIndex2;
    }
    public void UpdateGridFrom2DString(string[] mapLayout)
    {
        if (grid == null || mapLayout == null)
        {
            Debug.LogError("Grid or mapLayout is null");
            return;
        }

        if (grid.GetWidth() != mapLayout[1].Length || grid.GetHeight() != mapLayout.Length)
        {
            Debug.LogError("Grid dimensions do not match mapLayout dimensions");
            return;
        }

        for (int x = 0; x < grid.GetWidth(); x++)
        {
            for (int y = 0; y < grid.GetHeight(); y++)
            {
                PathNode node = grid.GetGridObject(x, y);
                char cellChar = mapLayout[y][x];
                bool isWalkable = cellChar == '.';
                node.SetIsWalkable(isWalkable);
                bool isWalkable1 = cellChar == 'X';
                node.SetIsWalkable(!isWalkable1);
                if(isWalkable1)
                {
                    var rot = new Vector3((x * 10) + 5, (y * 10) + 5, 0f);
                    Instantiate(ForestTile, rot, Quaternion.identity);
                }
                if (cellChar == 'H')
                {
                    var rot = new Vector3((x * 10) + 5, (y * 10) + 5, 0f);
                    GameObject go = Instantiate(HradTile, rot, Quaternion.Euler(new Vector3(0, 180, 0)));
                    go.AddComponent<ChangeCity>();
                    go.GetComponent<ChangeCity>().buildingImage = buildingImage;
                }
                if (cellChar == 'R')
                {
                    var rot = new Vector3((x * 10) + 5, (y * 10) + 5, 0f);
                    GameObject go = Instantiate(Resources, rot, Quaternion.Euler(new Vector3(0, 180, 0)));
                    go.GetComponent<ResourceIfColected>().claim = claimedResource[next];
                    int lol = Random.Range(0, 6);
                    if(lol == 0)
                    {
                        go.tag = "SurovinyG";
                    }
                    if (lol == 1)
                    {
                        go.tag = "SurovinyGe";
                    }
                    if (lol == 2)
                    {
                        go.tag = "SurovinyM";
                    }
                    if (lol == 3)
                    {
                        go.tag = "SurovinyS";
                    }
                    if (lol == 4)
                    {
                        go.tag = "SurovinyI";
                    }
                    if (lol == 5)
                    {
                        go.tag = "SurovinySt";
                    }
                    if (lol == 6)
                    {
                        go.tag = "SurovinyW";
                    }
                    next++;
                }
                if (cellChar == 'B')
                {
                    var rot = new Vector3((x * 10) + 5, (y * 10) + 5, 0f);
                    GameObject go = Instantiate(Buildings, rot, Quaternion.Euler(new Vector3(0, 180, 0)));
                    node.SetIsWalkable(false);
                    if (nextBuilding == 0)
                    {
                        go.tag = "BuildingG";
                        go.GetComponent<ResourceObject>().BeClaimed = claimedBuilding[nextBuilding];
                        go.GetComponent<ResourceObject>().notTaken = nonClaimedbuild[nextBuilding];
                        go.GetComponent<ResourceObject>().taken = claimedbuild[nextBuilding];
                        if(claimedBuilding[nextBuilding].claimed)
                        {
                            go.GetComponent<MeshRenderer>().material = claimedbuild[nextBuilding];
                        }
                        else
                        {
                            go.GetComponent<MeshRenderer>().material = nonClaimedbuild[nextBuilding];
                        }
                    }
                    if (nextBuilding == 1)
                    {
                        go.tag = "BuildingGe";
                        go.GetComponent<ResourceObject>().BeClaimed = claimedBuilding[nextBuilding];
                        go.GetComponent<ResourceObject>().notTaken = nonClaimedbuild[nextBuilding];
                        go.GetComponent<ResourceObject>().taken = claimedbuild[nextBuilding];
                        if (claimedBuilding[nextBuilding].claimed)
                        {
                            go.GetComponent<MeshRenderer>().material = claimedbuild[nextBuilding];
                        }
                        else
                        {
                            go.GetComponent<MeshRenderer>().material = nonClaimedbuild[nextBuilding];
                        }
                    }
                    if (nextBuilding == 2)
                    {
                        go.tag = "BuildingM";
                        go.GetComponent<ResourceObject>().BeClaimed = claimedBuilding[nextBuilding];
                        go.GetComponent<ResourceObject>().notTaken = nonClaimedbuild[nextBuilding];
                        go.GetComponent<ResourceObject>().taken = claimedbuild[nextBuilding];
                        if (claimedBuilding[nextBuilding].claimed)
                        {
                            go.GetComponent<MeshRenderer>().material = claimedbuild[nextBuilding];
                        }
                        else
                        {
                            go.GetComponent<MeshRenderer>().material = nonClaimedbuild[nextBuilding];
                        }
                    }
                    if (nextBuilding == 3)
                    {
                        go.tag = "BuildingS";
                        go.GetComponent<ResourceObject>().BeClaimed = claimedBuilding[nextBuilding];
                        go.GetComponent<ResourceObject>().notTaken = nonClaimedbuild[nextBuilding];
                        go.GetComponent<ResourceObject>().taken = claimedbuild[nextBuilding];
                        if (claimedBuilding[nextBuilding].claimed)
                        {
                            go.GetComponent<MeshRenderer>().material = claimedbuild[nextBuilding];
                        }
                        else
                        {
                            go.GetComponent<MeshRenderer>().material = nonClaimedbuild[nextBuilding];
                        }
                    }
                    if (nextBuilding == 4)
                    {
                        go.tag = "BuildingI";
                        go.GetComponent<ResourceObject>().BeClaimed = claimedBuilding[nextBuilding];
                        go.GetComponent<ResourceObject>().notTaken = nonClaimedbuild[nextBuilding];
                        go.GetComponent<ResourceObject>().taken = claimedbuild[nextBuilding];
                        if (claimedBuilding[nextBuilding].claimed)
                        {
                            go.GetComponent<MeshRenderer>().material = claimedbuild[nextBuilding];
                        }
                        else
                        {
                            go.GetComponent<MeshRenderer>().material = nonClaimedbuild[nextBuilding];
                        }
                    }
                    if (nextBuilding == 5)
                    {
                        go.tag = "BuildingSt";
                        go.GetComponent<ResourceObject>().BeClaimed = claimedBuilding[nextBuilding];
                        go.GetComponent<ResourceObject>().notTaken = nonClaimedbuild[nextBuilding];
                        go.GetComponent<ResourceObject>().taken = claimedbuild[nextBuilding];
                        if (claimedBuilding[nextBuilding].claimed)
                        {
                            go.GetComponent<MeshRenderer>().material = claimedbuild[nextBuilding];
                        }
                        else
                        {
                            go.GetComponent<MeshRenderer>().material = nonClaimedbuild[nextBuilding];
                        }
                    }
                    if (nextBuilding == 6)
                    {
                        go.tag = "BuildingW";
                        go.GetComponent<ResourceObject>().BeClaimed = claimedBuilding[nextBuilding];
                        go.GetComponent<ResourceObject>().notTaken = nonClaimedbuild[nextBuilding];
                        go.GetComponent<ResourceObject>().taken = claimedbuild[nextBuilding];
                        if (claimedBuilding[nextBuilding].claimed)
                        {
                            go.GetComponent<MeshRenderer>().material = claimedbuild[nextBuilding];
                        }
                        else
                        {
                            go.GetComponent<MeshRenderer>().material = nonClaimedbuild[nextBuilding];
                        }
                    }
                    nextBuilding++;
                }
                if(cellChar == 'E')
                {
                    var rot = new Vector3((x * 10) + 5, (y * 10) + 5, 0f);
                    GameObject go = Instantiate(Enemy, rot, Quaternion.Euler(new Vector3(0, 180, 0)));
                    go.GetComponent<EnemyUnitsContol>().unitStructs = DataForEnemy[enemyNext];
                    go.GetComponent<EnemyUnitsContol>().enemyUnits = enemyUnits;
                    go.GetComponent<EnemyUnitsContol>().EnemyRemove = enemysToRemove[enemyNext];
                    go.GetComponent<EnemyUnitsContol>().delete = enemyNext;
                    go.GetComponent<EnemyUnitsContol>().whatDelete = what;
                    enemyNext++;
                }
            }
        }
    }
}
