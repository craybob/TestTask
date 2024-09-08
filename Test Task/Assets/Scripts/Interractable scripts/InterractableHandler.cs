using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class InterractableHandler : IInterractable
{
    public Image loadingLine;

    public float fillSpeed = 1f;

    public Effect effect;
    
    public Effect GetEffect()
    {
        throw new System.NotImplementedException();
    }

    public void Interract()
    {
        throw new System.NotImplementedException();
    }

    
}
