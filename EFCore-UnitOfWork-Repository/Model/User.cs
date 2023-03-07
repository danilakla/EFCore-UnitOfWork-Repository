using System;
using System.Collections.Generic;

namespace EFCoreRelationshipsTutorial.Models
{
    public partial class User
    {
        public User()
        {
            Characters = new HashSet<Character>();
        }

        public int Id { get; set; }
        public string Username { get; set; } = null!;

        public virtual ICollection<Character> Characters { get; set; }
    }
}
