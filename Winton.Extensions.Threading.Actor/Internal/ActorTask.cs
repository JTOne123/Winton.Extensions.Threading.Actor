using System.Threading.Tasks;

namespace Winton.Extensions.Threading.Actor.Internal
{
    internal static class ActorTask
    {
        public static bool IsActorTask(this Task self)
        {
            return self.AsyncState is ActorTaskContext;
        }

        public static void Cancel(this Task self)
        {
            var context = self.AsyncState as ActorTaskContext;
            context?.Canceller.Cancel();
        }
    }
}