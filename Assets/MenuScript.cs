using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{

    // Start is called before the first frame update

    void Start()
    {
        Debug.Log("toto");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
