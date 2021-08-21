using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grid : MonoBehaviour
{
    private const int COLUMNS = 9;
    private const int ROWS = 9;
    private int[] BLOCK_CENTER_INDICES = new int[]{ 10, 13, 16, 37, 40, 43, 64, 67, 70 };

    private float cellOffset = 3.0f;
    private float cellScale = 0.9f;

    private float seperatorWidth = 5f;

    [SerializeField] private GameObject cellPrefab;

    private List<GameObject> cells = new List<GameObject>();

    private HashSet<int> selectedIndices = new HashSet<int>();
    private HashSet<int> highlightedCellsIndex = new HashSet<int>();

    private void Start() {
        GameEvents.onCellSelected += HighlightAffectedCells;
        InitializeGrid();
    }

    void InitializeGrid() {
        InstantiateCells();
        LoadPuzzle();
    }
    private void LoadPuzzle() {
        string testPuzzle = "000000002001006005300004000290400300000020061500700000050000900904001050700000003";

        for (int i = 0; i < testPuzzle.Length; i++) {
            cells[i].GetComponent<Cell>().SetNumber((int)char.GetNumericValue(testPuzzle[i]));
        }
    }

    private void InstantiateCells() {
        Vector2 startPosition = new Vector2(-660, 380);
        int numOfVerticalSeperators = 0;
        int numOfHorizontalSeperators = 0;

        for (int row = 0; row < ROWS; row++) {
            for (int column = 0; column < COLUMNS; column++) {
                GameObject cell = Instantiate(cellPrefab, this.transform);

                cell.GetComponent<RectTransform>().localScale = new Vector3(cellScale, cellScale, cellScale);
                float cellWidth = cell.GetComponent<RectTransform>().rect.width * cellScale;
                float cellHeight = cell.GetComponent<RectTransform>().rect.height * cellScale;

                if (column == 3 || column == 6) {
                    numOfVerticalSeperators++;
                }

                float cellXPosition = startPosition.x + (cellWidth + cellOffset) * column + seperatorWidth * numOfVerticalSeperators;
                float cellYPosition = startPosition.y - (cellHeight + cellOffset) * row - seperatorWidth * numOfHorizontalSeperators;

                cell.GetComponent<RectTransform>().anchoredPosition = new Vector2(cellXPosition, cellYPosition);

                cell.GetComponent<Cell>().Index = row * ROWS + column;
                cells.Add(cell);
            }

            numOfVerticalSeperators = 0;

            if (row == 2 || row == 5) {
                numOfHorizontalSeperators++;
            }
        }
    }

    public void HighlightAffectedCells(int index, bool addingNew) {
        if (!addingNew) {
            selectedIndices.Clear();
            selectedIndices.Add(index);
            GameEvents.ResetCellSelection(selectedIndices);

            ResetHighlights();

            if (index >= 0) {
                highlightedCellsIndex = GetAffectedCells(index);
                HighlightMarkedCells();
            }
        }
        else {
            selectedIndices.Add(index);
            GameEvents.ResetCellSelection(selectedIndices);

            if (highlightedCellsIndex.Count == 0) {
                highlightedCellsIndex = GetAffectedCells(index);
                HighlightMarkedCells();
                return;
            }
            HashSet<int> affectedCells = GetAffectedCells(index);

            HashSet<int> copy = new HashSet<int>(highlightedCellsIndex);
            copy.IntersectWith(affectedCells);

            ResetHighlights();

            highlightedCellsIndex = new HashSet<int>(copy);
            HighlightMarkedCells();
        }
    }

    private HashSet<int> GetAffectedCells(int index) {
        HashSet<int> affectedCells = new HashSet<int>();

        MarkRowForHighlight(index, affectedCells);
        MarkColumnForHighlight(index, affectedCells);
        MarkBlockForHighlight(index, affectedCells);

        return affectedCells;
    }

    private void HighlightMarkedCells() {
        foreach (int index in highlightedCellsIndex) {
            ColorBlock cb = cells[index].GetComponent<Cell>().colors;
            cb.normalColor = new Color32(177, 179, 255, 255);
            cells[index].GetComponent<Cell>().colors = cb;
        }
     }

    private void ResetHighlights() {
        foreach (int cellIndex in highlightedCellsIndex) {
            cells[cellIndex].GetComponent<Cell>().Unhighlight();
        }
        highlightedCellsIndex.Clear();
    }

    public void MarkRowForHighlight(int index, HashSet<int> highlightIndices) {
        int rowNumber = index / 9;
        for (int i = rowNumber * 9; i < rowNumber * 9 + 9; i++) {
            MarlCellForHighlight(i, highlightIndices);
        }
    }

    public void MarkColumnForHighlight(int index, HashSet<int> highlightIndices) {
        // Highlight cells above

        for (int i = index - 9; i >= 0; i-=9) {
            MarlCellForHighlight(i, highlightIndices);
        }

        // Highlight cells below
        for (int i = index + 9; i < 81; i+=9) {
            MarlCellForHighlight(i, highlightIndices);
        }
    }

    private void MarlCellForHighlight(int index, HashSet<int> highlightIndices) {
        highlightIndices.Add(index);
    }

    private void MarkBlockForHighlight(int index, HashSet<int> highlightIndices) {
        int indexOfCenter = FindCenter(index);

        for (int i = indexOfCenter - 1 - 9; i <= indexOfCenter - 1 + 9; i+=9) {
            MarlCellForHighlight(i, highlightIndices);
            for (int j = i; j < i + 3 ; j++) {
                MarlCellForHighlight(j, highlightIndices);
            }
        }
    }

    // Find the closest center (of a block) to the cell in the given index
    private int FindCenter(int index) {
        List<int> candidateCenters = new List<int>();
        foreach (int i in BLOCK_CENTER_INDICES) {
            if (Mathf.Abs(index - i) <= 10) {
                candidateCenters.Add(i);
            }
        }

        if (candidateCenters.Count == 1)
            return candidateCenters[0];

        float shortestDistance = Mathf.Infinity;
        int shortestDistanceIndex = 82;
        foreach (int i in candidateCenters) {
            float distance = Vector2.Distance(cells[i].transform.position, cells[index].transform.position);
            if (distance < shortestDistance) {
                shortestDistance = distance;
                shortestDistanceIndex = i;
            }
        }
        return shortestDistanceIndex;
    }
}
