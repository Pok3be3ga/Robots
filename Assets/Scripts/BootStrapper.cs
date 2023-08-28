using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BootStrapper : MonoBehaviour
{
    [SerializeField] GameStateManager gameStateManager;
    private void Awake()
    {
        gameStateManager.Init();
    }
}
