using System.Collections.Generic;
using PureMVCContent.Model.Enemies;
using UnityEngine;

namespace PureMVCContent.Model
{
    [CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/EnemyCatalog", order = 1)]
    public class EnemiesCatalog : ScriptableObject
    {
        public List<Enemy> Items = new List<Enemy>();
    }
}