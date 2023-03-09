namespace Project_Sem3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AnswerResult")]
    public partial class AnswerResult
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int IdRegistratedUser { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CompetitionId { get; set; }

        public string Answer { get; set; }

        public double? Mark { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }

        public virtual Competition Competition { get; set; }

        public virtual Registration Registration { get; set; }
    }
}
