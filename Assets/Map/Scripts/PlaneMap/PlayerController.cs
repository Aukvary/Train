using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float maxDistance = 8;
    [SerializeField] Camera camera;
    [SerializeField] float speed;

    private float _distance;
    private Vector3 _newTransform;


    private void Update()
    {
        CellTransform();
        transform.position = Vector3.Lerp(transform.position, _newTransform, speed * Time.deltaTime);
    }

    private void CellTransform()
    {
        maxDistance = PlayerPrefs.GetInt("hodDistanse");

        var direction = camera.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        if (Physics.Raycast(direction, out hit))
        {
            var cell = hit.collider.gameObject;

            _distance = Vector3.Distance(cell.transform.position, transform.position);
            var isCell = cell.GetComponent<TraintTransform>();

            if (Input.GetMouseButtonDown(0) && _distance <= maxDistance && isCell != null)
            {
                _newTransform = cell.transform.position;
                transform.LookAt(_newTransform);
                Debug.Log("pon");
            }
        }
    }
}
