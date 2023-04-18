using System;
using UnityEngine;

public class InputController : MonoBehaviour {
    public Action MouseLeftDown;
    public Action MouseLeftUp;
    public Action MouseLeft;
    public Action SpaceDown;
    private void Update() {
        //  Mouse inputs
        if (Input.GetMouseButtonDown(0)) MouseLeftDown?.Invoke();
        if (Input.GetMouseButtonUp(0)) MouseLeftUp?.Invoke();
        if (Input.GetMouseButton(0)) MouseLeft?.Invoke();

        //  Key inputs
        if (Input.GetKeyDown(KeyCode.Space)) SpaceDown?.Invoke();
    }
}
