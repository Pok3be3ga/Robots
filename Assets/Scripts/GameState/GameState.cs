using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    protected GameStateManager gameStateManager;
    public virtual void Init(GameStateManager _gameStateManager)
    {
        gameStateManager = _gameStateManager;
    }
    bool wasSet;

    public virtual void EnterFirstTime()
    {

    }

    public virtual void Enter()
    {
        if (!wasSet)
        {
            EnterFirstTime();
            wasSet = true;
        }
    }
    public virtual void Exit()
    {

    }

}
