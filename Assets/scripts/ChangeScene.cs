using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    public GameObject tlodom;
    public GameObject tloogrod;
    
    void Start()
    {
        
    }
    void Update()
    {
        
    }

    public void BackgroundChanger()
    {
            tlodom.SetActive(false);
            tloogrod.SetActive(true);
    }
}