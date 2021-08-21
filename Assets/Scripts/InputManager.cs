using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public void OnEnableNotes(InputAction.CallbackContext ctx) {
        GameEvents.NotesActive(ctx.ReadValueAsButton());
    }
    
    public void OnInputNumber(InputAction.CallbackContext ctx) {
        int numKeyValue; 
        int.TryParse(ctx.control.name, out numKeyValue);

        GameEvents.InputNumber(numKeyValue);
    }

    public void OnClearCell(InputAction.CallbackContext ctx) {
        GameEvents.ClearCell();
    }
}
