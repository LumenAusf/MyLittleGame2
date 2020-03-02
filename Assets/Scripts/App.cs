using UnityEngine;


public class App : MonoBehaviour
{
    public int FPS = 60;

    // [SerializeField] private EnemiesCatalog enemyCatalog;
    // [SerializeField] private GameConfiguration gameConfiguration;
    // [SerializeField] private Dictionary<string, object> dictionary = new Dictionary<string, object>();
    //
    // public List<GameObject> PrefabsToInit = new List<GameObject>();
    //
    // public Action PlayGame = delegate { };
    // public Action SuccesLevel = delegate { };
    // public Action FailedLevel = delegate { };
    //
    // public static App instance { get; private set; }

    private void Awake()
    {
        Application.targetFrameRate = FPS;
        MyFacade.GetInstance().Launch();
    }

    // private void AdditionalInit()
    // {
    //     AddData(EnemiesCatalog.NAME, enemyCatalog);
    //     AddData(GameConfiguration.NAME, gameConfiguration);
    //     foreach (var prefab in PrefabsToInit)
    //     {
    //         if (prefab != null)
    //             Instantiate(prefab);
    //     }
    // }
    //
    // public object GetData(string key)
    // {
    //     return !dictionary.ContainsKey(key) ? null : dictionary[key];
    // }
    //
    // public void AddData(string key, object value)
    // {
    //     if (dictionary.ContainsKey(key)) throw new ArgumentException($"key '{key}' already exist");
    //     dictionary.Add(key, value);
    //     Debug.Log($"Added key '{key}' and value '{value}'");
    // }
}