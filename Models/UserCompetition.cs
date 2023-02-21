namespace Project_Sem3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UserCompetition")]
    public partial class UserCompetition
    {
        [Key]
        [Column(Order = 0)]
        public string UserId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CompetitionId { get; set; }

        public bool? isStatus { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }

        public virtual Competition Competition { get; set; }
    }
}
