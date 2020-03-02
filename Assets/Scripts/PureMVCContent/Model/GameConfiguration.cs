using System;
using System.Collections.Generic;
using UnityEngine;

namespace PureMVCContent.Model
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/GameConfiguration", order = 2)]
    public class GameConfiguration : ScriptableObject
    {
        public int MinWeight;
        public int MaxWeight;
        public int Range;
        public int CirclesCount;
        public float PlayerSpeed;
        public float EnemyMoveSpeed;
        public float EnemyRotateSpeed;
        public List<LevelBehaviour> Behaviours = new List<LevelBehaviour>();

        public Vector2Int GetLevelWeights(int level)
        {
            var currlvl = 0;
            var weight = MinWeight;
            foreach (var levelBehaviour in Behaviours)
            {
                if (levelBehaviour.LevelsCount + currlvl < level)
                {
                    currlvl += levelBehaviour.LevelsCount;
                    weight += levelBehaviour.Weight;
                    weight = Mathf.Clamp(weight, MinWeight, MaxWeight);
                }
                else
                {
                    var a = levelBehaviour.Weight / (float) levelBehaviour.LevelsCount;
                    var b = level - currlvl;
                    var c = a * b;
                    weight += (int)c;
                    break;
                }
            }
            return new Vector2Int(weight, Mathf.Clamp(weight + Range, MinWeight, MaxWeight));
        }
    }

    [Serializable]
    public struct LevelBehaviour
    {
        public int LevelsCount;
        public int Weight;
    }
}