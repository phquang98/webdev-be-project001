using webdev_be_project001.Models;

namespace webdev_be_project001.Dto
{
    public class OwnerDto
    {
        public int IdColumn { get; set; }
        public string NameColumn { get; set; }
        public string GymColumn { get; set; }
        public Country CountryColumn { get; set; }
    }
}
