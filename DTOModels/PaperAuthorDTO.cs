using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OiPubAssignment.DTOModels
{
    public class PaperAuthorDTO
    {
        public string Title { get; set;}
        public DateTime DatePublished { get; set; }
        public long ReferenceCount { get; set; }
        public long NumberOfCitations { get; set; }
        public Guid AuthorId { get; set;}

    }
}
