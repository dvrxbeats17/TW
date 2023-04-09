using System.Collections.Generic;
using UnityEngine;


public class pithFinder : MonoBehaviour
{
    [SerializeField] private Node currentNode;

    private Vector2Int[] _directions = {Vector2Int.up, Vector2Int.right, Vector2Int.down, Vector2Int.left};

    private GridManager _gridManager;
    Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();
    private void Awake()
    {
        _gridManager = FindObjectOfType<GridManager>();
        if(_gridManager != null)
        {
            grid = _gridManager.Grid;
        }
    }
    private void Start()
    {
        ExploreNeighbours();
    }
    
    private void ExploreNeighbours()
    {
        if (grid.ContainsKey(currentNode.coordinates))
        {
            grid[currentNode.coordinates].isPath = true;
        }
        List<Node> neighburs = new List<Node>();
        // составить лист соседей проходить по всем напрвлениям (с помощью масисва). в массиве вычислить координаты соседа.
        // проверяем в этом напралении соседние ноды. если они существуют то  мы добаляем ее в лист соседей и ставим метку isExplored
        foreach(Vector2Int direction in _directions)
        {
            Vector2Int neighborCoordinates = currentNode.coordinates + direction;

            if (grid.ContainsKey(neighborCoordinates))
            {
                neighburs.Add(grid[neighborCoordinates]);
                grid[neighborCoordinates].isExplored = true;
                grid[currentNode.coordinates].isPath = true;
            }
        }
    }
}
