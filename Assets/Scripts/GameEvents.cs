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

    public delegate void CellHoveredHandler(int cellIndex);
    public static event CellHoveredHandler onCellHovered;

    public static void CellHovered(int cellIndex) {
        onCellHovered(cellIndex);
    }

    public delegate void NotesActiveHandler(bool active);
    public static event NotesActiveHandler onNotesActive;

    public static void NotesActive(bool active) {
        onNotesActive(active);
    }

    public delegate void InputNumberHandler(int num);
    public static event InputNumberHandler onInputNumber;

    public static void InputNumber(int num) {
        onInputNumber(num);
    }

}
