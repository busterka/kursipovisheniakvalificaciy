//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace kursipovisheniakvalificaciy.entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Polzovateli
    {
        public int ID_polzovatelya { get; set; }
        public string Login { get; set; }
        public string Parol { get; set; }
        public int Rol { get; set; }
        public int Kod_pola { get; set; }
    
        public virtual Pol Pol { get; set; }
        public virtual Roli Roli { get; set; }
    }
}
