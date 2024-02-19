namespace WebAPI.Models
{
    public class Etudiant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }

        public Etudiant(int id, string name, string lastname)
        {
            Id = id;
            Name = name;
            Lastname = lastname;
        }
    }
}
