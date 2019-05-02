using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

/// <summary>
/// Allows the player to switch from first person view to overhead camera view.
/// </summary>
public class SwitchOnWorldMap : MonoBehaviour
{
    private RigidbodyFirstPersonController rigidbodyFirstPersonController;
    [SerializeField] GameObject mainCamera;
    [SerializeField] GameObject worldMapCamera;
    [SerializeField] KeyCode SwitchCameraView = KeyCode.M;

    AudioListener mainCamAudio;
    AudioListener worldCamAudio;

    // Start is called before the first frame update
    void Start()
    {
        rigidbodyFirstPersonController = FindObjectOfType<RigidbodyFirstPersonController>();
        mainCamAudio = mainCamera.GetComponent<AudioListener>();
        worldCamAudio = worldMapCamera.GetComponent<AudioListener>();
        CameraPositionChange(PlayerPrefs.GetInt("CameraPostion"));   

    }

    // Update is called once per frame
    void Update()
    {
        SwitchCamera();
    }
    public void CameraPositionMain()
    {
        CameraChangeCounter();
    }
    void SwitchCamera()
    {
        if (Input.GetKeyDown(SwitchCameraView))
        {
            CameraChangeCounter();
        }
    }
    void CameraChangeCounter()
    {
        int CameraPositionCounter = (PlayerPrefs.GetInt("CameraPostion"));
        CameraPositionCounter++;
        CameraPositionChange(CameraPositionCounter);
    }
    void CameraPositionChange(int CamPosition)
    {
        if(CamPosition > 1)
        {
            CamPosition = 0;
        }
        
     
        // Sets camera position database
        PlayerPrefs.SetInt("CameraPosition", CamPosition);

        //sets to main camera
        if (CamPosition == 0)
        {
            rigidbodyFirstPersonController.enabled = true;

            mainCamera.SetActive(true);
            mainCamAudio.enabled = true;

            worldMapCamera.SetActive(false);
            worldCamAudio.enabled = false;

        }
        //sets to world camera
        if (CamPosition == 1)
        {

            rigidbodyFirstPersonController.enabled = false;

            worldMapCamera.SetActive(true);
            worldCamAudio.enabled = true;

            mainCamera.SetActive(false);
            mainCamAudio.enabled = false;  

        }
    }
}
