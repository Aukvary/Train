using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourseCollision : MonoBehaviour
{
    public enum resourse
    {
        fuel, food, wood, stone, iron
    }

    [SerializeField] resourse resourses;
    [SerializeField] int quantity;
    [SerializeField] int quantityRandom;

    private InventorySystem _inventorySystem;


    private void Start()
    {
        _inventorySystem = FindObjectOfType<InventorySystem>();
    }
    

    private void OnCollisionEnter(Collision collision)
    {
            Debug.Log("sigma");
        var col = collision.gameObject.GetComponent<PlayerController>();
        if (col != null)
        {
            if (resourses == resourse.fuel)
            {
                _inventorySystem.item[0].quantity += Random.Range(quantity - quantityRandom, quantity + quantityRandom);
            }
            if (resourses == resourse.food)
            {
                _inventorySystem.item[4].quantity += Random.Range(quantity - quantityRandom, quantity + quantityRandom);
            }
            if (resourses == resourse.wood)
            {
                _inventorySystem.item[1].quantity += Random.Range(quantity - quantityRandom, quantity + quantityRandom);

            }
            if (resourses == resourse.stone)
            {
                _inventorySystem.item[2].quantity += Random.Range(quantity - quantityRandom, quantity + quantityRandom);
            }
            if (resourses == resourse.iron)
            {
                _inventorySystem.item[3].quantity += Random.Range(quantity - quantityRandom, quantity + quantityRandom);
            }
            Destroy(gameObject);
        }
    }
}
