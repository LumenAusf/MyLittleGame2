using System.Collections.Generic;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using UnityEngine;

namespace PureMVCContent.View
{
    public class WinPopupMediator : Mediator
    {
        public new const string NAME = "WinPopupMediator";

        private WinPopupView View;

        public WinPopupMediator(object viewComponent) : base(NAME, viewComponent)
        {
            View = ((GameObject) ViewComponent).GetComponent<WinPopupView>();
            Debug.Log("Win popup Mediator");
            View.ButtonNextLevel.onClick.AddListener(NextLevel);
        }

        private void NextLevel()
        {
            // SendNotification(MyFacade.HIDE_WIN_POPUP);
            SendNotification(MyFacade.PLAY_NEXT_LEVEL);
        }
        

        public override void HandleNotification(INotification notification)
        {
            switch (notification.Name)
            {
                case MyFacade.SHOW_WIN_POPUP:
                    View.Show();
                    break;
                case MyFacade.HIDE_WIN_POPUP:
                    View.Hide();
                    break;
            }
        }

        public override IList<string> ListNotificationInterests()
        {
            IList<string> list = new List<string>
            {
                MyFacade.SHOW_WIN_POPUP,
                MyFacade.HIDE_WIN_POPUP,
            };

            return list;
        }

        public override void OnRegister()
        {
        }

        public override void OnRemove()
        {
        }
    }
}