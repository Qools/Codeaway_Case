using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : Singleton<GameController>
{
    private bool isGameEnded = false;

    public void Init()
    { 
        SetStatus(Status.ready);
    }


    private void OnEnable()
    {
        BusSystem.OnLivesReduced += OnLivesReduced;
    }

    private void OnDisable()
    {
        BusSystem.OnLivesReduced -= OnLivesReduced;
    }

    private void OnNewLevelLoad()
    {
        
    }

    private void OnLivesReduced(int _lives)
    {
        if (isGameEnded)
        {
            return;
        }

        if (_lives <= 0)
        {
            Debug.Log("Game Over");
            isGameEnded = true;
        }
    }
}
