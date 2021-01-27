using MirthConnectFX.Model;
using System;
using System.Collections.Generic;

namespace MirthConnectFX.Interfaces
{
    public interface IEventsService
    {
        List<Event> GetEvents(int? maxEventId,
                              int? minEventId,
                              DateTime? startDate,
                              DateTime? endDate,
                              int? offset,
                              int? limit,
                              int? userId,
                              string Level = "",
                              string eventName = "",
                              string outcome = "",
                              string ipAddress = "",
                              string serverId = "");
        void RemoveAllEvents();
    }
}