using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Day : MonoBehaviour
{
    public StateMachine sm;
    public TMP_Text text;

    private void OnEnable()
    {
        StateMachine.NewTurn += UpdateDay;
            
    }

    private void OnDisable()
    {
        StateMachine.NewTurn -= UpdateDay;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdateDay()
    {
        text.text = "December " + sm.GetDay();
    }
}
