using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StateMachine : MonoBehaviour
{
    public int day;

    public GameObject ActiveProblemList;
    public GameObject AllProblemList;

    public GameObject winning;

    public GameObject Doordash;
    public bool isDeliveryOn = false;

    public GameObject IncorrectOnlineInfo;
    public GameObject DesignWebsite;
    public GameObject Employees;
    public GameObject IncorrectQuickEats;
    public GameObject ChristmasWarning;

    Resources resources;

    public delegate void OnPassTurn();
    public static event OnPassTurn PassTurn;

    public delegate void OnUpkeep();
    public static event OnUpkeep Upkeep;

    public delegate void OnNewTurn();
    public static event OnNewTurn NewTurn;

    // Start is called before the first frame update
    void Start()
    {
        day = 1;
        resources = GetComponent<Resources>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextTurn()
    {
        day++;
        if (isDeliveryOn) { resources.ChangeMoney(1); }
        StartCoroutine(TurnPass());
        
    }

    private IEnumerator TurnPass()
    {
        yield return (CallTurnPass());
        yield return (CallUpkeep());
        yield return (CallNewTurn());
        
        if (day == 5)
        {
            Doordash.SetActive(true);
        }

        if (day == 7)
        {
            if (isDeliveryOn)
            {
                DesignWebsite.SetActive(true);
            } else
            {
                AllProblemList.GetComponent<ProblemManager>().AddProblem(IncorrectOnlineInfo);
            }
        }

        if (day == 9)
        {
            ChristmasWarning.SetActive(true);
        }

        if (day == 12)
        {
            AllProblemList.GetComponent<ProblemManager>().AddProblem(Employees);
        }

        if (day == 15)
        {
            if (isDeliveryOn)
            {
                AllProblemList.GetComponent<ProblemManager>().AddProblem(IncorrectQuickEats);
            }
            else
            {
                AllProblemList.GetComponent<ProblemManager>().AddProblem(IncorrectOnlineInfo);
            }
        }

        if (day == 21)
        {
            winning.SetActive(true);
        }
    }

    private IEnumerator CallTurnPass()
    {
        PassTurn.Invoke();
        yield return null;
    }

    private IEnumerator CallUpkeep()
    {
        Upkeep.Invoke();
        yield return null;
    }
    
    private IEnumerator CallNewTurn()
    {
        NewTurn.Invoke();
        yield return null;
    }

    public int GetDay()
    {
        return day + 10;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AcceptDelivery()
    {
        isDeliveryOn = true;
    }

}
