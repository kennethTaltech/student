public class MasterStudent : Student
{
    public string MasterStudentNumber { get; private set; }
    // Constructor for MasterStudent
    public MasterStudent(string name, string number) : base(name)
    {
        MasterStudentNumber = number;
    }
    protected override void CongratulateStudent()
    {
        // Congratulate if credits reach or exceed the graduation threshold for Master's degree
        if (_credits >= 120)
        {
            Console.WriteLine($"Congratulations, you have {_credits} credits, you have graduated with a Master's degree!");
        }
    }

    public override void ConvertGrade(int percentage)
    {
        // Prevent adding grades if student is on hold or not active
        if (!_isActive) return;

        // Similar to the base ConvertGrade, but with Master-specific grade conversions
        string message = percentage switch
        {
            < 0 or > 100 => "Cannot find the grade, invalid value", // Handle out-of-bounds percentage
            < 40 => "Cannot add grade 0 to the student.", // Message for very low percentage
            >= 40 and <= 60 => $"Converted it to 1, added to student.", // Conversion for low scores
            _ => $"Converted it to {ConvertPercentageToGrade(percentage)}, added to student." // Default conversion message
        };

        // Add the converted grade based on percentage ranges for Master's students
        if (percentage >= 40 && percentage <= 100)
        {
            _grades.Add(percentage < 60 ? 1 : ConvertPercentageToGrade(percentage));
        }

        Console.WriteLine(message); // Print the conversion message
    }
}