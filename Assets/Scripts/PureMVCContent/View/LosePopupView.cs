using UnityEngine;
using UnityEngine.UI;

namespace PureMVCContent.View
{
    public class LosePopupView : MonoBehaviour
    {
        public Button ButtonBackToMain;

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