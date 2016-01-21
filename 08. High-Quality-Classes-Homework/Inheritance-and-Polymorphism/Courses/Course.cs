namespace InheritanceAndPolymorphism.Courses
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Interfaces;

    public abstract class Course : ICourse
    {
        private string name;
        private IList<string> students;

        protected Course(
            string courseName, 
            string teacherName = null, 
            IList<string> students = null)
        {
            this.Name = courseName;
            this.TeacherName = teacherName;
            this.Students = students;
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("name", "Value cannot be null or empty.");
                }

                this.name = value;
            }
        }

        public string TeacherName { get; set; }

        public IList<string> Students
        {
            get
            {
                // lazy loading (it is a thing)
                if (this.students == null)
                {
                    this.students = new List<string>();
                }

                return this.students;
            }

            set
            {
                this.students = value;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append(this.GetType().Name);
            result.Append("{ Name = ");
            result.Append(this.Name);
            if (this.TeacherName != null)
            {
                result.Append("; Teacher = ");
                result.Append(this.TeacherName);
            }

            result.Append("; Students = ");
            result.Append(this.GetStudentsAsString());
            return result.ToString();
        }

        private string GetStudentsAsString()
        {
            if (this.Students == null || this.Students.Count == 0)
            {
                return "{ }";
            }

            return "{ " + string.Join(", ", this.Students) + " }";
        }
    }
}
