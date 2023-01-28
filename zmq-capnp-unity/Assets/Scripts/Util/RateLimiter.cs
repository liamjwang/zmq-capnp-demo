using System;
using UnityEngine;

public class RateLimiter
{
    private float lastTime;
    private readonly float rateHz;

    public RateLimiter(float rateHz)
    {
        this.rateHz = rateHz;
        lastTime = 0;
    }

    
    public void Run(Action action)
    {
        if (Mathf.Approximately(rateHz, 0))
        {
            return;
        }
        if (!(Time.time - lastTime > 1 / rateHz)) return;
        lastTime = Time.time;
        action();
    }
}