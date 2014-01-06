using System;

public class ExamResult
{
    public int Grade { get; private set; }
    public int MinGrade { get; private set; }
    public int MaxGrade { get; private set; }
    public string Comments { get; private set; }

    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        if (grade < 0 || minGrade < 0 || maxGrade <= minGrade)
        {
            string message = string.Format("Incorrect grade values grade={0}, minGrade={1}, maxGrade={2}", grade, minGrade, maxGrade);
            throw new ArgumentOutOfRangeException(message);
        }

        if (comments == null || comments == string.Empty)
        {
            comments = "No comments";
        }

        this.Grade = grade;
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Comments = comments;
    }
}
