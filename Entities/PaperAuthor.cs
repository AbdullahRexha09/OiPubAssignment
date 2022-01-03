using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OiPubAssignment.Entities
{
    public class PaperAuthor
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        [ForeignKey("paperid")]
        public Guid PaperId { get; set; }

        [ForeignKey("authorid")]
        public Guid AuthorId { get; set; }



        #region virtual
        public virtual Author Author { get; set; }
        public virtual Paper Paper { get; set; }
        #endregion
    }
}
