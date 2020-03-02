using PureMVC.Interfaces;
using PureMVC.Patterns;
using UnityEngine;

namespace PureMVCContent.Control
{
    public class ExitCommand : SimpleCommand
    {
        public override void Execute(INotification notification)
        {
            Debug.Log("Exit");
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}