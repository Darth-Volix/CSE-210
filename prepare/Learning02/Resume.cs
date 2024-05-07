using System;

public class Resume
{
    // Initialize the variables for the job class
    public string _name = "";
    public List<Job> _jobs = new List<Job>();

    // method to display the resume information
    public void Display()
    {
        Console.WriteLine("");
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");
        foreach (Job job in _jobs)
        {
            job.Display();
        }
        Console.WriteLine("");
    }
}