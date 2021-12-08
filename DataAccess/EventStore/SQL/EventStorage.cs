using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EventStore.SQL
{
    public class IEventData
    {
        int Id { get; set; }
        //  Event Name
        string Type { get; set; }
        //  Aggregate Id
        Guid StreamId { get; set; }
        //  AutoIncremented Identofying stage
        int Version { get; set; }
        //  Allow for data date traveling e.g Show me what the aggregate looked like before 12/08/19
        DateTime Created { get; set; }
        //  Serialized JSON Event Store
        string Payload { get; set; }
    }
}


