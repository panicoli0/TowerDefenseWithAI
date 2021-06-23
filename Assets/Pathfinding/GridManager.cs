using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    [SerializeField] Vector2Int gridSize;
    [SerializeField] int unityGridSize = 10;

    Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();

    public Dictionary<Vector2Int, Node> Grid { get { return grid; } }
    public int UnityGridSize { get { return unityGridSize; } }

    void Awake()
    {
        CreateGrid();
    }

    public Node GetNode(Vector2Int coordinates)
    {
        if(grid.ContainsKey(coordinates))
        {
            return grid[coordinates];
        }

        return null;
    }

    void CreateGrid()
    {
        for(int x = 0; x < gridSize.x; x++)
        {
            for(int y = 0; y < gridSize.y; y++)
            {
                Vector2Int coordinates = new Vector2Int(x,y);
                grid.Add(coordinates, new Node(coordinates, true));
            }
        }
    }

    public void BlockNodes(Vector2Int coordinates)
    {
        if (grid.ContainsKey(coordinates))
        {
            grid[coordinates].isWalkable = true;
        }
    }

    public Vector2Int GetCoordinatesFromPosition(Vector3 position)
    {
        Vector2Int coordinates = new Vector2Int();
        position.x *= UnityGridSize; 
        position.y = position.z * UnityGridSize;

        return coordinates;
    }

    public Vector3 GetPositionFromCoordinates(Vector2Int coordenates)
    {
        Vector3 position = new Vector3();
        position.x = Mathf.RoundToInt(coordenates.x / UnityGridSize);
        position.y = Mathf.RoundToInt(coordenates.y / UnityGridSize);

        return position;
    }
}
