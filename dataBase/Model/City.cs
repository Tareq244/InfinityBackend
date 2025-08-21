using System.ComponentModel.DataAnnotations;

namespace InfinityBack.dataBase
{
    public class City
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(100)]
        public string Name { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }

        public ICollection<Address> Addresses { get; set; }
    }
}
