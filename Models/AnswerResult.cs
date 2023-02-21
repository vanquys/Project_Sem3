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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(128)]
        public string UserId { get; set; }

        public int? CompetitionId { get; set; }

        public string Answer { get; set; }

        public double? Mark { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Date { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }

        public virtual Competition Competition { get; set; }
    }
}
