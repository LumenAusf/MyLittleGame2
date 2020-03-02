using System.Collections.Generic;
using PureMVC.Patterns;
using PureMVCContent.Model.Enemies;
using UnityEngine;

namespace PureMVCContent.Model
{
    public class EnemyProxy : Proxy
    {
        public new static string NAME = "Enemy";
        
        public List<Enemy> Items = new List<Enemy>();
        
        public EnemyProxy(string proxyName)
            : base(proxyName)
        {
            Debug.Log("EnemyProxy create");
        }

        public void AddEnemy(Enemy enemy)
        {
            Items.Add(enemy);
        }

        public void Clear()
        {
            Items.Clear();
        }

        public List<Enemy> GetEnemies()
        {
            return new List<Enemy>(Items);
        }
        
        public override void OnRegister()
        {
            base.OnRegister();
            Debug.Log("EnemyProxy OnRegister");
        }
        
        public override void OnRemove()
        {
            base.OnRemove();
            Debug.Log("EnemyProxy OnRemove");
        }
    }
}