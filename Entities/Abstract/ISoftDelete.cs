using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Abstract
{
   public interface ISoftDelete
    {
        public bool IsDeleted { get; set; }
    }
}
