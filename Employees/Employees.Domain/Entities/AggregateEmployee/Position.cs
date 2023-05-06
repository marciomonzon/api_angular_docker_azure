using Employees.Domain.Entities.Base;
using Employees.Domain.Entities.Enums;

namespace Employees.Domain.Entities.AggregateEmployee
{
    public class Position : EntityBase
    {
        public string Description { get; private set; }
        public Employee Employee { get; set; }
        public PositionTypeEnum OccupationType { get; private set; }

        public Position(string description,
                          PositionTypeEnum occupationType)
        {
            Description = description;
            OccupationType = occupationType;
        }
    }
}
