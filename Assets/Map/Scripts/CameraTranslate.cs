using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTranslate : MonoBehaviour
{
    public Transform cameraGameObject;
    public float speed;

    private float _posY;

    private void Start()
    {
        _posY = cameraGameObject.position.y;
    }


    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            cameraGameObject.position = Vector3.Lerp(cameraGameObject.position, new Vector3(,_posY,), speed * Time.deltaTime);
        }


    }

    private void VectorMoveZ()
    {

    }
}
