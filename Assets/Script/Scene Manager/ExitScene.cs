using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitScene : MonoBehaviour
{

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        Debug.Log("Application Closed");
    }

}