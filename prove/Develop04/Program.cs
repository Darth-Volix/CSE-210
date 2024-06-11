using System;

class Program
{
    static void Main(string[] args)
    {


        ListingActivity listingActivity = new ListingActivity("Listing Activity", "This activity will help you reflect on the positive aspects of your life. You will be prompted with questions that will help you recognize the good in your life.");
        listingActivity.Run();
    }
}