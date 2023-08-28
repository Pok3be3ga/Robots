using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionState : GameState
{
    [SerializeField] Joystick Joystick;
    [SerializeField] RigitbodyMove rigitbodyMove;

    [SerializeField] EnemyManager enemyManager;
    [SerializeField] ExpirienceManager expirienceManager;

    public override void EnterFirstTime()
    {
        base.EnterFirstTime();
        enemyManager.StartNewWave(0);
        expirienceManager.UpLevel();
    }
    public override void Enter()
    {
        base.Enter();
        Joystick.Activate();
        rigitbodyMove.enabled = true;

    }
    public override void Exit() 
    { 
        base.Exit(); 
        Joystick.Deactivate();
        rigitbodyMove.enabled = false;
    }

}
