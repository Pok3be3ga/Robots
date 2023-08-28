using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    GameState currentGameState;


    [SerializeField] GameState menuState;
    [SerializeField] GameState actionState;
    [SerializeField] GameState pauseState;
    [SerializeField] GameState winState;
    [SerializeField] GameState loseState;
    [SerializeField] GameState cardState;


    public void Init()
    {
        menuState.Init(this);
        actionState?.Init(this);
        pauseState?.Init(this);
        winState?.Init(this);
        loseState?.Init(this);
        cardState.Init(this);

        SetGameState(menuState);
    }
    public void SetGameState(GameState _gameState)
    {
        if (currentGameState)
        {
            currentGameState.Exit();
        }
        currentGameState = _gameState;
        _gameState.Enter();
        
    }

    public void SetMenu()
    {
        SetGameState(menuState);
    }

    public void SetAction()
    {
        SetGameState(actionState);
    }

    public void SetPause()
    {
        SetGameState(pauseState);
    }

    public void SetWin()
    {
        SetGameState(winState);
    }

    public void SetLose()
    {
        SetGameState(loseState);
    }
    public void SetCardState()
    {
        SetGameState(cardState);
    }
}
