using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BrokenMachine : MonoBehaviour
{
    [SerializeField]Image repairBar;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(repairBar.fillAmount <= 1)
            repairBar.fillAmount += Time.deltaTime;
    }
}
