using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LFC_Management.Domain.Common
{
    // Aggregate kế thừa từ Entity, đại diện cho thực thể quản lý cao nhất của một cụm.
    public abstract class AggregateRoot : Entity
    {
        // Hiện tại để trống, sau này dùng để chứa cá sự kiện Domain (Domain Events)
    }
}
