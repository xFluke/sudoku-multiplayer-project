using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public delegate void ClearCellHandler();
    public static event ClearCellHandler onClearCell;

    public static void ClearCell() {
        onClearCell();
    }

    public delegate void CellSelectedHandler(int cellIndex);
    public static event CellSelectedHandler onCellSelected;

    public static void CellSelected(int cellIndex) {
        onCellSelected(cellIndex);
    }
}
