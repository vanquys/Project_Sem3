namespace Project_Sem3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DataQuuestion")]
    public partial class DataQuuestion
    {
        public int Id { get; set; }

        public int CompetitionId { get; set; }

        [StringLength(150)]
        public string Answer { get; set; }

        [StringLength(150)]
        public string Question { get; set; }

        public virtual Competition Competition { get; set; }
    }
}
