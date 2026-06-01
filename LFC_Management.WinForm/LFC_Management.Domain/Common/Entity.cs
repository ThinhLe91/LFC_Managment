using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFC_Management.Domain.Common
{
    public abstract class Entity
    {
        // Khóa chính dùng chung cho tất cả các thực thể kế thừa từ Entity
        public int Id { get; protected set; }
    }
}
