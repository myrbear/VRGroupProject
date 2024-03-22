using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Timer
{
    public float SetTime { get; set; }
    public float ElapsedTime { get; set; }
    public float TimeLeft { get { return SetTime - ElapsedTime; } }
    public bool IsActive { get { return ElapsedTime < SetTime; } }

    public Timer(float setTime)
    {
        SetTime = setTime;

        ResetTimer();
    }

    public void RunTimer()
    {
        ElapsedTime += Time.deltaTime;

        if (ElapsedTime > SetTime)
        {
            ElapsedTime = SetTime;
        }
    }
    public void ResetTimer()
    {
        ElapsedTime = 0;
    }
}