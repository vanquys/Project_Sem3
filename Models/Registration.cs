namespace Project_Sem3.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Registration")]
    public partial class Registration
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [Column(TypeName = "date")]
        public DateTime? JoinDate { get; set; }

        [StringLength(128)]
        public string RollNo { get; set; }

        [StringLength(50)]
        public String Class { get; set; }

        [StringLength(50)]
        public string Specification { get; set; }

        [StringLength(50)]
        public string Section { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }
    }
}
