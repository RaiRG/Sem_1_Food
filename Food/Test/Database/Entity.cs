namespace Test
{
    public class Entity<T>
    {
        public int Id { get; set; }
        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType())
                return false;
            var otherEntity = (Entity<T>) obj;
            return this.Id == otherEntity.Id;
        }
    }
}