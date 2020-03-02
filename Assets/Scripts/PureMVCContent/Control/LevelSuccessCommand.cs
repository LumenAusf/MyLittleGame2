using PureMVC.Interfaces;
using PureMVC.Patterns;

namespace PureMVCContent.Control
{
    public class LevelSuccessCommand : SimpleCommand
    {
        public override void Execute(INotification notification)
        {
            SendNotification(MyFacade.CLEAR_LEVEL);
            SendNotification(MyFacade.SHOW_WIN_POPUP);
        }
    }
}