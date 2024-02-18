using System;
using System.Threading;

public class Timer
{
    private Action _action;
    private int _interval;
    private bool _isRunning;
    
    public Timer(Action action, int interval)
    {
        _action = action;
        _interval = interval;
    }

    public void Start()
    {
        if (_isRunning)
            return;

        _isRunning = true;
        Thread thread = new Thread(RunTimer);
        thread.IsBackground = true;
        thread.Start();
    }

    public void Stop()
    {
        _isRunning = false;
    }

    private void RunTimer()
    {
        while (_isRunning)
        {
            _action();
            Thread.Sleep(_interval * 1000);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Timer timer = new Timer(PrintHello, 2);
        timer.Start();

        Timer timer1 = new Timer(Hello, 4);
        timer1.Start();

        Console.WriteLine("Timer started. Press any key to stop...");
        Console.ReadKey();

        timer.Stop();
        timer1.Stop();
        Console.WriteLine("Timer stopped.");
    }

    static void PrintHello()
    {
        Console.WriteLine("Hello");
    }

    static void Hello()
    {
        Console.WriteLine("World");
    }
}
