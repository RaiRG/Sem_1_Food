namespace DaoDatabase
{
    public class PersonalInformation : Entity<PersonalInformation>
    {
        public string Mail { get; set; }

        public string StringValue { get; set; }

        public string HashCode { get; set; }
    }
}