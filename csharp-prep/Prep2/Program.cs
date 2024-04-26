using System;

class Program
{
    static void Main(string[] args)
    {
        // Prompt the user for their grade percentage
        Console.WriteLine("");
        Console.Write("What is your grade percentage? ");
        string user_input = Console.ReadLine();
        // Convert user input to an integer
        int grade_percentage = int.Parse(user_input);
        // Declare the letter grade variable outside the if statements
        string letter_grade;

        // Determine the letter grade based on the percentage
        if (grade_percentage >= 90)
        {
            letter_grade = "A";
        }
        else if (grade_percentage >= 80)
        {
            letter_grade = "B";
        }
        else if (grade_percentage >= 70)
        {
            letter_grade = "C";
        }
        else if (grade_percentage >= 60)
        {
            letter_grade = "D";
        }
        else
        {
            letter_grade = "F";
        }

        // Determine the sign (+ or -) based on the last digit of the percentage
        string sign = "";
        int last_digit = grade_percentage % 10;
        if (last_digit >= 7)
        {
            sign = "+";
        }
        else if (last_digit < 3)
        {
            sign = "-";
        }

        // Handle exceptional cases (A+, F+, F-)
        if (letter_grade == "A" && sign == "+")
        {
            letter_grade = "A";
        }
        else if (letter_grade == "F")
        {
            sign = ""; 
        }

        // Display the final grade (letter grade + sign)
        Console.WriteLine($"Your grade: {letter_grade}{sign}");

        // Determine if they passed the class
        if (grade_percentage >= 70)
        {
            Console.WriteLine("Congratulations, You have passed the class!");
            Console.WriteLine("");
        }
        else
        {
            Console.WriteLine("You have not passed and will need to retake the course.");
            Console.WriteLine("");
        }
    }
}