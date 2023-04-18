
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour {
    [SerializeField] private InputController inputController;
    [SerializeField] private TMP_Text info;
    private void Start() {
        inputController.SpaceDown += OnSpaceDown;
        info.gameObject.SetActive(true);
    }

    private void OnSpaceDown() {
        info.gameObject.SetActive(false);
    }
}
