using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace OrderOut.EF.Models
{
    public class UserRole : BaseEntity
    {
        [NotNull]
        public long UserId { get; set; }
        [NotNull]
        public long RoleId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }

    }
}
