//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcApplication1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TypesOfEquipment
    {
        public TypesOfEquipment()
        {
            this.Equipments = new HashSet<Equipment>();
        }
    
        public string Type { get; set; }
        public float Flops { get; set; }
        public int Core { get; set; }
        public int Bufer { get; set; }
    
        public virtual ICollection<Equipment> Equipments { get; set; }
    }
}