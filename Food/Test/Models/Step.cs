namespace Test
{
    public class Step : Entity<Step>
    {
        //TODO: think about img
        public int DishID { get; set; }
        public int NumberOfStep { get; set; }
        public string Description { get; set; }
        public string Img { get; set; }
    }
}