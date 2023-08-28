using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartMenuState : GameState
{
    [SerializeField] Button tapToStartButton;
    [SerializeField] GameObject startMenuObject;

    public override void Init(GameStateManager _gameStateManager)
    {
        base.Init(_gameStateManager);
        tapToStartButton.onClick.AddListener(_gameStateManager.SetAction);
    }


    public override void Enter()
    {
        base.Enter();
        startMenuObject.SetActive(true);
    }

    public override void Exit()
    {
        base.Exit();
        startMenuObject.SetActive(false);
    }
}

