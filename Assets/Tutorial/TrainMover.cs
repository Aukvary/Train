using Unity.VisualScripting;
using UnityEngine;

public class TrainMover : MonoBehaviour
{
    private float _y;

    private Vector3 _target;

    private new RectTransform transform;

    private float x => Mathf.Clamp(transform.position.x + Input.GetAxis("Mouse X") * 10, 0, 1200);

    private void Awake()
    {
        transform = GetComponent<RectTransform>();

        _y = transform.position.y;
    }

    private void FixedUpdate()
    {
        transform.position = new Vector3(x, _y, 0);
    }

    
}