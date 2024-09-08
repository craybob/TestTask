using System.Drawing;
using UnityEngine;
using Zenject;

public class GameMonoInstaller : MonoInstaller
{
    [SerializeField] private Player _playerPrefab;
    [SerializeField] private GameDataManager _gameDataManager;

    public override void InstallBindings()
    {
        
        Container.BindInterfacesAndSelfTo<Player>().FromInstance(_playerPrefab).AsSingle();
        Container.Bind<MoveHandler>().AsSingle().NonLazy();
        Container.Bind<InterractableHandler>().AsSingle().NonLazy();
        Container.BindInterfacesAndSelfTo<GameDataManager>().FromInstance(_gameDataManager).AsSingle();
        //Container.Bind<LoadingCircle>().WithId("Loading_background").FromComponentInHierarchy();
    }
}