namespace MyOOPExam20Dec2015.Models.Attacks
{
    using Interfaces;
    public class PutridFart : IAttack
    {
        private const int PutridFartModifier = 1;
        public PutridFart()
        {
        }

        public int Modifier
        {
            get { return PutridFartModifier; }
        }
    }
}
