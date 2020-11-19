using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//https://docs.unity3d.com/ScriptReference/RequireComponent.html
[RequireComponent(typeof(Animator))]
public class playerAnimations : MonoBehaviour
{
    protected Animator myAnimator;

    private void Awake()
    {
        myAnimator = GetComponent<Animator>();
    }

    public void setWalk(bool moving)
    {
        myAnimator.SetBool("moving", moving);
    }

    public void setDie(bool dead)
    {
        myAnimator.SetBool("dead", dead);
    }    

}
