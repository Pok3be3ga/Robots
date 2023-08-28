using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountiniusEffect : Effect
{
    [SerializeField] float colldown;
    float timer;
    public void ProccesFrame(float _frameTime)
    {
        timer += _frameTime;
        if(timer > colldown)
        {
            Produce();
            timer = 0;

        }

    }

    protected virtual void Produce()
    {

    }
}
