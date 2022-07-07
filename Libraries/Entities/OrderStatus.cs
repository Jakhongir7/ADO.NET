using System;
using System.Collections.Generic;
using System.Text;

namespace Libraries.Entities
{
    public enum OrderStatus
    {
        NotStarted,
        Loading,
        InProgress,
        Arrived,
        Unloading,
        Cancelled,
        Done
    }
}
