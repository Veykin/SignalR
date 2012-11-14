﻿using IISServer = Microsoft.Web.Administration;

namespace Microsoft.AspNet.SignalR.FunctionalTests.Infrastructure.IIS
{
    public static class IISExtensions
    {
        public static void StartAndWait(this IISServer.Site site)
        {
            var wait = new PollingWait(() => site.Start(), () => site.State == IISServer.ObjectState.Started);

            wait.Invoke();
        }

        public static void StopAndWait(this IISServer.Site site)
        {
            var wait = new PollingWait(() => site.Stop(), () => site.State == IISServer.ObjectState.Stopped);

            wait.Invoke();
        }

        public static void StartAndWait(this IISServer.ApplicationPool appPool)
        {
            var wait = new PollingWait(() => appPool.Start(), () => appPool.State == IISServer.ObjectState.Started);

            wait.Invoke();
        }

        public static void StopAndWait(this IISServer.ApplicationPool appPool)
        {
            var wait = new PollingWait(() => appPool.Stop(), () => appPool.State == IISServer.ObjectState.Stopped);

            wait.Invoke();
        }

        public static void WaitForState(this IISServer.ApplicationPool appPool, IISServer.ObjectState state)
        {
            new PollingWait(() => { }, () => appPool.State == state).Invoke();
        }

        public static void WaitForState(this IISServer.Site site, IISServer.ObjectState state)
        {
            new PollingWait(() => { }, () => site.State == state).Invoke();
        }
    }
}
