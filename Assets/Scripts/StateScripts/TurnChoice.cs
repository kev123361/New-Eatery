using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnChoice : MonoBehaviour
{
    public StateMachine sm;

    GameObject actionList;
    GameObject problemList;

    Dropdown choiceList;
    public Dropdown otherChoiceList;

    public GameObject Break;

    public delegate void OnNewChoice();
    public static event OnNewChoice NewChoice;
    // Start is called before the first frame update
    void Start()
    {
        sm = GameObject.FindGameObjectWithTag("StateMachine").GetComponent<StateMachine>();

        actionList = GameObject.FindGameObjectWithTag("ActionList");
        problemList = GameObject.FindGameObjectWithTag("ProblemList");
        choiceList = GetComponent<Dropdown>();

        PopulateWithActions();
        NewChoiceSelected();
    }

    private void OnEnable()
    {
        StateMachine.NewTurn += PopulateWithActions;

    }

    private void OnDisable()
    {
        StateMachine.NewTurn -= PopulateWithActions;
    }

    public void PopulateWithActions()
    {
        if (sm.GetDay() != 25)
        {
            List<string> newOptions = new List<string>();

            StatChanges[] currActions = actionList.GetComponentsInChildren<StatChanges>();
            StatChanges[] currProblems = problemList.GetComponentsInChildren<StatChanges>();

            for (int i = 0; i < currActions.Length; i++)
            {
                newOptions.Add(currActions[i].gameObject.name);
            }

            for (int i = 0; i < currProblems.Length; i++)
            {
                newOptions.Add(currProblems[i].gameObject.name);
            }

            Debug.Log(newOptions);
            choiceList.ClearOptions();
            choiceList.AddOptions(newOptions);
        } else
        {
            List<string> newOptions = new List<string>();
            newOptions.Add(Break.name);

            choiceList.ClearOptions();
            choiceList.AddOptions(newOptions);
            
        }
        

        
    }

    public void NewChoiceSelected()
    {
        NewChoice.Invoke();
        GameObject.Find(choiceList.options[choiceList.value].text).GetComponent<ActiveStatChanges>().Select();
        GameObject.Find(otherChoiceList.options[otherChoiceList.value].text).GetComponent<ActiveStatChanges>().Select();
    }
}
