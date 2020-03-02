using PureMVC.Interfaces;
using PureMVC.Patterns;
using PureMVCContent.Model;
using PureMVCContent.Model.Enemies;
using PureMVCContent.View;
using UnityEngine;

namespace PureMVCContent.Control
{
    public class CreateLevelCommand : SimpleCommand
    {
        public override void Execute(INotification notification)
        {
            var mediator = MyFacade.Instance.RetrieveMediator(GameMediator.NAME) as GameMediator;
            var proxy = MyFacade.Instance.RetrieveProxy(GameConfigurationProxy.NAME) as GameConfigurationProxy;

            mediator.ClearCircles();

            var level = (int) notification.Body;
            var sproxy = MyFacade.Instance.RetrieveProxy(OtherProxy.NAME) as OtherProxy;
            sproxy.SetLevel(level);
            
            var circlesCount = proxy.GetCirclesCount();
            if (circlesCount < 3)
            {
                SendNotification(MyFacade.CREATE_LEVEL_FAIL);
                return;
            }

            var rings = EnemyTypes.Block;

            var circleF = mediator.GetInstanceCircle();
            var weight = proxy.GetLevelWeight(level);
            var finalWeight = Random.Range(weight.x, weight.y);
            var speed = proxy.GetSpeedMovables();
            circleF.Init(finalWeight, speed, rings, true);
            SendNotification(MyFacade.FILL_FIRST_CIRCLE, circleF);
            mediator.AddCircle(circleF);

            for (var i = 0; i < circlesCount - 2; i++)
            {
                var circleM = mediator.GetInstanceCircle();
                circleM.transform.localPosition = new Vector3(0, 0, (i + 1) * circleM.SizeZ);
                finalWeight = Random.Range(weight.x, weight.y);
                circleM.Init(finalWeight, speed, rings, i % 2 != 0);
                SendNotification(MyFacade.FILL_MID_CIRCLE, circleM);
                mediator.AddCircle(circleM);
            }

            var circleL = mediator.GetInstanceCircle();
            circleL.transform.localPosition = new Vector3(0, 0, (circlesCount - 1) * circleL.SizeZ);
            finalWeight = Random.Range(weight.x, weight.y);
            circleL.Init(finalWeight, speed, rings, circlesCount % 2 != 0);
            SendNotification(MyFacade.FILL_LAST_CIRCLE, circleL);
            mediator.AddCircle(circleL);

            var proxyOther = MyFacade.Instance.RetrieveProxy(OtherProxy.NAME) as OtherProxy;
            SendNotification(MyFacade.SHOW_GAME);
            mediator.PlayerToFirstCircle(proxy.GetSpeedPlayer());
        }
    }
}