namespace Exceptions_Homework
{
    using System;

    public class ExamResult
    {
        private int grade;
        private int minGrade;
        private int maxGrade;
        private string comments;

        public ExamResult(int grade, int minGrade, int maxGrade, string comments)
        {
            if (minGrade < 0)
            {
                throw new Exception();
            }

            if (maxGrade <= minGrade)
            {
                throw new Exception();
            }

            if (string.IsNullOrEmpty(comments))
            {
                throw new Exception();
            }

            this.Grade = grade;
            this.MinGrade = minGrade;
            this.MaxGrade = maxGrade;
            this.Comments = comments;
        }

        public int Grade
        {
            get
            {
                return this.grade;
            }

            private set
            {
                if (value < this.MinGrade || value > this.MaxGrade)
                {
                    string message = string
                        .Format("Grade must be in range [{0}..{1}].", this.MinGrade, this.MaxGrade);

                    throw new ArgumentOutOfRangeException("grade", message);
                }

                this.grade = value;
            }
        }

        public int MinGrade
        {
            get
            {
                return this.minGrade;
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("minGrade", "MinGrade cannot be negative.");
                }

                this.minGrade = value;
            }
        }

        public int MaxGrade
        {
            get
            {
                return this.maxGrade;
            }

            private set
            {
                if (value < this.MinGrade)
                {
                    throw new ArgumentOutOfRangeException(
                        "maxGrade",
                        "MaxGrade must be greater than or equal to MinGrade.");
                }

                this.maxGrade = value;
            }
        }

        public string Comments
        {
            get
            {
                return this.comments;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("comments", "Comments field must not be empty.");
                }

                this.comments = value;
            }
        }
    }
}
