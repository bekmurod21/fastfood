using FastFood.Domain.Commons;

namespace FastFood.Domain.Entities.Users
{
    public class Role:Auditable
    {
        public long UserId { get; set; }
        public string Name { get; set; }
    }
}
