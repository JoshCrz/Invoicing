using System;
using System.Collections.Generic;
using System.Text;

namespace EntityModels
{
    public class IAuditableEntity
    {
        public int CreatedByUserID { get; set; } = 0;
        public int ModifiedByUserID { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateModified { get; set; }
    }
}
