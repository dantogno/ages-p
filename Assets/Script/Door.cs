using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Animator))]
public class Door : InteractiveObject
{
    private Animator animator;
    /// <summary>
    /// Using constructor to initiilize displayText in the editor.
    /// </summary>
    //public Door ()
    //{
    //    displayText = nameof(Door);
    //}

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    //public override void InteractWith()
    //{

    //}
}
