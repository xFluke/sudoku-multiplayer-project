using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    private const int COLUMNS = 9;
    private const int ROWS = 9;

    private float cellOffset = 3.0f;
    private float cellScale = 0.9f;

    private float seperatorWidth = 5f;

    [SerializeField] private GameObject cellPrefab;

    private List<GameObject> cells = new List<GameObject>();

    private void Start() {
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
}
