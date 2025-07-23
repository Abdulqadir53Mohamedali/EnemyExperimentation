using UnityEngine;
using System;




namespace Utilities
{
    public abstract class Timer
    {

        protected float initialTime;
        protected float Time { get; set; }

        public bool IsRunning { get; protected set; }  

        public float Progress => Time / initialTime;

        public Action onTimerStart = delegate { };
        public Action onTimerStop = delegate { };
        
        protected Timer(float value)
        {
            initialTime = value;
            IsRunning = false;
        }

        
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        public void Start()
        {
            
            Time = initialTime;
            
            if (!IsRunning)
            {
                IsRunning = true;
                onTimerStop.Invoke();
            }
        }        
        
        public void Stop()
        {
            Time = initialTime;
            
       
            
            IsRunning = false;
            onTimerStop.Invoke();
            
        }

        public void Resume() => IsRunning = true;
        public void Pause() => IsRunning = false;

        public abstract void Tick(float deltaTime);
    }

    public class CountDownTimer : Timer
    {
        public CountDownTimer(float value) : base(value) { }

        public override void Tick(float deltaTime)
        {
            if(IsRunning && Time > 0)
            {
                Time -= deltaTime;
            }

            if(IsRunning && Time <= 0)
            {
                Stop();
            }
        }

        public bool IsFinished => Time <= 0;

        public void Reset() => Time = initialTime = 0;

        public void Reset (float newTime)
        {
            initialTime = newTime;
            Reset();
        }
    }
}
