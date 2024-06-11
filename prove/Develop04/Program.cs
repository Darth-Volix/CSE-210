using System;

class Program
{
    static void Main(string[] args)
    {
        MindfulnessActivity mindfulnessActivity = new MindfulnessActivity("Mindful Breathing", "Focus on your breath to calm your mind.");
        mindfulnessActivity.Start();
        mindfulnessActivity.End();
    }
}