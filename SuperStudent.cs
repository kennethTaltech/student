public class SuperStudent : Student
{
    public SuperStudent(string name) : base(name) { } // Constructor for SuperStudent
    private bool _onHold = false; // Indicates if the student is on hold

    public void ToggleOnHold()
    {
        _onHold = !_onHold; // Toggle the on-hold status of the student
    }
    protected override void CongratulateStudent()
    {
        // Congratulate if credits and grade count meet graduation criteria
        if (_credits >= 200 && _grades.Count >= 4)
        {
            Console.WriteLine($"Congratulations, you have {_credits} credits, you have graduated! Your average grade is {CalculateGPA()}.");
        }
    }

    public override void AddGrade(int grade)
    {
        // Prevent adding grades if student is on hold or not active
        if (_onHold || !_isActive) return;

        // Validate grade range
        if (grade < 1 || grade > 5)
        {
            Console.WriteLine("Cannot add the grade, invalid value");
            return; // Exit if the grade is invalid
        }

        _grades.Add(grade); // Add valid grade to the list
        if (grade == 5) Console.WriteLine("Good job!"); // Acknowledge a perfect score
    }

    public override void ConvertGrade(int percentage)
    {
        // Prevent adding grades if student is on hold or not active
        if (_onHold || !_isActive) return;

        // Use pattern matching to determine the appropriate message based on percentage
        string message = percentage switch
        {
            < 0 or > 100 => "Cannot find the grade, invalid value", // Handle out-of-bounds percentage
            < 51 => "Cannot add grade 0 to the student.", // Message for low percentage
            _ => $"Converted it to {ConvertPercentageToGrade(percentage)}, added to student." // Conversion message
        };

        // Add the converted grade if percentage is valid
        if (percentage >= 51 && percentage <= 100)
        {
            _grades.Add(ConvertPercentageToGrade(percentage));
        }
        Console.WriteLine(message); // Print the respective message
    }

    // Calculate the GPA by averaging the grades and rounding to three decimal places
    public decimal CalculateGPA() =>
        Math.Round((decimal)_grades.Sum() / _grades.Count,3); // Ensure the division is in decimal
}