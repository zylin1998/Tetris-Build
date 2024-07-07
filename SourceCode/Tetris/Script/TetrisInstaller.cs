using Loyufei.DomainEvents;
using Tetris;
using UnityEngine;
using Zenject;

public class TetrisInstaller : MonoInstaller
{
    [SerializeField]
    private GameObject _Dot;

    public override void InstallBindings()
    {
        #region Factory

        Container
            .BindMemoryPool<Dot, Dot.Pool>()
            .FromComponentInNewPrefab(_Dot)
            .AsCached();

        #endregion

        #region Event

        SignalBusInstaller.Install(Container);

        Container
            .DeclareSignal<IDomainEvent>()
            .WithId(Declarations.Tetris);

        Container
            .Bind<IDomainEventBus>()
            .To<DomainEventBus>()
            .AsCached()
            .WithArguments(Declarations.Tetris);

        Container
            .Bind<DomainEventService>()
            .AsSingle();


        #endregion

        #region Data Structure

        Container
            .Bind<GridQuery>()
            .AsSingle();

        Container
            .Bind<Report>()
            .AsSingle();

        Container
            .Bind<TetrisGrid>()
            .AsSingle();

        Container
            .Bind<PlayerInput>()
            .AsSingle();

        Container
            .Bind<TetrominoMaker>()
            .AsSingle();

        #endregion

        #region Model

        Container
            .Bind<TetrisModel>()
            .AsSingle();

        #endregion

        #region Presenter

        Container
            .Bind<PlayerPresenter>()
            .AsSingle()
            .NonLazy();

        Container
            .Bind<TetrisGridPresenter>()
            .AsSingle()
            .NonLazy();

        Container
            .Bind<TetrisInfoPresenter>()
            .AsSingle()
            .NonLazy();

        Container
            .Bind<TetrisPresenter>()
            .AsSingle()
            .NonLazy();

        #endregion
    }
}