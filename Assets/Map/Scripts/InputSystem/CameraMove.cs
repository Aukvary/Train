using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] Transform train;
    [SerializeField] Transform q;
    [SerializeField] Transform w;

    private CameraController cameraActions;
    private InputAction movement;
    private Transform cameraTransform;

    [SerializeField] Camera camera;

    [SerializeField]
    private float maxSpeed = 5f;
    private float speed;
    
    [SerializeField]
    private float acceleration = 10f;
    
    [SerializeField]
    private float damping = 15f;

    
    [SerializeField]
    private float stepSize = 2f;
    
    [SerializeField]
    private float zoomDampening = 7.5f;
    
    [SerializeField]
    private float minHeight = 5f;
    
    [SerializeField]
    private float maxHeight = 50f;
    
    [SerializeField]
    private float zoomSpeed = 2f;

    
    [SerializeField]
    private float maxRotationSpeed = 1f;

    
    [SerializeField]
    [Range(0f, 0.1f)]
    private float edgeTolerance = 0.05f;

    //value set in various functions 
    //used to update the position of the camera base object.
    private Vector3 targetPosition;

    private float zoomHeight;

    //used to track and maintain velocity w/o a rigidbody
    private Vector3 horizontalVelocity;
    private Vector3 lastPosition;

    //tracks where the dragging action started
    Vector3 startDrag;

    private void Awake()
    {
        //transform.position = new Vector3(train.transform.position.x, 0, train.transform.position.z);
        cameraActions = new CameraController();
        cameraTransform = this.GetComponentInChildren<Camera>().transform;
    }

    private void Start()
    {
        transform.position = new Vector3(train.transform.position.x, 0, train.transform.position.z);
    }

    private void OnEnable()
    {
        lastPosition = this.transform.position;
        movement = cameraActions.camera.Movement;
        cameraActions.camera.Enable();
    }

    private void OnDisable()
    {
        cameraActions.Disable();
    }

    private void Update()
    {
        GetKeyboardMovement();

        CheckMouseAtScreenEdge();

        DragCamera();

        UpdateVelocity();
        UpdateBasePosition();
    }

    private void UpdateVelocity()
    {
        horizontalVelocity = (this.transform.position - lastPosition) / Time.deltaTime;
        horizontalVelocity.y = 0;
        lastPosition = this.transform.position;
    }

    private void GetKeyboardMovement()
    {
        Vector3 inputValue = movement.ReadValue<Vector2>().x * GetCameraRight() + movement.ReadValue<Vector2>().y * GetCameraForward();

        inputValue = inputValue.normalized;
        if (inputValue.sqrMagnitude > 0.1f)
            targetPosition += inputValue;
    }

    private Vector3 GetCameraRight()
    {
        Vector3 right = cameraTransform.right;
        right.y = 0;
        return right;
    }
    private Vector3 GetCameraForward()
    {
        Vector3 forward = cameraTransform.forward;
        forward.y = 0;
        return forward;
    }

    private void UpdateBasePosition()
    {
        if (targetPosition.sqrMagnitude > 0.1f)
        {
        speed = Mathf.Lerp(speed, maxSpeed, Time.deltaTime * acceleration);
        transform.position += targetPosition * Time.deltaTime * speed;
        }
        else
        {
            horizontalVelocity = Vector3.Lerp(horizontalVelocity, Vector3.zero, Time.deltaTime * damping);
            transform.position += horizontalVelocity * Time.deltaTime;
        }

        targetPosition = Vector3.zero;
    }

    private void CheckMouseAtScreenEdge()
    {
        Vector2 mousePosition = Mouse.current.position.ReadValue();
        Vector3 moveDirection = Vector3.zero;

        if (mousePosition.x < edgeTolerance * Screen.width)
            moveDirection += -GetCameraRight();
        else if(mousePosition.x > (1f - edgeTolerance) * Screen.width)
            moveDirection += GetCameraRight();

        if (mousePosition.y < edgeTolerance * Screen.height)
            moveDirection += -GetCameraForward();
        else if (mousePosition.y > (1f - edgeTolerance) * Screen.height)
            moveDirection += GetCameraForward();

        targetPosition += moveDirection;
    } 

    private void DragCamera()
    {
        if (!Mouse.current.rightButton.isPressed)
            return;

        Plane plane = new Plane(Vector3.up, Vector3.zero);

        Ray ray = camera.ScreenPointToRay(Mouse.current.position.ReadValue());

        if(plane.Raycast(ray, out float distance))
        {
            if (Mouse.current.rightButton.wasPressedThisFrame)
                startDrag = ray.GetPoint(distance);
            else
            {
                targetPosition += startDrag - ray.GetPoint(distance);
            }
        }
    }
}
