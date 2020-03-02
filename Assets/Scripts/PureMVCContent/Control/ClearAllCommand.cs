using PureMVC.Interfaces;
using PureMVC.Patterns;
using PureMVCContent.Model;

namespace PureMVCContent.Control
{
    public class ClearAllCommand : SimpleCommand
    {
        public override void Execute(INotification notification)
        {
            SendNotification(MyFacade.CLEAR_LEVEL);
            var proxy = MyFacade.Instance.RetrieveProxy(OtherProxy.NAME) as OtherProxy;
            proxy.SetLevel(1);
        }
    }
}