using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class Cell : MonoBehaviour, ISelectHandler
{
    InputField inputField;

    [SerializeField] Transform notesObject;
    [SerializeField] private bool selected = false;
    public bool Selected { get { return selected; } set { selected = value; } }

    [SerializeField] private int index;
    public int Index { get { return index; } set { index = value; } }

    private bool notesActive = false;
    private List<int> pencilMarks = new List<int>();


    private void Awake() {
        inputField = GetComponent<InputField>();
        inputField.onValidateInput += delegate (string input, int charIndex, char addedChar) { return ValidateInput(addedChar); };
        GameEvents.onClearCell += ClearCell;
        GameEvents.onNotesActive += SetNotesActive;
        GameEvents.onInputNumber += AddPencilMark;
        GameEvents.onCellSelected += Deselect;
    }

    private void SetNotesActive(bool b) {

        notesActive = b;
    }

    private char ValidateInput(char addedChar) {
        // Check if user input is between 1-9
        if (Char.GetNumericValue(addedChar) > 0 && Char.GetNumericValue(addedChar) < 10) {
            if (inputField.text.Length == 1) {
                inputField.text = "";
            }

            return addedChar;
        }
        else {
            return '\0';
        }
    }

    private void AddPencilMark(int num) {
        if (selected) {
            Debug.Log("hi");
        }

        if (selected && notesActive) {
            notesObject.GetChild(num - 1).gameObject.SetActive(true);
        }
    }

    private void ClearCell() {
        if (selected)
            inputField.text = "";
    }
    public void SetNumber(int num) {
        if (num > 0) {
            inputField.text = num.ToString();
            inputField.readOnly = true;
        }
    }

    public void Unhighlight() {
        ColorBlock cb = inputField.colors;
        cb.normalColor = Color.white;
        inputField.colors = cb;
    }

    public void OnSelect(BaseEventData eventData) {
        selected = true;
        GameEvents.CellSelected(index);
    }

    public void Deselect(int selectedIndex) {
        if (selectedIndex != index) {
            selected = false;
        }
    }
}
