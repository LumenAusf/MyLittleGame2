using PureMVC.Interfaces;
using PureMVC.Patterns;
using PureMVCContent.Model;
using UnityEngine;

namespace PureMVCContent.Control
{
    public class LoadGameDataCommand : SimpleCommand
    {
        public override void Execute(INotification notification)
        {
            Debug.Log("LoadGameDataCommand");
            
            var data = Resources.Load("Scriptables/GameConfiguration") as GameConfiguration;
            var proxy = MyFacade.Instance.RetrieveProxy(GameConfigurationProxy.NAME) as GameConfigurationProxy;
            proxy.AddData(data);
        }
    }
}