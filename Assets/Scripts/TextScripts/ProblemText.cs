using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ProblemText : MonoBehaviour
{
    public GameObject problemList;
    TMP_Text problemText;

    private void OnEnable()
    {
        StateMachine.NewTurn += UpdateProblemText;
    }

    private void OnDisable()
    {
        StateMachine.NewTurn -= UpdateProblemText;

    }

    // Start is called before the first frame update
    void Start()
    {
        problemText = GetComponent<TMP_Text>();

        UpdateProblemText();
    }


    public void UpdateProblemText()
    {
        string newProblemText = "Current Problems:\n";

        foreach (StatChanges problem in problemList.GetComponentsInChildren<StatChanges>())
        {
            if (problem.name != "Take A Break")
            {
                newProblemText += problem.name + " - Actions needed: " + problem.GetComponent<ActiveStatChanges>().daysToComplete + "\n";
            }
        }

        problemText.text = newProblemText;
    }
}
