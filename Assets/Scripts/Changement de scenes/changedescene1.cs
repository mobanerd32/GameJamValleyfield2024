using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changedescene1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartScene() 
    {
        SceneManager.LoadScene("UI-choix");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScene(string scene){
        SceneManager.LoadScene(scene);
    }
}
