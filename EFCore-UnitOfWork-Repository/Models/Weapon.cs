using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace EFCoreRelationshipsTutorial
{
    public class Weapon
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Damage { get; set; } = 10;
        [JsonIgnore]
        public Character Character { get; set; }
        [AllowNull]
        public int CharacterId { get; set; }
    }
}
