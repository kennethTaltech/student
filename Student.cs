public interface IStudent
{
    // Method to add credits to the student
    void AddCredits(int amount);

    // Method to add a grade to the student
    void AddGrade(int grade);

    // Method to convert a percentage to a grade
    void ConvertGrade(int percentage);

    // Method to print all grades of the student
    void PrintGrades();

    // Method to print student information
    void PrintInfo();

    // Method to print the last grade of the student
    void PrintLastGrade();
}

public abstract class Student : IStudent
{
    private string _name; // Student's name
    protected int _credits = 0; // Total credits earned by the student
    protected bool _isActive = true; // Status indicating if the student is active
    protected List<int> _grades = new List<int>(); // List to store the student's grades

    protected Student(string name) // Constructor to initialize the student's name
    {
        _name = name;
    }

    public void AddCredits(int amount)
    {
        // Only add positive amounts of credits and congratulate the student if applicable
        _credits += amount > 0 ? amount : 0;
        CongratulateStudent();
    }
    protected abstract void CongratulateStudent(); // Abstract method to congratulate student on graduation, different for all students
    // Calculate the grade by adjusting the percentage and dividing by 10
    protected int ConvertPercentageToGrade(int percentage) => (int)Math.Ceiling((decimal)(percentage - 50) / 10);
    

    public virtual void AddGrade(int grade)
    {
        // Prevent adding grades if student is on hold or not active
        if (!_isActive) return;

        // Validate grade range
        if (grade < 1 || grade > 5)
        {
            Console.WriteLine("Cannot add the grade, invalid value");
            return; // Exit if the grade is invalid
        }

        _grades.Add(grade); // Add valid grade to the list
        if (grade == 5) Console.WriteLine("Good job!"); // Acknowledge a perfect score
    }


    public virtual void ConvertGrade(int percentage)
    {
        // Prevent adding grades if student is on hold or not active
        if (!_isActive) return;

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

    // Print all grades or indicate if none are available
    public void PrintGrades() =>
        Console.WriteLine(_grades.Count > 0 ? $"{_name}'s grades: {string.Join(", ", _grades)}." : $"Student {_name} has no grades.");

    // Print the student's name and total credits
    public void PrintInfo() =>
        Console.WriteLine($"{_name} has {_credits} credits.");

    // Print the last grade the student received
    public void PrintLastGrade() =>
        Console.WriteLine(_grades.Count > 0 ? $"{_name}'s last grade: {_grades[_grades.Count - 1]}" : $"Student {_name} has no grades.");

}