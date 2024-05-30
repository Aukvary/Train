using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save : MonoBehaviour
{
    private void Start()
    {
        if (PlayerPrefs.GetInt("hodDistanse") != 16)
        {
            PlayerPrefs.SetInt("hodDistanse",8);
        }
    }
    
    
}
