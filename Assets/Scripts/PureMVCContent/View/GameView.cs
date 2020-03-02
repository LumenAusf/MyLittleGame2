using OtherNow;
using UnityEngine;
using UnityEngine.UI;

namespace PureMVCContent.View
{
    public class GameView : MonoBehaviour
    {
        public CircleController CircleTemplate;
        public PlayerCubeController Player;
        public Transform CircleStorage;
        public Text LevelText;
        
        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}