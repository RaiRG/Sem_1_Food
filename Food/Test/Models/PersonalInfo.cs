namespace Test
{
    public class PersonalInfo : Entity<PersonalInfo>
    {
        public string Mail { get; set; }

        public string HashPassword { get; set; }
    }
}