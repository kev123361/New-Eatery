using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoveroverDescription : MonoBehaviour
{

    private void OnEnable()
    {
        TurnChoice.NewChoice += DestroyThis;
    }

    private void OnDisable()
    {
        TurnChoice.NewChoice -= DestroyThis;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DestroyThis()
    {
        Destroy(gameObject);
    }
}
