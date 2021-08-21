using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class Cell : Selectable, IPointerClickHandler, IDeselectHandler
{ 
    InputField inputField;
    [SerializeField] Text numberText;

    [SerializeField] Transform notesObject;
    [SerializeField] private bool selected = false;
    public bool Selected { get { return selected; } set { selected = value; } }

    [SerializeField] private int index;
    public int Index { get { return index; } set { index = value; } }

    [SerializeField] private int number = 0;
    public int Number { get { return number; } set { number = value; } }


    private bool blockInput = false;

    [SerializeField] private bool controlHeld = false;
    private List<int> pencilMarks = new List<int>();

    new private void Start() {
        GameEvents.onClearCell += ClearCell;
        GameEvents.onNotesActive += SetNotesActive;
        GameEvents.onInputNumber += InputNumber;
        GameEvents.onResetCellSelection += Deselect;
        GameEvents.onShowCellWithSameNumber += ShowCellWithSameNumber;
    }

    private void ShowCellWithSameNumber(int num) {
        if (number == 0)
            return;

        if (num < 0) {
            Unhighlight();
        }

        if (number == num) {
            ColorBlock cb = colors;
            cb.normalColor = new Color32(67, 163, 212, 255);
            colors = cb;
        }
    }

    private void SetNotesActive(bool b) {

        controlHeld = b;
    }

    private void InputNumber(int num) {
        if (!selected || blockInput)
            return;

        if (!controlHeld) {
            numberText.text = num.ToString();
            number = num;
            GameEvents.ShowCellsWithSameNumber(number);
        }
        else {
            AddPencilMark(num);
        }
    }
    private void AddPencilMark(int num) {
        notesObject.GetChild(num - 1).gameObject.SetActive(true);
    }

    private void ClearCell() {
        if (selected)
            inputField.text = "";
    }
    public void SetNumber(int num) {
        if (num > 0) {
            number = num;
            numberText.text = num.ToString();
            numberText.fontStyle = FontStyle.Bold;
            blockInput = true;
        }
    }

    public void Unhighlight() {
        ColorBlock cb = colors;
        cb.normalColor = Color.white;
        colors = cb;
    }

    public void Deselect(HashSet<int> selectedIndices) {
        if (!selectedIndices.Contains(index)) {
            selected = false;
            InstantClearState();
        }
    }

    public void OnPointerClick(PointerEventData eventData) {
        if (selected)
            return;

        selected = true;
        GameEvents.CellSelected(index, controlHeld);
    }

    public new void OnDeselect(BaseEventData eventData) {
        if (!controlHeld) {
            GameEvents.CellSelected(-1);
            GameEvents.ShowCellsWithSameNumber(-1);
            GameEvents.ResetCellSelection(new HashSet<int>());
        }
    }

    
}
