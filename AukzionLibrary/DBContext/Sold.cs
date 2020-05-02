namespace AukzionLibrary.DBContext
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sold")]
    public partial class Sold
    {
        public int Id { get; set; }

        public int? ID_Product { get; set; }

        public int? ID_Buyer { get; set; }

        public virtual Buyer Buyer { get; set; }

        public virtual Product Product { get; set; }
    }
}
