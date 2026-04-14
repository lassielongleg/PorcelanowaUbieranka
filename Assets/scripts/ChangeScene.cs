using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBackground : MonoBehaviour
{
    public GameObject[] backgrounds;
    private int backgroundNum = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackGroundChangerLeft()
    {
        backgrounds[backgroundNum].SetActive(false);
        backgroundNum--;
        if (backgroundNum < 0)
        {
            backgroundNum = backgrounds.Length-1;
        }
        backgrounds[backgroundNum].SetActive(true);

    }

    public void BackGroundChangerRight()
    {
        backgrounds[backgroundNum].SetActive(false);
        backgroundNum++;
        if (backgroundNum == backgrounds.Length)
        {
            backgroundNum = 0;
        }
        backgrounds[backgroundNum].SetActive(true);
    }
}