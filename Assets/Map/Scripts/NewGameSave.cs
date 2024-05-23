using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGameSave : MonoBehaviour
{
    public void click()
    {
        PlayerPrefs.DeleteAll();
    }
}
