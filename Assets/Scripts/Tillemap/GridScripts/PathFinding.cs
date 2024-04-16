using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class PathFinding
{
        private const int MOVE_STRAIGHT_COST = 10;
        private const int MOVE_DIAGONAL_COST = 14;
        public int settedValue;
        public static PathFinding Instance { get; private set; }

        public Grid<PathNode> grid;
        private int Remove;
        private List<PathNode> openList;
        private List<PathNode> closedList;

        public PathFinding(int width, int height)
        {
            Instance = this;
            grid = new Grid<PathNode>(width, height, 10f, Vector3.zero, (Grid<PathNode> g, int x, int y) => new PathNode(g, x, y));
        }

        public Grid<PathNode> GetGrid()
        {
            return grid;
        }

        public List<Vector3> FindPath(Vector3 startWorldPosition, Vector3 endWorldPosition)
        {
            grid.GetXY(startWorldPosition, out int startX, out int startY);
            grid.GetXY(endWorldPosition, out int endX, out int endY);

            List<PathNode> path = FindPath(startX, startY, endX, endY);
            if (path == null)
            {
                return null;
            }
            else
            {;

                List<Vector3> vectorPath = new List<Vector3>();
                foreach (PathNode pathNode in path)
                {
                    vectorPath.Add(new Vector3(pathNode.x, pathNode.y) * grid.GetCellSize() + Vector3.one * grid.GetCellSize() * .5f);
                }
                return vectorPath;
            }
        }

        public List<PathNode> FindPath(int startX, int startY, int endX, int endY)
        {
            PathNode startNode = grid.GetGridObject(startX, startY);
            PathNode endNode = grid.GetGridObject(endX, endY);

            if (startNode == null || endNode == null)
            {
                // Invalid Path
                return null;
            }

            openList = new List<PathNode> { startNode };
            closedList = new List<PathNode>();

            for (int x = 0; x < grid.GetWidth(); x++)
            {
                for (int y = 0; y < grid.GetHeight(); y++)
                {
                    PathNode pathNode = grid.GetGridObject(x, y);
                    pathNode.gCost = settedValue;
                    pathNode.CalculateFCost();
                    pathNode.cameFromNode = null;
                }
            }

         startNode.gCost = 0;
         startNode.hCost = CalculateDistanceCost(startNode, endNode);
         startNode.CalculateFCost();

         // Store the nodes that are already processed to avoid redundant operations
         HashSet<PathNode> processedNodes = new HashSet<PathNode>();
 
         PathDebug.Instance.ClearSnapshots();
        PathDebug.Instance.TakeSnapshot(grid, startNode, openList, closedList);

        while (openList.Count > 0)
        {
            PathNode currentNode = GetLowestFCostNode(openList);
            if (currentNode == endNode)
            {
                // Reached final node
                PathDebug.Instance.TakeSnapshot(grid, currentNode, openList, closedList);
                PathDebug.Instance.TakeSnapshotFinalPath(grid, CalculatePath(endNode));
                return CalculatePath(endNode);
            }

            openList.Remove(currentNode);
            closedList.Add(currentNode);
            processedNodes.Add(currentNode);

            foreach (PathNode neighbourNode in GetNeighbourList(currentNode))
            {
                if (processedNodes.Contains(neighbourNode))
                    continue;

                int tentativeGCost = currentNode.gCost + CalculateDistanceCost(currentNode, neighbourNode);
                if (tentativeGCost < neighbourNode.gCost)
                {
                    neighbourNode.cameFromNode = currentNode;
                    neighbourNode.gCost = tentativeGCost;
                    neighbourNode.hCost = CalculateDistanceCost(neighbourNode, endNode);
                    neighbourNode.CalculateFCost();

                    if (!openList.Contains(neighbourNode))
                    {
                        openList.Add(neighbourNode);
                    }
                }
                PathDebug.Instance.TakeSnapshot(grid, currentNode, openList, closedList);
            }
        }
        return null;
    }

        private List<PathNode> GetNeighbourList(PathNode currentNode)
        {
            List<PathNode> neighbourList = new List<PathNode>();

            if (currentNode.x - 1 >= 0)
            {

                neighbourList.Add(GetNode(currentNode.x - 1, currentNode.y));

                if (currentNode.y - 1 >= 0) neighbourList.Add(GetNode(currentNode.x - 1, currentNode.y - 1));

                if (currentNode.y + 1 < grid.GetHeight()) neighbourList.Add(GetNode(currentNode.x - 1, currentNode.y + 1));
            }
            if (currentNode.x + 1 < grid.GetWidth())
            {

                neighbourList.Add(GetNode(currentNode.x + 1, currentNode.y));

                if (currentNode.y - 1 >= 0) neighbourList.Add(GetNode(currentNode.x + 1, currentNode.y - 1));

                if (currentNode.y + 1 < grid.GetHeight()) neighbourList.Add(GetNode(currentNode.x + 1, currentNode.y + 1));
            }

            if (currentNode.y - 1 >= 0) neighbourList.Add(GetNode(currentNode.x, currentNode.y - 1));

            if (currentNode.y + 1 < grid.GetHeight()) neighbourList.Add(GetNode(currentNode.x, currentNode.y + 1));

            return neighbourList;
        }

        public PathNode GetNode(int x, int y)
        {
            return grid.GetGridObject(x, y);
        }

        private List<PathNode> CalculatePath(PathNode endNode)
        {
            List<PathNode> path = new List<PathNode>();
            path.Add(endNode);
            PathNode currentNode = endNode;
            while (currentNode.cameFromNode != null)
            {
                path.Add(currentNode.cameFromNode);
                currentNode = currentNode.cameFromNode;
            }
            path.Reverse();
        Remove = path.Count;
        return path;
        }

        private int CalculateDistanceCost(PathNode a, PathNode b)
        {
            int xDistance = Mathf.Abs(a.x - b.x);
            int yDistance = Mathf.Abs(a.y - b.y);
            int remaining = Mathf.Abs(xDistance - yDistance);
            return MOVE_DIAGONAL_COST * Mathf.Min(xDistance, yDistance) + MOVE_STRAIGHT_COST * remaining;
        }

    private PathNode GetLowestFCostNode(List<PathNode> pathNodeList)
    {
        BinarySearchTree<PathNode> bst = new BinarySearchTree<PathNode>();

        foreach (PathNode node in pathNodeList)
        {
            bst.Insert(node, node.fCost);
        }

        return bst.RemoveMin();
    }

    public void SetSettedValue(int value)
    {
        settedValue = value;
    }
    public void RemoveCost()
    {
        settedValue -= Remove * 14;
    }
}

public class BinaryTreeNode<T>
{
    public T Data { get; set; }
    public double Priority { get; set; }
    public BinaryTreeNode<T> Left { get; set; }
    public BinaryTreeNode<T> Right { get; set; }

    public BinaryTreeNode(T data, double priority)
    {
        Data = data;
        Priority = priority;
    }
}
public class BinarySearchTree<T>
{
    private BinaryTreeNode<T> _root;

    public void Insert(T data, double priority)
    {
        _root = Insert(_root, data, priority);
    }

    private BinaryTreeNode<T> Insert(BinaryTreeNode<T> node, T data, double priority)
    {
        if (node == null)
        {
            return new BinaryTreeNode<T>(data, priority);
        }

        if (priority < node.Priority)
        {
            node.Left = Insert(node.Left, data, priority);
        }
        else
        {
            node.Right = Insert(node.Right, data, priority);
        }

        return node;
    }

    public T RemoveMin()
    {
        if (_root == null)
        {
            throw new InvalidOperationException("Binary search tree is empty");
        }

        var minNode = FindMinNode(_root);
        _root = RemoveMin(_root);
        return minNode.Data;
    }

    private BinaryTreeNode<T> FindMinNode(BinaryTreeNode<T> node)
    {
        while (node.Left != null)
        {
            node = node.Left;
        }
        return node;
    }

    private BinaryTreeNode<T> RemoveMin(BinaryTreeNode<T> node)
    {
        if (node.Left == null)
        {
            return node.Right;
        }
        node.Left = RemoveMin(node.Left);
        return node;
    }

    public bool IsEmpty()
    {
        return _root == null;
    }
}
