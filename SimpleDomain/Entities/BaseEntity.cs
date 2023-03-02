using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleDomain.Entities
{
    public class BaseEntity
    {
        /*
        * Entidade comum para todos os outros modelos
        TODO: Criar os Campos: CreatedBy, UpdatedBy, DeletedBy
        TODO: Criar os campos: UpdatedData, UpdatedLastData
        */
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public bool IsDeleted { get; set; } = false;
    }
}