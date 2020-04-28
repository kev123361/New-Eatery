using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatChanges : MonoBehaviour
{
    public int moneyChange = 0;
    public int ratingsChange = 0;
    public int workersChange = 0;

    GameObject stateMachine;


    public void OnEnable()
    {
        StateMachine.PassTurn += ChangeStats;
    }

    public void OnDisable()
    {
        StateMachine.PassTurn -= ChangeStats;

    }

    // Start is called before the first frame update
    void Start()
    {
        stateMachine = GameObject.FindGameObjectWithTag("StateMachine");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeStats()
    {
        if (moneyChange + ratingsChange + workersChange != 0)
        {
            Debug.Log(gameObject.name + " passively changed stats by: money " + moneyChange + ", ratings " + ratingsChange + ", workers " + workersChange);
            stateMachine.GetComponent<Resources>().ChangeResources(moneyChange, ratingsChange, workersChange);
        }
    }
}
