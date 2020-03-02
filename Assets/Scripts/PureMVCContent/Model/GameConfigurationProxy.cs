using PureMVC.Patterns;
using UnityEngine;

namespace PureMVCContent.Model
{
    public class GameConfigurationProxy : Proxy
    {
        public new static string NAME = "GameConfiguration";

        private GameConfiguration Data;
        
        public GameConfigurationProxy(string proxyName)
            : base(proxyName)
        {
            Debug.Log("GameConfiguration create");
        }

        public void AddData(GameConfiguration data)
        {
            Data = data;
        }

        public int GetCirclesCount()
        {
            return Data.CirclesCount;
        }

        public Vector2Int GetLevelWeight(int level)
        {
            return Data.GetLevelWeights(level);
        }

        public float GetSpeedMovables()
        {
            return Data.EnemyMoveSpeed;
        }

        public override void OnRegister()
        {
            base.OnRegister();
            Debug.Log("GameConfiguration OnRegister");
        }

        public override void OnRemove()
        {
            base.OnRemove();
            Debug.Log("GameConfiguration OnRemove");
        }

        public float GetSpeedPlayer()
        {
            return Data.PlayerSpeed;
        }
    }
}