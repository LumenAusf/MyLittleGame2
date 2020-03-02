using PureMVC.Interfaces;
using PureMVC.Patterns;

namespace PureMVCContent.Control
{
    public class FillFirstCircleCommand : SimpleCommand
    {
        public override void Execute(INotification notification)
        {
            var circle = notification.Body as CircleController;
            circle.EnableMover();
        }
    }
}