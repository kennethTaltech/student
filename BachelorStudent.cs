public class BachelorStudent : Student
{
    public BachelorStudent(string name) : base(name) { } // Constructor for BachelorStudent
    protected override void CongratulateStudent()
    {
        // Congratulate if credits reach or exceed the graduation threshold for Bachelor's degree
        if (_credits >= 180)
        {
            Console.WriteLine($"Congratulations, you have {_credits} credits, you have graduated with a Bachelor's degree!");
        }
    }
}
