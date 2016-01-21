namespace MyOOPExam20Dec2015.Models.Attacks
{
    using Interfaces;
    public class Blobplode : IAttack
    {
        private const int BlobplodeModifier = 2;
        public Blobplode()
        {
        }

        public int Modifier
        {
            get { return BlobplodeModifier; }
        }
    }
}
