using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuControllerScript : MonoBehaviour {
    const int CONTINUE_BUTTON_INDEX = 0;
    const int AR_BUTTON_INDEX = 1;
    const int VR_BUTTON_INDEX = 2;
    const int EXIT_BUTTON_INDEX = 3;

    const string prevScene = "ListOfLabs";

    public GameObject menu_panel;
    public GameObject menu_button;
    public List<GameObject> buttons;
    public JSONLoader jSONLoader = JSONLoader.Instance;
    bool isOpen;
    // Use this for initialization
    void Awake () {
 
        isOpen = true;
        menu_button.GetComponent<Button>().onClick.AddListener(() => {OpenCloseMenu(menu_panel, ref isOpen);});
        SceneLink scene = jSONLoader.GetSceneLink(SceneManager.GetActiveScene().name);

        buttons[CONTINUE_BUTTON_INDEX].GetComponent<Button>().onClick.AddListener(() => OpenCloseMenu(menu_panel,ref isOpen));
        buttons[AR_BUTTON_INDEX].GetComponent<Button>().onClick.AddListener(() => LoadScene.LoadSceneByName(scene.ARsceneLink));
        buttons[VR_BUTTON_INDEX].GetComponent<Button>().onClick.AddListener(() => LoadScene.LoadSceneByName(scene.VRsceneLink));
        buttons[EXIT_BUTTON_INDEX].GetComponent<Button>().onClick.AddListener(() => LoadScene.LoadSceneByName(prevScene));
        
    }

    void OpenCloseMenu(GameObject menu_panel,ref bool isOpen) {
        menu_panel.SetActive(isOpen);
        isOpen = isOpen ^ true;
        Debug.Log(isOpen);
    }

    void SetMenuElements(GameObject parent,ArrayList item_list) {


    }

    

}
