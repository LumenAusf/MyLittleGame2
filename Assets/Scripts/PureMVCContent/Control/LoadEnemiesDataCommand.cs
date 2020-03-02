using PureMVC.Interfaces;
using PureMVC.Patterns;
using PureMVCContent.Model;
using UnityEngine;

namespace PureMVCContent.Control
{
    public class LoadEnemiesDataCommand : SimpleCommand
    {
        public override void Execute(INotification notification)
        {
            Debug.Log("LoadEnemiesDataCommand");
            
            var data = Resources.Load("Scriptables/Enemies") as EnemiesCatalog;
            var proxy = MyFacade.Instance.RetrieveProxy(EnemyProxy.NAME) as EnemyProxy;
            foreach (var dataItem in data.Items)
            {
                proxy.AddEnemy(dataItem);
            }
        }
    }
}