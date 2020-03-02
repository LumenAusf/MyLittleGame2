using PureMVC.Interfaces;
using PureMVC.Patterns;
using PureMVCContent.Model;

namespace PureMVCContent.Control
{
    public class PlayNextLevelCommand : SimpleCommand
    {
        public override void Execute(INotification notification)
        {
            SendNotification(MyFacade.HIDE_WIN_POPUP);
            SendNotification(MyFacade.CLEAR_LEVEL);
            var proxy = MyFacade.Instance.RetrieveProxy(OtherProxy.NAME) as OtherProxy;
            var lvl = proxy.GetLevel();
            lvl++;
            proxy.SetLevel(lvl);
            SendNotification(MyFacade.PLAY, lvl);
        }
    }
}