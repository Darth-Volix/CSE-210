using System;
public class Course
{
    public string _courseCode = "";
    public string _courseName = "";
    public int _creditHours = 0;
    public string _color = "";
 
    // methods
    public void DisplayCourseInfo()
    {
        Console.WriteLine("Course Code: " + _courseCode);
        Console.WriteLine("Course Name: " + _courseName);
        // Console.WriteLine("Credit Hours: " + _creditHours);
        // Console.WriteLine("Color: " + _color);
    }
}


// notes:
// A method is a function that is part of a class 
// an object is an instance of a class
// a class is a blueprint for an object