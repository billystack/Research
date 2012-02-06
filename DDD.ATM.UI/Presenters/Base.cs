using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
//using Fohjin.DDD.BankApplication.Views;

namespace DDD.ATM.UI.Presenters
{
	public abstract class Base<TView> where TView : class//, IView
    {
        protected Base(TView view)
        {
            HookUpViewEvents(view);
        }


        private void HookUpViewEvents(TView view)
        {
            var viewDefinedEvents = GetViewDefinedEvents();
            var viewEvents = GetViewEvents(view, viewDefinedEvents);
            var presenterEventHandlers = GetPresenterEventHandlers(viewDefinedEvents, this);

            foreach (var viewDefinedEvent in viewDefinedEvents)
            {
                var eventInfo = viewEvents[viewDefinedEvent];
                var methodInfo = GetTheEventHandler(viewDefinedEvent, presenterEventHandlers, eventInfo);

                WireUpTheEventAndEventHandler(view, eventInfo, methodInfo);
            }
        }

        private MethodInfo GetTheEventHandler(string viewDefinedEvent, IDictionary<string, MethodInfo> presenterEventHandlers, EventInfo eventInfo)
        {
            var substring = viewDefinedEvent.Substring(2);
            if (!presenterEventHandlers.ContainsKey(substring))
                throw new Exception(string.Format("\n\nThere is no event handler for event '{0}' on presenter '{1}' expected '{2}'\n\n", eventInfo.Name, GetType().FullName, substring));

            return presenterEventHandlers[substring];
        }

        private void WireUpTheEventAndEventHandler(TView view, EventInfo eventInfo, MethodInfo methodInfo)
        {
            var newDelegate = Delegate.CreateDelegate(typeof(EventAction), this, methodInfo);
            eventInfo.AddEventHandler(view, newDelegate);
        }

        private static IDictionary<string, MethodInfo> GetPresenterEventHandlers<TPresenter>(ICollection<string> actionProperties, TPresenter presenter)
        {
            return presenter
                .GetType()
                .GetMethods(BindingFlags.Instance | BindingFlags.Public)
                .Where(x => Contains(actionProperties, x))
                .ToList()
                .Select(x => new KeyValuePair<string, MethodInfo>(x.Name, x))
                .ToDictionary(x => x.Key, x => x.Value);
        }

        private static List<string> GetViewDefinedEvents()
        {
            return typeof(TView).GetEvents().Select(x => x.Name).ToList();
        }

        private static IDictionary<string, EventInfo> GetViewEvents(TView view)
        {
			var _actionProperties = typeof(TView).GetEvents().Select(x => x.Name).ToList();

            return view
                .GetType()
                .GetEvents()
                .Where(x => Contains(_actionProperties, x))
                .ToList()
                .Select(x => new KeyValuePair<string, EventInfo>(x.Name, x))
                .ToDictionary(x => x.Key, x => x.Value);
        }

        private static bool Contains(ICollection<string> actionProperties, EventInfo x)
        {
            return actionProperties.Contains(x.Name);
        }

        private static bool Contains(ICollection<string> actionProperties, MethodInfo x)
        {
            return actionProperties.Contains(string.Format("On{0}", x.Name));
        }
    }
}