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
    
    public partial class AJUSTEPRECIO
    {
        public long IDAJUSTEPRECIO { get; set; }
        public Nullable<long> IDPRODUCTO { get; set; }
        public Nullable<decimal> PRECIOVIGENTE { get; set; }
        public Nullable<System.DateTime> FECHAINICIOAJUSTEPRECIO { get; set; }
        public Nullable<System.DateTime> FECHAFINAJUSTEPRECIO { get; set; }
    
        public virtual PRODUCTO PRODUCTO { get; set; }
    }
}
