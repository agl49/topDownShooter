using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    public void playGame()
    {
        //Loads test scene for now
        SceneManager.LoadScene(1);
    }

    public void quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
