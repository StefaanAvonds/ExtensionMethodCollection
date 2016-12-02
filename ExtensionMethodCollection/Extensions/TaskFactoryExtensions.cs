using System;
using System.Threading;
using System.Threading.Tasks;

namespace ExtensionMethodCollection.Extensions
{
    /// <summary>
    /// Extension-methods for the TaskFactory-object.
    /// </summary>
    public static class TaskFactoryExtensions
    {
        /// <summary>
        /// Start a new task that will run continuously for a given amount of time.
        /// </summary>
        /// <param name="taskFactory">Provides access to factory methods for creating System.Threading.Tasks.Task and System.Threading.Tasks.Tasks`1 instances.</param>
        /// <param name="action">The action delegate to execute asynchronously.</param>
        /// <param name="cancellationToken">The Sytem.Threading.Tasks.TaskFactory.CancellationToken that will be assigned to the new task.</param>
        /// <param name="delay">The interval between invocations of the callback.</param>
        /// <returns>The started System.Threading.Tasks.Task.</returns>
        public static Task StartNewContinuously(this TaskFactory taskFactory, Action action, CancellationToken cancellationToken, TimeSpan delay)
        {
            return taskFactory.StartNew(async () =>
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    try
                    {
                        action.Invoke();
                    }
                    catch (AggregateException ae)
                    {
                        ae = ae.Flatten();
                        foreach (Exception ex in ae.InnerExceptions)
                        {
                            string message = ex.Message;
                        }
                    }
                    finally
                    {
                        await Task.Delay(delay);
                    }
                }
            },
            cancellationToken);
        }

        /// <summary>
        /// Try to start a new Task. If an exception has been thrown, it will get caught.
        /// </summary>
        /// <param name="taskFactory">Provides access to factory methods for creating System.Threading.Tasks.Task and System.Threading.Tasks.Task`1 instances.</param>
        /// <param name="action">The action delegate to execute asynchronously.</param>
        /// <param name="cancellationToken">The System.Threading.Tasks.TaskFactory.CancellationToken that will be assigned to the new task.</param>
        /// <returns></returns>
        public static Task TryStartNew(this TaskFactory taskFactory, Action action, CancellationToken cancellationToken)
        {
            try
            {
                return taskFactory.StartNew(action, cancellationToken);
            }
            catch (AggregateException ae)
            {
                ae = ae.Flatten();

                foreach (Exception ex in ae.InnerExceptions)
                {
                    string message = ex.Message;
                }
            }

            return null;
        }
    }
}
