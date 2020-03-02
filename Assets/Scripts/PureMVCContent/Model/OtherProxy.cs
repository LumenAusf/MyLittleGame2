using PureMVC.Patterns;
using UnityEngine;

namespace PureMVCContent.Model
{
    public class OtherProxy : Proxy
    {
        public new static string NAME = "Other";

        private OtherModel Data;

        public OtherProxy(string proxyName)
            : base(proxyName)
        {
            Debug.Log("Other proxy create");
            AddData(new OtherModel());
        }

        public void AddData(OtherModel data)
        {
            Data = data;
        }

        public int GetLevel()
        {
            return Data.CurrentLevel;
        }

        public void SetLevel(int newLevel)
        {
            Data.CurrentLevel = newLevel;
            SendNotification(MyFacade.OTHER_DATA_UPDATED, Data);
        }

        public override void OnRegister()
        {
            base.OnRegister();
            Debug.Log("Other proxy OnRegister");
        }

        public override void OnRemove()
        {
            base.OnRemove();
            Debug.Log("Other proxy OnRemove");
        }

        public OtherModel GetData()
        {
            return Data;
        }
    }
}