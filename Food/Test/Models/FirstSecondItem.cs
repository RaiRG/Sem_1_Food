namespace Test
{
    public class FirstSecondItem
    {
        public FirstSecondItem()
        {
            
        }
        public FirstSecondItem(int first, int second)
        {
            FirstId = first;
            SecondId = second;
        }

        public int FirstId { get; set; }
        public int SecondId { get; set; }
    }
}