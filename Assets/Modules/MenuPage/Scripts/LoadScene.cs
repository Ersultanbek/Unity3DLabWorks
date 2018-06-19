using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour {
    public string SceneName;

    public static void LoadSceneByName(string scene) {
        Debug.Log(scene);
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }

    public void Awake()
    {
        this.GetComponent<Button>().onClick.AddListener(() => LoadSceneByName(SceneName));
    }
}
