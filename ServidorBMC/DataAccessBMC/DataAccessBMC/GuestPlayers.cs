//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccessBMC
{
    using System;
    using System.Collections.Generic;
    
    public partial class GuestPlayers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GuestPlayers()
        {
            this.LobbyPlayers = new HashSet<LobbyPlayers>();
        }
    
        public int GuestID { get; set; }
        public string Username { get; set; }
        public Nullable<System.DateTime> JoinDate { get; set; }
        public int StatusID { get; set; }
    
        public virtual StatusPlayer StatusPlayer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LobbyPlayers> LobbyPlayers { get; set; }
    }
}
