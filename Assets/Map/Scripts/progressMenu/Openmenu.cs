using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Openmenu : MonoBehaviour
{
    [SerializeField] GameObject progressMenu;
    [SerializeField] List<GameObject> closeMenu;
    [SerializeField] GameObject gameOverMenu;
    
    [SerializeField] CameraMovement cameraMove;
    [SerializeField] PlayerController playerController;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P) && progressMenu.activeSelf == false)
        {
            progressMenu.SetActive(true);
            cameraMove.GetComponent<CameraMovement>().enabled = false;
            playerController.GetComponent<PlayerController>().enabled = false;
        }
        else if(Input.GetKeyDown(KeyCode.P) && progressMenu.activeSelf == true)
        {
            progressMenu.SetActive(false);
            cameraMove.GetComponent<CameraMovement>().enabled = true;
            playerController.GetComponent<PlayerController>().enabled = true;

            for(int i = 0; i<closeMenu.Count; i++)
            {
                closeMenu[i].SetActive(false);
            }
        }

        if (gameOverMenu.activeSelf == true)
        {
            cameraMove.GetComponent<CameraMovement>().enabled = false;
            playerController.GetComponent<PlayerController>().enabled = false;
        }
    }
}
