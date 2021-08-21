using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.EventSystems;

public class Cell : MonoBehaviour, IPointerClickHandler
{
    InputField inputField;

    [SerializeField] private bool selected = false;
    public bool Selected { get { return selected; } set { selected = value; } }

    [SerializeField] private int index;
    public int Index { get { return index; } set { index = value; } }

    private void Awake() {
        inputField = GetComponent<InputField>();
        inputField.onValidateInput += delegate (string input, int charIndex, char addedChar) { return ValidateInput(addedChar); };
        GameEvents.onClearCell += ClearCell;
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

    public void OnPointerClick(PointerEventData eventData) {
        GameEvents.CellSelected(index);
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
}
