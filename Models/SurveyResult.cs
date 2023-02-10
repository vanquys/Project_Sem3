namespace Project_Sem3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SurveyResult")]
    public partial class SurveyResult
    {
        public int Id { get; set; }

        public int? MemberId { get; set; }

        public virtual Member Member { get; set; }
    }
}
