using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openButtonDescryption : MonoBehaviour
{
    [SerializeField] GameObject openMenu;
    [SerializeField] List<GameObject> closeMenu;

    
    public void OpenDescription()
    {
        for(int i = 0; i < closeMenu.Count; i++)
        {
            closeMenu[i].SetActive(false);
        }
        openMenu.SetActive(true);
    }
}
