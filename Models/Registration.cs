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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Registration()
        {
            AnswerResults = new HashSet<AnswerResult>();
        }

        public int Id { get; set; }

        [StringLength(128)]
        public string UserId { get; set; }

        [StringLength(50)]
        public string ClassName { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [Column(TypeName = "date")]
        public DateTime? JoinDate { get; set; }

        [StringLength(50)]
        public string Specification { get; set; }

        [StringLength(50)]
        public string Section { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AnswerResult> AnswerResults { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }
    }
}
