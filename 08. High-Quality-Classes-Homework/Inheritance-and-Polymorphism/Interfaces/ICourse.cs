namespace InheritanceAndPolymorphism.Interfaces
{
    using System.Collections.Generic;

    public interface ICourse
    {
        string Name { get; set; }

        string TeacherName { get; set; }

        IList<string> Students { get; set; }
    }
}
