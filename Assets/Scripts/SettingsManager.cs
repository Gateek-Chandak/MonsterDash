using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsManager : MonoBehaviour
{
  
    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void goHome()
    {
        SceneManager.LoadScene("Menu");
    }
}
