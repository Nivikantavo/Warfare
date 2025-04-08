using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Map : MonoBehaviour
{
    private const float NeighboringTolerance = 0.1f;

    [SerializeField] private List<Cell> _cells;
    [SerializeField] private Cell _startCell;

    private Dictionary<Cell, Vector2> _cellsPositions;

    private float _cellsStep;
    
    private void Start()
    {
        foreach (var cell in _cells)
        {
            cell.gameObject.SetActive(true);
        }

        _cellsPositions = GetCellsPositions(_cells);
        CalculateStep();
        UnlockStartCells();
    }

    private Dictionary<Cell, Vector2> GetCellsPositions(List<Cell> cells)
    {
        Dictionary<Cell, Vector2> cellsPositions = new Dictionary<Cell, Vector2>();

        foreach (var cell in cells)
        {
            cellsPositions.Add(cell, cell.transform.position);
            cell.CellOpened += OnCellOpened;
        }
        
        return cellsPositions;
    }

    private void UnlockStartCells()
    {
        _startCell.UnlockCell();
    }

    private void OnCellOpened(Cell openedCell)
    {
        UnlockNeighboringCells(openedCell);
        openedCell.CellOpened -= OnCellOpened;
    }

    private void UnlockNeighboringCells(Cell cell)
    {
        List<Cell> neighboringCells = FindNeighboringCells(cell);

        foreach (var neighbourCell in neighboringCells)
        {
            neighbourCell.UnlockCell();
        }
    }

    private List<Cell> FindNeighboringCells(Cell cell)
    {
        var neighboringCells = _cellsPositions
            .Where(pair => pair.Key != cell && Vector2.Distance(pair.Value, _cellsPositions[cell]) <= _cellsStep)
            .Select(pair => pair.Key)
            .ToList();

        return neighboringCells;
    }

    private void CalculateStep()
    {
        float minStep = float.MaxValue;

        for (int i = 0; i < _cells.Count; i++)
        {
            for (int j = i + 1; j < _cells.Count; j++)
            {
                float distance = Vector2.Distance(_cellsPositions[_cells[i]], _cellsPositions[_cells[j]]);
                if (distance < minStep)
                {
                    minStep = distance;
                }
            }
        }

        _cellsStep = minStep + NeighboringTolerance;
    }
}
