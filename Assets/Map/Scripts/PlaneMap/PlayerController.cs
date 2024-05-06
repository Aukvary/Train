using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Camera camera;
    [SerializeField] float speed;
    [SerializeField] GameObject cellColider;

    private void Update()
    {
        var direction = camera.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        if(Physics.Raycast(direction,out hit))
        {
            if(Input.GetMouseButtonDown(0))
            {
                transform.position = hit.collider.gameObject.transform.position;
                Debug.Log("pon");
            }
            
        }
    }
}
