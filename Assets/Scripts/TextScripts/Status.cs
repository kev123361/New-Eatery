using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Status : MonoBehaviour
{
    Resources resources;

    TMP_Text statusText;

    private void OnEnable()
    {
        StateMachine.NewTurn += UpdateStatus;

    }

    private void OnDisable()
    {
        StateMachine.NewTurn -= UpdateStatus;
    }

    // Start is called before the first frame update
    void Start()
    {
        resources = GameObject.FindGameObjectWithTag("StateMachine").GetComponent<Resources>();
        statusText = GetComponent<TMP_Text>();
        UpdateStatus();
       

    }

    public void UpdateStatus()
    {
        statusText.text = "Money: " + resources.GetMoney() +
           "\nPopularity: " + resources.GetRatings() +
           "\nMorale: " + resources.GetWorkers();
    }
}
