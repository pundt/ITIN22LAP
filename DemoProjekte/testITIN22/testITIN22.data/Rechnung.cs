//------------------------------------------------------------------------------
// <auto-generated>
//     Der Code wurde von einer Vorlage generiert.
//
//     Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten der Anwendung.
//     Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace testITIN22.data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Rechnung
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Rechnung()
        {
            this.AlleRechnungsWaren = new HashSet<RechnungsWare>();
        }
    
        public int ID { get; set; }
        public int ID_Benutzer { get; set; }
        public System.DateTime Datum { get; set; }
    
        public virtual Benutzer Benutzer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RechnungsWare> AlleRechnungsWaren { get; set; }
    }
}
