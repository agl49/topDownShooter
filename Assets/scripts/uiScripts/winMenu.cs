using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class winMenu : MonoBehaviour
{
    public void returnToMenu()
    {
        Debug.Log("win return to menu");    
        SceneManager.LoadScene(0);
    }

}
