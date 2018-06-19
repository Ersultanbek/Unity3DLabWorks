using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneListLoader : MonoBehaviour {
    public GameObject loadButtonPref;
    public GameObject panel;
    public GameObject horizPanelPref;
    public GameObject verticalPanelPref;

    public JSONLoader JSONLoader = JSONLoader.Instance;

    // Use this for initialization
    void Awake () {
        Vector3 prevPos = new Vector3(0,0, 0);
        Vector2 buttonSize = new Vector2(Screen.width / 10, Screen.width / 10);
    
            List<SceneLink> scenesLink = JSONLoader.GetSceneLinks();
            
            GameObject newButton;
            GameObject newHorzPanel = Instantiate(horizPanelPref, verticalPanelPref.transform);
            newHorzPanel.transform.SetParent(verticalPanelPref.transform, false);
            int count = 0;
            foreach (SceneLink link in scenesLink) {
                if (loadButtonPref != null)
                {
                    if (count < 6)
                    {
                        newButton = Instantiate(loadButtonPref, loadButtonPref.transform.position, loadButtonPref.transform.rotation);
                        newButton.GetComponent<Transform>().SetParent(newHorzPanel.transform, false);
                        RectTransform trans = newButton.GetComponent<RectTransform>();
                       
                        trans.GetComponent<RectTransform>().anchoredPosition = prevPos;
                        trans.GetComponent<RectTransform>().sizeDelta = buttonSize;
                        trans.GetComponent<Button>().onClick.AddListener(() => LoadSceneByName(link.sceneLink));
                        prevPos += new Vector3(120, 0, 0);
                        count++;
                    }
                    else {
                        count = 0;
                        newHorzPanel = Instantiate(horizPanelPref, verticalPanelPref.transform);
                        newHorzPanel.transform.SetParent(verticalPanelPref.transform, false);
                    }
                }
            }
        }


    public void LoadSceneByName(string scene)
    {
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }
}
