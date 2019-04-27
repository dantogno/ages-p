using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectLookAtInteractive : MonoBehaviour
{
    [Tooltip("Starting point of raycast used to detect origins.")]
    [SerializeField] private Transform raycastOrigin;

    [Tooltip("How far from raycastOrigin we will search for interactive element.")]
    [SerializeField] private float maxRange = 5.0f;


    public IInteractive LookedAtInteractive
    {
        get { return lookedAtInteractive; }
        set { lookedAtInteractive = value; }
    }
    private IInteractive lookedAtInteractive;

    private void FixedUpdate()
    {
       Debug.DrawRay(raycastOrigin.position, raycastOrigin.forward * maxRange, Color.red);

        RaycastHit hitInfo;
        bool objectWasDetected = Physics.Raycast(raycastOrigin.position, raycastOrigin.forward,out hitInfo, maxRange);

        IInteractive interactive = null;

        if (objectWasDetected)
        {
            // Debug.Log($"Player is looking at:  { hitInfo.collider.gameObject.name}");
            interactive = hitInfo.collider.gameObject.GetComponent<IInteractive>();
        }

        if (interactive != null)
            //interactive.InteractWith();
            lookedAtInteractive = interactive;
    }
}
