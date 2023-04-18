using UnityEngine;

public class MenuUI : MonoBehaviour {
    [SerializeField] private GameObject MainMenu;
    [SerializeField] private GameObject LevelSelectionMenu;

    void Start() {
        OpenMainMenu();
    }
    public void OpenLevelSelectionMenu() {
        MainMenu.SetActive(false);
        LevelSelectionMenu.SetActive(true);
    }
    public void OpenMainMenu() {
        LevelSelectionMenu.SetActive(false);
        MainMenu.SetActive(true);
    }
}
