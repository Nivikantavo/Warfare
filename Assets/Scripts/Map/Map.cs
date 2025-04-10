using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Map : MonoBehaviour
{
    private const float NeighboringTolerance = 0.1f;

    public event Action<int> LevelClicked;
    public event Action<BonusCellData> BonusFinded;

    [SerializeField] private List<Cell> _cells;
    [SerializeField] private Cell _startCell;

    private Dictionary<Cell, Vector2> _cellsPositions;
    private List<LevelCell> _levelCells = new List<LevelCell>();
    private List<BonusHolderCell> _bonusHoldersCells = new List<BonusHolderCell>();

    private float _cellsStep;

    private void Start()
    {
        Initialize();
    }

    private void OnEnable()
    {
        foreach (var cell in _cells)
        {
            cell.CellOpened += OnCellOpened;
        }
    }

    private void OnDisable()
    {
        foreach (var cell in _cells)
        {
            cell.CellOpened -= OnCellOpened;
        }
    }

    public void Initialize()
    {
        DistributeCells();

        _cellsPositions = GetCellsPositions(_cells);
        CalculateStep();
        UnlockStartCells();
    }

    private void DistributeCells()
    {
        foreach (var cell in _cells)
        {
            cell.gameObject.SetActive(true);

            if (cell is LevelCell)
            {
                _levelCells.Add(cell as LevelCell);
            }
            else if (cell is BonusHolderCell)
            {
                _bonusHoldersCells.Add(cell as BonusHolderCell);
            }
        }

        foreach (var cell in _levelCells)
        {
            cell.LevelCellInteract += OnLevelCellInteract;
        }

        foreach (var cell in _bonusHoldersCells)
        {
            cell.BonusCellInteract += OnBonusCellInteract;
        }
    }

    private Dictionary<Cell, Vector2> GetCellsPositions(List<Cell> cells)
    {
        Dictionary<Cell, Vector2> cellsPositions = new Dictionary<Cell, Vector2>();

        foreach (var cell in cells)
        {
            cellsPositions.Add(cell, cell.transform.position);
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

    private void OnLevelCellInteract(int levelIndex)
    {
        LevelClicked?.Invoke(levelIndex);
    }

    private void OnBonusCellInteract(BonusCellData bonusData)
    {
        BonusFinded?.Invoke(bonusData);
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
