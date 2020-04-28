using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProblemManager : MonoBehaviour
{
    public GameObject activeProblemList;
    public StateMachine sm;

    public GameObject OnlineComplaints;
    public GameObject NewSupplies;
    public GameObject Rent;
    public GameObject Break;

    int problemChance = 70;
    bool addedComplaint = true;

    private void OnEnable()
    {
        StateMachine.Upkeep += PotentiallyAddNewProblems;
    }

    private void OnDisable()
    {
        StateMachine.Upkeep -= PotentiallyAddNewProblems;

    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    public void PotentiallyAddNewProblems()
    {
        if (sm.GetDay() == 19) { problemChance = 40; }
        float chance = Random.Range(0f, 100f);

        if (!addedComplaint && chance > problemChance && sm.GetDay() != 25) 
        {
            AddProblem(OnlineComplaints);
            addedComplaint = true;
        } else { addedComplaint = false; }

        if (sm.GetDay() == 14)
        {
            AddProblem(NewSupplies);
        }

        if (sm.GetDay() == 25)
        {
            AddProblem(Break);
        }

        if (sm.GetDay() == 26)
        {
            AddProblem(Rent);
        }
    }

    public void AddProblem(int num)
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }

        for (int i = 0; i < num; i++)
        {


            StatChanges[] allProblems = GetComponentsInChildren<StatChanges>();
            Debug.Log(allProblems.Length);
            GameObject chosenProblem = allProblems[Random.Range(0, allProblems.Length)].gameObject;

            GameObject newProblem = Instantiate(chosenProblem, activeProblemList.transform);
            newProblem.name = chosenProblem.name;
        }

        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }

    public void AddProblem(GameObject problem)
    {
        problem.SetActive(true);

        GameObject newProblem = Instantiate(problem, activeProblemList.transform);
        newProblem.name = problem.name;

        problem.SetActive(false);
    }
}
