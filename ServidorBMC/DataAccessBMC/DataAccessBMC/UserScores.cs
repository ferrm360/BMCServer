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
    
    public partial class UserScores
    {
        public int ScoreID { get; set; }
        public int PlayerID { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
    
        public virtual Player Player { get; set; }
    }
}
