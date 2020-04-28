using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveStatChanges : MonoBehaviour
{
    public int moneyChange = 0;
    public int ratingsChange = 0;
    public int workersChange = 0;

    public int daysToComplete = 1;
    public bool isProblem;

    GameObject stateMachine;

    public bool selected = false;
    public bool doubleSelected = false;


    public void OnEnable()
    {
        StateMachine.PassTurn += ChangeStats;
        TurnChoice.NewChoice += Deselect;
    }

    public void OnDisable()
    {
        StateMachine.PassTurn -= ChangeStats;
        TurnChoice.NewChoice += Deselect;

    }

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.tag == "Problem") { isProblem = true; }
        stateMachine = GameObject.FindGameObjectWithTag("StateMachine");
    }

    public void Deselect()
    {
        selected = false;
        doubleSelected = false;
    }

    public void Select()
    {
        if (selected)
        {
            doubleSelected = true;
        }
        selected = true;
    }

    public void ChangeStats()
    {
        Debug.Log(gameObject.name + " was selected: " + selected);
        if (selected)
        {
            
            Debug.Log(gameObject.name + " actively changed stats by: money " + moneyChange + ", ratings " + ratingsChange + ", workers " + workersChange);
            stateMachine.GetComponent<Resources>().ChangeResources(moneyChange, ratingsChange, workersChange);
            Debug.Log(gameObject.name + " was an active problem.");
            if (isProblem && daysToComplete <= 1)
            {
                Destroy(gameObject);
            } else if (isProblem && daysToComplete > 1)
            {
                daysToComplete -= 1;
                if (doubleSelected)
                {
                    Debug.Log(gameObject.name + " actively changed stats by: money " + moneyChange + ", ratings " + ratingsChange + ", workers " + workersChange);
                    stateMachine.GetComponent<Resources>().ChangeResources(moneyChange, ratingsChange, workersChange);
                    Debug.Log(gameObject.name + " was double selected");
                    if (isProblem && daysToComplete <= 1)
                    {
                        Destroy(gameObject);
                    }
                    else if (isProblem && daysToComplete > 1)
                    {
                        daysToComplete -= 1;
                    }
                }
            }
        }

        
    }
}
