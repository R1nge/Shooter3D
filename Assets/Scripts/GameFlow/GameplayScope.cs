using VContainer;
using VContainer.Unity;

namespace GameFlow
{
    public class GameplayScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<EntryPoint>().AsSelf();
        }
    }
}