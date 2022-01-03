using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace OiPubAssignment.Entities
{
    public class Paper
    {
        [Key]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Column("title")]

        public string Title { get; set; }
        [Column("paperauthor")]
        [ForeignKey("PaperAuthor")]
        public Guid? PaperAuthorId { get; set;}

        [Column("datapublished")]
        public DateTime DatePublished { get; set; }
        [Column("referencecount")]
        public long ReferenceCount { get; set; }
        [Column("numberofcitations")]
        public long NumberOfCitations { get; set; }

        #region virtual
        public virtual List<PaperAuthor> PaperAuthors { get; set; }
        #endregion
    }
}
