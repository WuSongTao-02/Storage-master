//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Warehouse
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Warehouse()
        {
            this.WarehouseStorage = new HashSet<WarehouseStorage>();
        }
    
        public int WarId { get; set; }
        public string WarType { get; set; }
        public string WarOrder { get; set; }
        public string WarPerson { get; set; }
        public int VenId { get; set; }
        public int AudiId { get; set; }
        public System.DateTime CreateTime { get; set; }
        public int IsDelete { get; set; }
        public string Remake { get; set; }
    
        public virtual Auditing Auditing { get; set; }
        public virtual Vendor Vendor { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WarehouseStorage> WarehouseStorage { get; set; }
    }
}
