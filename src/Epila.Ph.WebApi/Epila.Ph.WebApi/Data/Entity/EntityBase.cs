using System;

namespace Epila.Ph.WebApi.Data.Entity
{
    public class EntityBase
    {
        //Add common Properties here that will be used for all your entities
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
