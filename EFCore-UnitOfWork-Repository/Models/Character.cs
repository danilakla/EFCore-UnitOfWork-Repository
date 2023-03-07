using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace EFCoreRelationshipsTutorial
{
    [Table("Characters")]
    public class Character
    {
        [Column("character_id")]
        public int Id { get; set; }
        [Column("character_name")]

        public string Name { get; set; } = string.Empty;

        [JsonIgnore]
        public User User { get; set; }
        public int UserId { get; set; }
        public Weapon Weapon { get; set; }
        public List<Skill> Skills { get; set; }
    }
}
