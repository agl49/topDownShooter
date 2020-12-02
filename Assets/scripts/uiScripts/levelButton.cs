using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelButton : MonoBehaviour
{
   public void playLevel1()
   {
        SceneManager.LoadScene(1);
   }

   public void playLevel2()
   {
        SceneManager.LoadScene(2);
   }

   public void playLevel3()
   {
        SceneManager.LoadScene(3);
   }
}
