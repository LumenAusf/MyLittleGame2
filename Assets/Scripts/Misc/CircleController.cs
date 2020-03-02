using System.Collections.Generic;
using System.Linq;
using PureMVCContent.Model;
using PureMVCContent.Model.Enemies;
using UnityEngine;
using Random = UnityEngine.Random;

public class CircleController : MonoBehaviour
{
    public float MoveRadius;
    public float Speed;
    public GameObject Mover;
    public GameObject Finisher;
    public Transform Platform;
    public Transform Pool;

    public int RealWeight;
    public EnemyTypes RingType;
    public bool IsLeftMove;

    public List<Enemy> Enemies = new List<Enemy>();

    public float y => Platform.transform.localScale.y;
    public float SizeZ => Platform.localScale.z;

    public void Init(int weight, float speed, EnemyTypes ringType, bool isLeftMove)
    {
        RealWeight = weight;
        Speed = speed;
        IsLeftMove = isLeftMove;
        RingType = ringType;
    }

    public void EnableMover()
    {
        Mover.SetActive(true);
    }

    public void EnableFinisher()
    {
        Finisher.SetActive(true);
    }

    public void AddEnemy(Enemy enemy)
    {
        Enemies.Add(enemy);
    }

    // public void GenerateEnemies()
    // {
    // RealWeight = Random.Range(minWeight, maxWeight);
    // RingType = (EnemyTypes) Random.Range(0, Enemy.MaxEnumValue);
    // IsLeftMove = Random.Range(0, 100) % 2 != 0;
    //
    // var catalog = App.instance.GetData(EnemiesCatalog.NAME) as EnemiesCatalog;
    // var enemy = catalog.Items.First(x => x.EnemyType == RingType);
    // if (enemy.IsOnlyOne)
    // {
    //     var ee = Instantiate(enemy, Pool);
    //     var locY = y + enemy.transform.localScale.y / 2f;
    //     ee.transform.localPosition = new Vector3(0, locY, 0);
    //     Enemies.Add(ee);
    // }
    // else
    // {
    //     var count = RealWeight / enemy.Weight;
    //     for (var i = 0; i < count; i++)
    //     {
    //         var ee = Instantiate(enemy, Pool);
    //         var locY = y + enemy.transform.localScale.y / 2f;
    //         ee.transform.localPosition = new Vector3(0, locY, 0);
    //         ee.MagicPosValue = Random.Range(0f, 1f);
    //         Enemies.Add(ee);
    //         MoveEnemy(ee);
    //     }
    // }
    // }

    // Update is called once per frame
    void Update()
    {
        foreach (var enemy in Enemies)
        {
            if (!enemy.IsMovable) continue;
            MoveEnemy(enemy);
        }
    }

    private void MoveEnemy(Enemy enemy)
    {
        if (IsLeftMove)
        {
            enemy.MagicPosValue += Time.deltaTime * Speed;
            if (enemy.MagicPosValue > 1) enemy.MagicPosValue = 0;
        }
        else
        {
            enemy.MagicPosValue -= Time.deltaTime * Speed;
            if (enemy.MagicPosValue < 0) enemy.MagicPosValue = 1;
        }

        var x = Mathf.Cos(enemy.MagicPosValue * 2 * Mathf.PI) * MoveRadius;
        var z = Mathf.Sin(enemy.MagicPosValue * 2 * Mathf.PI) * MoveRadius;
        var newPos = new Vector3(x, enemy.transform.localPosition.y, z);

        enemy.transform.rotation = Quaternion.LookRotation(newPos - enemy.transform.position);
        enemy.transform.localPosition = newPos;
    }

    public void Clear()
    {
        foreach (var enemy in Enemies)
        {
            Destroy(enemy.gameObject);
        }

        Enemies.Clear();
    }

    public Enemy InstantiateEnemy(Enemy enemy)
    {
        var o = Instantiate(enemy, Pool);
        return o;
    }
}