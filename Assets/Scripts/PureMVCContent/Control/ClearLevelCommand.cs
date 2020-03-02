using PureMVC.Interfaces;
using PureMVC.Patterns;
using PureMVCContent.View;

namespace PureMVCContent.Control
{
    public class ClearLevelCommand : SimpleCommand
    {
        public override void Execute(INotification notification)
        {
            var mediator = MyFacade.Instance.RetrieveMediator(GameMediator.NAME) as GameMediator;
            mediator.ClearCircles();
        }
    }
}