

namespace StudentTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // Creating instances of students
            BachelorStudent bachelorStudent = new BachelorStudent("John Doe");
            MasterStudent masterStudent = new MasterStudent("Jane Smith", "#398249JNUIUIDJF");
            SuperStudent superStudent = new SuperStudent("Alice Johnson");
            SuperStudent author = new SuperStudent("Kenneth Ruut");

            // Adding credits to students and testing graduation messages
            Console.WriteLine("\n--- Adding credits ---");
            bachelorStudent.AddCredits(50);
            bachelorStudent.AddCredits(130); // Should trigger graduation message
            masterStudent.AddCredits(100);
            masterStudent.AddCredits(20);  // Total 120, should trigger graduation message
            superStudent.AddCredits(200);   // Should not trigger graduation message yet
            author.AddCredits(350);   // Should not trigger graduation message yet

            // Adding grades
            Console.WriteLine("\n--- Adding grades ---");
            bachelorStudent.AddGrade(3);
            bachelorStudent.AddGrade(6);   // Invalid grade
            bachelorStudent.AddGrade(5);   // Should print "Good job!"
            bachelorStudent.AddGrade(2);

            masterStudent.AddGrade(4);
            masterStudent.AddGrade(5);     // Should print "Good job!"
            masterStudent.AddGrade(0);     // Invalid grade
            masterStudent.AddGrade(3);

            superStudent.AddGrade(4);
            superStudent.AddGrade(5);      // Should print "Good job!"
            superStudent.AddGrade(2);
            superStudent.AddGrade(3);      // Now they have 4 grades

            author.AddGrade(5); // Should print "Good job!"
            author.AddGrade(5); // Should print "Good job!"
            author.AddGrade(5); // Should print "Good job!"
            author.AddGrade(5); // Should print "Good job!"
            author.AddGrade(5); // Should print "Good job!"
            author.AddGrade(5000); // Invalid grade

            // Test ConvertGrade method
            Console.WriteLine("\n--- Converting percentages to grades ---");
            bachelorStudent.ConvertGrade(87); // Should convert to 4
            bachelorStudent.ConvertGrade(73); // Should convert to 3
            bachelorStudent.ConvertGrade(32); // Should not add it
            masterStudent.ConvertGrade(45);   // Should convert to 1 (only for Master's students)
            masterStudent.ConvertGrade(95);   // Should convert to 5
            superStudent.ConvertGrade(55);    // Should convert to 1
            superStudent.ConvertGrade(99);    // Should convert to 5
            author.ConvertGrade(100);    // Should convert to 5
            author.ConvertGrade(108);    // Invalid percentage

            // Print all student information
            Console.WriteLine("\n--- Printing student information ---");
            bachelorStudent.PrintInfo();
            bachelorStudent.PrintGrades();
            bachelorStudent.PrintLastGrade();

            masterStudent.PrintInfo();
            masterStudent.PrintGrades();
            masterStudent.PrintLastGrade();

            superStudent.PrintInfo();
            superStudent.PrintGrades();
            superStudent.PrintLastGrade();

            author.PrintInfo();
            author.PrintGrades();
            author.PrintLastGrade();

            // Test invalid grade scenario
            bachelorStudent.AddGrade(10);  // Invalid grade

            // Adding credits for super student and testing graduation condition
            author.AddCredits(10); // Total 360 credits now

            // Printing final information
            Console.WriteLine("\n--- Final student information ---");
            author.PrintInfo();
            author.PrintGrades();
            author.PrintLastGrade();           
        }
    }
}
