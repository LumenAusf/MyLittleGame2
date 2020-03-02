using System.Collections.Generic;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using UnityEngine;

namespace PureMVCContent.View
{
    public class LosePopupMediator : Mediator
    {
        public new const string NAME = "LosePopupMediator";

        private LosePopupView View;

        public LosePopupMediator(object viewComponent) : base(NAME, viewComponent)
        {
            View = ((GameObject) ViewComponent).GetComponent<LosePopupView>();
            Debug.Log("Lose popup Mediator");
            View.ButtonBackToMain.onClick.AddListener(BackToMain);
        }

        private void BackToMain()
        {
            SendNotification(MyFacade.HIDE_LOSE_POPUP);
            SendNotification(MyFacade.CLEAR_ALL);
            SendNotification(MyFacade.HIDE_GAME);
            SendNotification(MyFacade.SHOW_MAIN_PANEL);
        }
        

        public override void HandleNotification(INotification notification)
        {
            switch (notification.Name)
            {
                case MyFacade.SHOW_LOSE_POPUP:
                    View.Show();
                    break;
                case MyFacade.HIDE_LOSE_POPUP:
                    View.Hide();
                    break;
            }
        }

        public override IList<string> ListNotificationInterests()
        {
            IList<string> list = new List<string>
            {
                MyFacade.SHOW_LOSE_POPUP,
                MyFacade.HIDE_LOSE_POPUP,
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