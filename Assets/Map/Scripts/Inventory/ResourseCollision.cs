using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourseCollision : MonoBehaviour
{
    public enum resourse
    {
        fuel, food, wood, stone, iron, enemy
    }

    [SerializeField] resourse resourses;
    [SerializeField] float quantity;
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
            float saveLevel = PlayerPrefs.GetFloat("resourseDrop")/100 + 1;
            float quant = Random.Range(quantity * saveLevel - quantityRandom, quantity * saveLevel + quantityRandom);
            Debug.Log("quant=" + quant);
            if (resourses == resourse.fuel)
            {
                
                _inventorySystem.item[0].quantity += Mathf.FloorToInt(quant);
            }
            if (resourses == resourse.food)
            {
                
                _inventorySystem.item[4].quantity += Mathf.FloorToInt(quant);
            }
            if (resourses == resourse.wood)
            {
                
                _inventorySystem.item[1].quantity += Mathf.FloorToInt(quant);
            }
            if (resourses == resourse.stone)
            {
                
                _inventorySystem.item[2].quantity += Mathf.FloorToInt(quant);
            }
            if (resourses == resourse.iron)
            {
                
                _inventorySystem.item[3].quantity += Mathf.FloorToInt(quant);
            }
            if (resourses == resourse.enemy)
            {

                DataManager.GoToFightScene(_inventorySystem);
            }

            Destroy(gameObject);
        }
    }
}
