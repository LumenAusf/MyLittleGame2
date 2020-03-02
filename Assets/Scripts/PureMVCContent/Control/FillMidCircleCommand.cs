using System.Linq;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using PureMVCContent.Model;
using UnityEngine;

namespace PureMVCContent.Control
{
    public class FillMidCircleCommand :SimpleCommand
    {
        public override void Execute(INotification notification)
        {
            var circle = notification.Body as CircleController;
            circle.EnableMover();

            var proxy = MyFacade.Instance.RetrieveProxy(EnemyProxy.NAME) as EnemyProxy;
            var enemy = proxy.Items.First(x => x.EnemyType == circle.RingType);
            if (enemy.IsOnlyOne)
            {
                var ee = circle.InstantiateEnemy(enemy);
                circle.AddEnemy(ee);
            }
            else
            {
                var count = circle.RealWeight / enemy.Weight;
                for (var i = 0; i < count; i++)
                {
                    var ee = circle.InstantiateEnemy(enemy);
                    var locY = circle.y + enemy.transform.localScale.y / 2f;
                    ee.transform.position = new Vector3(0, locY, 0);
                    ee.MagicPosValue = Random.Range(0f, 1f);
                    circle.AddEnemy(ee);
                }
            }
        }
    }
}