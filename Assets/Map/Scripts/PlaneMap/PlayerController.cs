using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Transform startPosition;
    [SerializeField] LayerMask layerMask;

    public float maxDistance = 8;
    [SerializeField] Camera camera;
    [SerializeField] float speed;

    private float _distance;
    private Vector3 _newTransform;
    private MinusFoodAndFuel _minusFoodAndFuel;
    private InventorySystem _inventorySystem;

    private void Awake()
    {
        _newTransform = new Vector3(startPosition.position.x, transform.position.y, startPosition.position.z);
        _minusFoodAndFuel = GetComponent<MinusFoodAndFuel>();
        _inventorySystem = GetComponent<InventorySystem>();
    }

    private void Start()
    {
        if (DataManager.Items != null)
        {
            _inventorySystem.item = DataManager.Items;
        }
    }

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
        if (Physics.Raycast(direction, out hit, layerMask))
        {
            var cell = hit.collider.gameObject;

            _distance = Vector3.Distance(cell.transform.position, transform.position);
            var isCell = cell.GetComponent<TraintTransform>();

            if (Input.GetMouseButtonDown(0) && _distance <= maxDistance && isCell != null)
            {
                _minusFoodAndFuel.FoodAndFuelMinus(2, 0);
                _minusFoodAndFuel.FoodAndFuelMinus(2, 4);

                _newTransform = cell.transform.position;
                transform.LookAt(_newTransform);
                Debug.Log("pon");
            }
        }
    }
}
