namespace AukzionLibrary.DBContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            Sold = new HashSet<Sold>();
        }

        public int Id { get; set; }

        [StringLength(200)]
        public string Name { get; set; }

        [Column(TypeName = "money")]
        public decimal? StartPrice { get; set; }

        [Column(TypeName = "money")]
        public decimal? SellPrice { get; set; }

        public bool? Status { get; set; } //чи доступний для продажу даний товар

        [StringLength(2000)]
        public string Photo { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sold> Sold { get; set; }
    }
}
