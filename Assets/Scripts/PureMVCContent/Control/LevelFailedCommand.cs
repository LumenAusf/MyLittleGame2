using PureMVC.Interfaces;
using PureMVC.Patterns;

namespace PureMVCContent.Control
{
    public class LevelFailedCommand : SimpleCommand
    {
        public override void Execute(INotification notification)
        {
            SendNotification(MyFacade.SHOW_LOSE_POPUP);
        }
    }
}