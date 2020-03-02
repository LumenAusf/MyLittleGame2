using System.Collections.Generic;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using UnityEngine;

namespace PureMVCContent.View
{
    public class MainPanelMediator : Mediator
    {
        public new const string NAME = "MainPanelMediator";

        private MainPanelView View;

        public MainPanelMediator(object viewComponent) : base(NAME, viewComponent)
        {
            View = ((GameObject) ViewComponent).GetComponent<MainPanelView>();
            View.gameObject.SetActive(true);
            Debug.Log("Main Panel Mediator");

            View.ButtonPlay.onClick.AddListener(OnClickPlay);
            View.ButtonExit.onClick.AddListener(OnClickExit);
        }

        private void OnClickExit()
        {
            SendNotification(MyFacade.EXIT);
        }

        public void OnClickPlay()
        {
            Debug.Log("Main Panel start game");
            SendNotification(MyFacade.PLAY,1);
            SendNotification(MyFacade.HIDE_MAIN_PANEL);
        }

        public override void HandleNotification(INotification notification)
        {
            switch (notification.Name)
            {
                case MyFacade.SHOW_MAIN_PANEL:
                    View.Show();
                    break;
                case MyFacade.HIDE_MAIN_PANEL:
                    View.Hide();
                    break;
            }
        }

        public override IList<string> ListNotificationInterests()
        {
            IList<string> list = new List<string>
            {
                MyFacade.SHOW_MAIN_PANEL,
                MyFacade.HIDE_MAIN_PANEL,
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