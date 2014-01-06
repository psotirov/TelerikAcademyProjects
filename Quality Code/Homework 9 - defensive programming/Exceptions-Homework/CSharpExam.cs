using System;

public class CSharpExam : Exam
{
    public int Score { get; private set; }
    private const int MaxScore = 100;

    public CSharpExam(int score)
    {
        if (score < 0 || score > MaxScore)
        {
            throw new ArgumentOutOfRangeException("Illegal score value when trying to create CSharpExam object");
        }

        this.Score = score;
    }

    public override ExamResult Check()
    {
        return new ExamResult(this.Score, 0, MaxScore, "Exam results calculated by score.");
    }
}
