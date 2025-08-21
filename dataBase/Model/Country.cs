using System.ComponentModel.DataAnnotations;

namespace InfinityBack.dataBase
{
    public class Country
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        public ICollection<City> Cities { get; set; }
    }
}
