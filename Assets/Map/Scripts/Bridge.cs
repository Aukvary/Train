using System.Collections.Generic;
using UnityEngine;

public class Bridge : MonoBehaviour
{
    [SerializeField] private List<GameObject> _enemyes;

    private void Start()
    {
        int count = 0;

        foreach(var enemy in _enemyes)
        {
            if(enemy == null)
                count++;
        }
        if(count < 2)
            gameObject.SetActive(false);
    }
}