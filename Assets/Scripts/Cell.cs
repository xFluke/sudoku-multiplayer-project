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

    [SerializeField] private bool controlHeld = false;
    private List<int> pencilMarks = new List<int>();

    new private void Start() {
        GameEvents.onClearCell += ClearCell;
        GameEvents.onNotesActive += SetNotesActive;
        GameEvents.onInputNumber += InputNumber;
        GameEvents.onResetCellSelection += Deselect;
    }

    private void SetNotesActive(bool b) {

        controlHeld = b;
    }

    private void InputNumber(int num) {
        if (!selected)
            return;

        if (!controlHeld) {
            numberText.text = num.ToString();
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
            numberText.text = num.ToString();
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
        Debug.Log(eventData.currentInputModule);
        if (!controlHeld) {
            GameEvents.CellSelected(-1);
            InstantClearState();
        }
    }

    
}
