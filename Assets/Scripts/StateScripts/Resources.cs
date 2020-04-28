using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resources : MonoBehaviour
{
    public int money = 30;
    public int ratings = 30;
    public int workers = 30;

    public GameObject GameOver;


    private void OnEnable()
    {
        StateMachine.NewTurn += CheckResources;
    }

    private void OnDisable()
    {
        StateMachine.NewTurn -= CheckResources;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeResources(int moneyChange, int ratingsChange, int workersChange)
    {
        money += moneyChange;
        ratings += ratingsChange;
        workers += workersChange;
    }

    public void ChangeMoney(int moneyChange)
    {
        money += moneyChange;
    }

    public void ChangeRatings(int ratingsChange)
    {
        ratings += ratingsChange;
    }

    public int GetMoney() { return money; }
    public int GetRatings() { return ratings; }
    public int GetWorkers() { return workers; }

    public void CheckResources()
    {

        if (money <= 0 || ratings <= 0 || workers <= 0)
        {
            //game over
            GameOver.SetActive(true);
        }
    }
}
