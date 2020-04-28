using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class DropdownTrigger : MonoBehaviour
{
    public GameObject descriptivePanel;
    public GameObject allProblemsList;
    public GameObject allActionsList;
    public GameObject DescriptionZone;

    public Dropdown dropdown;

    GameObject activeDescription;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowDescription()
    {


        activeDescription = Instantiate(descriptivePanel);
        activeDescription.transform.SetParent(DescriptionZone.transform, false);
        

        //Debug.Log(GetComponentInChildren<Text>().text);
        string newDescription;
            
        try {
            newDescription = allProblemsList.transform.Find(GetComponentInChildren<Text>().text).GetComponent<DescriptionText>().GetDescription();
        } catch(Exception e)
        {
            newDescription = allActionsList.transform.Find(GetComponentInChildren<Text>().text).GetComponent<DescriptionText>().GetDescription();
        }

        activeDescription.GetComponentInChildren<TMP_Text>().SetText(newDescription);
        
    }
   
    public void DestroyDescription()
    {
        Destroy(activeDescription);
    }
}
