//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LibrarianWorkplace
{
    using System;
    using System.Collections.Generic;
    
    public partial class Users
    {
        public int id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public int Age { get; set; }
        public int Phone { get; set; }
        public string Email { get; set; }
        public Nullable<int> idBook { get; set; }
    
        public virtual Books Books { get; set; }
    }
}
