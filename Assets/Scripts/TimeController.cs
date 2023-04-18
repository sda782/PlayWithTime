
using System;
using UnityEngine;

public class TimeController : MonoBehaviour {
    [SerializeField] private InputController inputController;
    private bool toggleTime;

    public Action<bool> TimeToggle;

    private void Start() {
        inputController.SpaceDown += OnSpaceDown;
        TimeToggle += OnTimeToggle;
        TimeToggle?.Invoke(false);
    }
    private void OnSpaceDown() {
        TimeToggle?.Invoke(true);
    }

    private void OnTimeToggle(bool toggle) {
        toggleTime = toggle;
        Time.timeScale = toggleTime ? 1 : 0;
    }
}
