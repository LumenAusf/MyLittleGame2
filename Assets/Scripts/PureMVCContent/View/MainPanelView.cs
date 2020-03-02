using UnityEngine;
using UnityEngine.UI;

namespace PureMVCContent.View
{
    public class MainPanelView : MonoBehaviour
    {
        public Button ButtonPlay;
        public Button ButtonExit;


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