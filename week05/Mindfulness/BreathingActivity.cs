public class BreathingActivity : Activity
{
    public BreathingActivity() : base(
        "Breathing Activity",
        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public void Run()
    {
        DisplayStartMessage();

        DateTime end = DateTime.Now.AddSeconds(GetDuration());
        bool breatheIn = true;

        while (DateTime.Now < end)
        {
            if (breatheIn)
            {
                Console.Write("Breathe in... ");
            }
            else
            {
                Console.Write("Breathe out... ");
            }

            int remaining = (int)(end - DateTime.Now).TotalSeconds;
            int pauseTime = Math.Min(4, remaining);
            if (pauseTime > 0)
            {
                ShowCountdown(pauseTime);
            }

            Console.WriteLine();
            breatheIn = !breatheIn;
        }

        DisplayEndMessage();
    }
}
