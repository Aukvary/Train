using UnityEngine;

public class CameraTranslater : MonoBehaviour
{
    [SerializeField] private Transform cameraLink;
    [SerializeField] private float _cameraSpeed;

    private float _posZ;

    private void Start()
    {
        _posZ = cameraLink.position.y;
    }


    private void Update()
    {
        if (!Input.GetMouseButton(1))
            return;

        float posX = transform.position.x + Input.GetAxis("Mouse X") * Time.deltaTime * _cameraSpeed;
        float posY = transform.position.y + Input.GetAxis("Mouse Y") * Time.deltaTime * _cameraSpeed;
        cameraLink.position = new Vector3(posX, posY, -1);
    }
}
