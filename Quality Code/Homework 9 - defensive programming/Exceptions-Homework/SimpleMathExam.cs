using System;

public class SimpleMathExam : Exam
{
    public int ProblemsSolved { get; private set; }

    public SimpleMathExam(int problemsSolved)
    {
        if (problemsSolved < 0 || problemsSolved > 10)
        {
            throw new ArgumentOutOfRangeException("Incorrect number of problems");
        } 

        this.ProblemsSolved = problemsSolved;
    }

    public override ExamResult Check()
    {
        if (ProblemsSolved == 1)
        {
            return new ExamResult(4, 2, 6, "Average result: nothing done.");
        }
        else if (ProblemsSolved == 2)
        {
            return new ExamResult(6, 2, 6, "Average result: nothing done.");
        }

        // there is some gap between permittable porblemsSolved (between 0 and 10)
        // and check results (lack of information how to proceed)
        // so I have decided to implement default bad result instead of exception
        return new ExamResult(2, 2, 6, "Bad result: nothing done.");
    }
}
