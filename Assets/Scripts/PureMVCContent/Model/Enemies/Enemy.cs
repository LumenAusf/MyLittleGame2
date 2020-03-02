using UnityEngine;

namespace PureMVCContent.Model.Enemies
{
    public abstract class Enemy : MonoBehaviour
    {
        public const int MaxEnumValue = 1;
        public abstract bool IsMovable { get; }
        public abstract bool IsOnlyOne { get; }
        public float MagicPosValue;
        public int Weight;
        public abstract EnemyTypes EnemyType{ get; }
    }

    public enum EnemyTypes
    {
        Block,
        Fan,
    }
}