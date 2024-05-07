using System;

class Program
{
    static void Main(string[] args)
    {
        // Create a new instance of the Job class
        Job job1 = new Job();
        // Set the values of the job instance
        job1._company = "Microsoft";
        job1._jobTitle = "Software Engineer";
        job1._startYear = 2015;
        job1._endYear = 2018;

        // Create a new instance of the Job class
        Job job2 = new Job();
        // Set the values of the job instance
        job2._company = "Apple";
        job2._jobTitle = "Software Developer";
        job2._startYear = 2018;
        job2._endYear = 2020;

        // Create a new instance of the Resume class
        Resume resume = new Resume();
        // Set the values of the resume instance
        resume._name = "Nick Wilkins";
        // Add the job instances to the jobs list
        resume._jobs.Add(job1);
        resume._jobs.Add(job2);

        // Call the Display method of the resume instance
        resume.Display();
    }
}