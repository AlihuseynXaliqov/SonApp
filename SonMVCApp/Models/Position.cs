using SonMVCApp.Models.Base;

namespace SonMVCApp.Models
{
    public class Position : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Agent> Agents { get; set; }
    }
}
