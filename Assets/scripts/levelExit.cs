using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelExit : MonoBehaviour
{
    [SerializeField] private float levelLoadDelay;

    private void OnTriggerEnter2D(Collider2D other)
    {
       StartCoroutine(LoadNextLevel());
    }

    private IEnumerator LoadNextLevel() 
    {
        Debug.Log("we entered the coroutine");

        yield return new WaitForSecondsRealtime(levelLoadDelay);

        var currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if(currentSceneIndex == 3)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(currentSceneIndex + 1);
            Debug.Log("Done Loading scene");
        }

   }
}
