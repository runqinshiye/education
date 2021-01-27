using MirthConnectFX.Interfaces;
using MirthConnectFX.Model;
using MirthConnectFX.Utility;
using System;
using System.Collections.Generic;

namespace MirthConnectFX
{
    public class EventsService : ServiceBase, IEventsService
    {
        public EventsService(IMirthConnectRequestFactory mirthConnectRequestFactory, IMirthConnectSession session)
            : base(mirthConnectRequestFactory, session, "events")
        {
        }

        public List<Event> GetEvents(int? maxEventId, 
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
                              string serverId = "")
        {
            var request = CreateRequest();
            //request.Execute();

            // Add Url Datat
            if (startDate.HasValue)                 request.AddUrlData("startDate", startDate.Value.ToString("yyyy-MM-ddTHH:mm:ss.fff") + "-0700");
            if (endDate.HasValue)                   request.AddUrlData("endDate", endDate.Value.ToString("yyyy-MM-ddTHH:mm:ss.fff") + "-0700");
            if (!string.IsNullOrEmpty(eventName))   request.AddUrlData("name", eventName);
            if (!string.IsNullOrEmpty(outcome))     request.AddUrlData("outcome", outcome);
            if (limit.HasValue)                     request.AddUrlData("limit", limit.ToString());

            var response = request.ExecuteGet();

            return response.Content.ToObject<EventList>().Events;

        }

        public void RemoveAllEvents()
        {
            var request = CreateRequest().ForOperation(Operations.Events.RemoveAllEvents);
            request.Execute();
        }
    }
}