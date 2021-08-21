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

    [SerializeField] private bool notesActive = false;
    private List<int> pencilMarks = new List<int>();

    new private void Start() {
        GameEvents.onClearCell += ClearCell;
        GameEvents.onNotesActive += SetNotesActive;
        GameEvents.onInputNumber += InputNumber;
        GameEvents.onCellSelected += Deselect;
    }

    private void SetNotesActive(bool b) {

        notesActive = b;
    }

    private void InputNumber(int num) {
        if (!selected)
            return;

        if (!notesActive) {
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

    public void Deselect(int selectedIndex) {
        if (selectedIndex != index) {
            selected = false;
        }
    }

    public void OnPointerClick(PointerEventData eventData) {
        if (selected)
            return;

        selected = true;
        GameEvents.CellSelected(index);
    }

    public new void OnDeselect(BaseEventData eventData) {
        GameEvents.CellSelected(-1);
        InstantClearState();
    }

    
}
