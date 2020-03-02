using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class LoadManager : MonoBehaviour
{
    public GameObject loadScene;
    public Slider slider;
    public Text text;

    public void LoadNextLevel()
    {
        StartCoroutine(Loadlevel());
    }

    IEnumerator Loadlevel()
    {
        loadScene.SetActive(true);

        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            slider.value = operation.progress;

            text.text = "Loading......" + operation.progress * 100 + "%";

            yield return null;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
