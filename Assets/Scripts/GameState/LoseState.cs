using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseState : GameState
{
    [SerializeField] LoseWindow loseWindow;
    public override void Enter()
    {
        base.Enter();
        Time.timeScale = 0;
        loseWindow.Show();
    }
}
