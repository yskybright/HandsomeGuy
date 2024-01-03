using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseScene : MonoBehaviour
{
    private void Start()
    {
        
    }

    protected virtual void Init()
    {

    }

    public abstract void Clear();
}
