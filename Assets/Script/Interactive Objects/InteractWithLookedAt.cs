using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Detects when the player pressed the interact button while looking at the IInteractive,
/// and then calls that IInteracctive's Interact With method.
/// </summary>
public class InteractWithLookedAt : MonoBehaviour
{
    private IInteractive lookedAtInteractive;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact") && lookedAtInteractive !=null)
        {
            Debug.Log("Player pressed the interact button.");
            lookedAtInteractive.InteractWith();
        }
    }

    private void OnLookedAtInteractiveChanged(IInteractive newLookedAtInteractive)
    {
        lookedAtInteractive = newLookedAtInteractive;
    }

    #region Event subscription / unsubscribe
    private void OnEnable()
    {
        DetectLookAtInteractive.LookedAtInteractiveChanged += OnLookedAtInteractiveChanged;
    }

    private void OnDisable()
    {
        DetectLookAtInteractive.LookedAtInteractiveChanged -= OnLookedAtInteractiveChanged;
    }
    #endregion


}
