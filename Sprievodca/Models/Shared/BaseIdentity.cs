using JsonApiDotNetCore.Resources;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sprievodca.Models.Shared
{
    public abstract class BaseIdentity : Identifiable<long>
    {
        /// <summary>
        /// Identifier
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override long Id { get => base.Id; set => base.Id = value; }
    }
}
