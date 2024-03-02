namespace BirthdayCelebrations.Models
{
    using BirthdayCelebrations.Contracts;
    public class Pet : IBirthable
    {
        public Pet(string name, string birthdate)
        {
            this.Name = name;
            this.Birthdate = birthdate;
        }
        public string Birthdate { get; set; }
        public string Name { get; set; }
    }
}
