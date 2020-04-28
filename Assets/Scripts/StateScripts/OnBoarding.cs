using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnBoarding : MonoBehaviour
{
    public int index = 0;

    public GameObject[] panels;

    // Start is called before the first frame update
    void Start()
    {
        panels[0].SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            panels[index].SetActive(false);
            index++;
            if (index >= panels.Length)
            {
                gameObject.SetActive(false);
            } else
            {
                panels[index].SetActive(true);
            }

        }
    }
}
