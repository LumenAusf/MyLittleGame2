using UnityEngine;
using UnityEngine.UI;

namespace PureMVCContent.View
{
    public class WinPopupView : MonoBehaviour
    {
        public Button ButtonNextLevel;

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