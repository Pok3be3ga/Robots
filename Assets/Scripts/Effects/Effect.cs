using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Effect : ScriptableObject
{
    public string Name;
    [TextArea(1, 3)]
    public string Description;
    public Sprite Sprite;
    public int Level = 1;

    protected EffectManager effectManager;
    protected Player player;
    protected EnemyManager enemyManager;

    public virtual void Initialize(EffectManager _effectManager, EnemyManager _enemyManager, Player _player)
    {
        effectManager = _effectManager;
        player = _player;
        enemyManager = _enemyManager;
    }


    public virtual void Activate()
    {
        Level++;
    }
}
