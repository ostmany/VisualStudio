//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SysVYC.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class EMPRESA
    {
        public EMPRESA()
        {
            this.CLIENTE = new HashSet<CLIENTE>();
            this.FIADOR = new HashSet<FIADOR>();
            this.REFERENCIACOMERCIAL = new HashSet<REFERENCIACOMERCIAL>();
        }
    
        public int IDEMPRESA { get; set; }
        public string NOMBREEMPRESA { get; set; }
        public string DIRECCIONEMPRESA { get; set; }
        public string TELEFONOEMPRESA { get; set; }
    
        public virtual ICollection<CLIENTE> CLIENTE { get; set; }
        public virtual ICollection<FIADOR> FIADOR { get; set; }
        public virtual ICollection<REFERENCIACOMERCIAL> REFERENCIACOMERCIAL { get; set; }
    }
}
