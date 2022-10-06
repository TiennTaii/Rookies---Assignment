using System;

public class Clock
{
    private int _second;
    public delegate void ClockTickHandler(object clock, TimeInfoEventArgs timeInfoEvent);
    public event ClockTickHandler clockTickEvent;

    public void OnTick(object clock, TimeInfoEventArgs timeInfoEvent)
    {
        if (clockTickEvent != null)
        {
            clockTickEvent(clock, timeInfoEvent);
        }
    }

    public void Run()
    {
        while (!Console.KeyAvailable)
        {
            System.Threading.Thread.Sleep(1000);
            DateTime now = DateTime.Now;

            if (now.Second != this._second)
            {
                TimeInfoEventArgs timeInfoEventArgs = new TimeInfoEventArgs(
                    now.Hour,
                    now.Minute,
                    now.Second
                );

                OnTick(this, timeInfoEventArgs);
            }
        }
    }
}

