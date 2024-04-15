using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Camera camera;
    public Transform cameraGameObject;
    public GameObject pointStart;
    public GameObject pointFinish;

    public GameObject map;

    private Vector3 _savePosition;


    void Update()
    {
        PointPosition1();
        PointPosition2();

        cameraTranslate();
    }
    
    private void cameraTranslate()
    {
        if (Input.GetMouseButton(1))
        {
            Vector3 move = pointFinish.transform.position - pointStart.transform.position;
            if (move != null)
            {
                cameraGameObject.transform.position = Vector3.Lerp(cameraGameObject.transform.position, move, 2 * Time.deltaTime);
            }
        }
    }

    private void PointPosition1()
    {
        var ray = camera.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject == map.gameObject)
            {
                if (Input.GetMouseButton(1))
                {
                    pointStart.transform.position = _savePosition;
                }
                else
                {
                    pointStart.transform.position = hit.point;
                    _savePosition = pointStart.transform.position;
                }
            }
        }
    }

    private void PointPosition2()
    {
        var ray = camera.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.gameObject == map.gameObject)
            {
                if (Input.GetMouseButton(1))
                {
                    pointFinish.transform.position = hit.point;
                }
            }
        }
    }
}


