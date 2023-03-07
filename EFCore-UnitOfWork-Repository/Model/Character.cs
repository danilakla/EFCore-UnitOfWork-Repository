using System;
using System.Collections.Generic;

namespace EFCoreRelationshipsTutorial.Models
{
    public partial class Character
    {
        public Character()
        {
            Skills = new HashSet<Skill>();
        }

        public int CharacterId { get; set; }
        public string CharacterName { get; set; } = null!;
        public int UserId { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual Weapon Weapon { get; set; } = null!;

        public virtual ICollection<Skill> Skills { get; set; }
    }
}
