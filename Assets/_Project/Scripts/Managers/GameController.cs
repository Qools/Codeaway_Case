﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : Singleton<GameController>
{ 
    public void Init()
    { 
        SetStatus(Status.ready);
    }


    private void OnEnable()
    {
       
    }

    private void OnDisable()
    {
       
    }

    private void OnNewLevelLoad()
    {
        
    }
}
