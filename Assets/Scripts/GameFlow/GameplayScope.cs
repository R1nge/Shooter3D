using Misc;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace GameFlow
{
    public class GameplayScope : LifetimeScope
    {
        [SerializeField] private PlayerInput playerInput;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterComponentInNewPrefab(playerInput, Lifetime.Singleton);
            builder.RegisterEntryPoint<CursorLocker>().AsSelf();
            builder.RegisterEntryPoint<EntryPoint>().AsSelf();
        }
    }
}