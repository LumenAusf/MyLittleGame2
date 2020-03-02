using System;
using System.Collections.Generic;
using OtherNow;
using PureMVC.Interfaces;
using PureMVC.Patterns;
using PureMVCContent.Model;
using UnityEngine;
using Object = UnityEngine.Object;

namespace PureMVCContent.View
{
    public class GameMediator : Mediator
    {
        public new const string NAME = "GameMediator";

        private GameView View;

        private List<CircleController> circles = new List<CircleController>();

        private int currentCircle;

        public GameMediator(object viewComponent) : base(NAME, viewComponent)
        {
            View = ((GameObject) ViewComponent).GetComponent<GameView>();
            View.Player.MoveNext += PlayerMoveNextCircle;
            View.Player.Failure += () => SendNotification(MyFacade.LEVEL_FAILED);
            View.Player.Finish += () => SendNotification(MyFacade.LEVEL_SUCCESS);
            Debug.Log("Game Mediator");
        }

        private void PlayerMoveNextCircle()
        {
            Debug.Log("NextCircle");
            currentCircle++;
            View.Player.SetCircle(circles[currentCircle]);
        }

        public CircleController GetInstanceCircle()
        {
            var o = Object.Instantiate(View.CircleTemplate, View.CircleStorage);
            return o;
        }

        public void AddCircle(CircleController circle)
        {
            circles.Add(circle);
        }

        public void ClearCircles()
        {
            currentCircle = 0;
            View.Player.Clear();
            foreach (var circle in circles)
            {
                circle.Clear();
                Object.Destroy(circle.gameObject);
            }

            circles.Clear();
        }


        public override void HandleNotification(INotification notification)
        {
            switch (notification.Name)
            {
                case MyFacade.SHOW_GAME:
                    View.Show();
                    break;
                case MyFacade.HIDE_GAME:
                    View.Hide();
                    break;
                case MyFacade.OTHER_DATA_UPDATED:
                    View.LevelText.text = $"Level {(notification.Body as OtherModel).CurrentLevel}";
                    break;
            }
        }

        public override IList<string> ListNotificationInterests()
        {
            IList<string> list = new List<string>
            {
                MyFacade.SHOW_GAME,
                MyFacade.HIDE_GAME,
                MyFacade.OTHER_DATA_UPDATED
            };

            return list;
        }

        public override void OnRegister()
        {
        }

        public override void OnRemove()
        {
        }

        public void PlayerToFirstCircle(float speedPlayer)
        {
            View.Player.SetSpeed(speedPlayer);
            View.Player.SetCircle(circles[0]);
            View.Player.SetMove(true);
        }
    }
}