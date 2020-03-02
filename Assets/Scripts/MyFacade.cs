using PureMVC.Patterns;
using PureMVCContent.Control;
using PureMVCContent.Model;
using PureMVCContent.View;
using UnityEngine;
using Utility;

public class MyFacade : Facade
{
    public const string PLAY = "play";
    public const string EXIT = "exit";

    public const string LOAD_GAME_SETTINGS = "load_game_settings";
    public const string LOAD_ENEMIES_DATA = "load_enemies_data";

    public const string SHOW_MAIN_PANEL = "show_main_panel";
    public const string HIDE_MAIN_PANEL = "hide_main_panel";

    public const string SHOW_GAME = "show_game";
    public const string HIDE_GAME = "hide_game";

    public const string OTHER_DATA_UPDATED = "other_data_updated";

    public const string CREATE_LEVEL_FAIL = "create_level_fail";

    public const string FILL_FIRST_CIRCLE = "fill_first_circle";
    public const string FILL_MID_CIRCLE = "fill_mid_circle";
    public const string FILL_LAST_CIRCLE = "fill_last_circle";

    public const string LEVEL_SUCCESS = "level_success";
    public const string LEVEL_FAILED = "level_failed";

    public const string CLEAR_LEVEL = "clear_level";
    
    public const string CLEAR_ALL = "clear_all";
    
    public const string SHOW_WIN_POPUP = "show_win_popup";
    public const string HIDE_WIN_POPUP = "hide_win_popup";
    
    public const string SHOW_LOSE_POPUP = "show_lose_popup";
    public const string HIDE_LOSE_POPUP = "hide_lose_popup";
    
    public const string PLAY_NEXT_LEVEL = "play_next_level";

    // public const string RESET_TRIES = "reset_tries";
    // public const string SHOW_LEADERS = "show_leaders";
    // public const string LEADER_ADDED = "leader_added";
    // public const string LEADERS_CLEARED = "leaders_cleared";
    // public const string INIT_LEVELS = "init_levels";
    // public const string ENEMY_DESTROYED = "enemy_destroyed";
    // public const string LEVEL_DONE = "level_done";
    // public const string GAME_IS_DONE = "game_is_done";
    // public const string PLAY_NEXT_LEVEL = "play_next_level";
    // public const string CLEAR_GAME = "clear_game";

    static MyFacade()
    {
        m_instance = new MyFacade();
    }

    public static MyFacade GetInstance()
    {
        return m_instance as MyFacade;
    }

    public void Launch()
    {
        SendNotification(LOAD_GAME_SETTINGS);
        SendNotification(LOAD_ENEMIES_DATA);
    }

    protected override void InitializeView()
    {
        base.InitializeView();

        GameObject mainPanel = GameObjectUtility.Instance.CreateGameObject("Prefabs/MainPanelView");
        RegisterMediator(new MainPanelMediator(mainPanel));

        GameObject gameView = GameObjectUtility.Instance.CreateGameObject("Prefabs/GameView");
        RegisterMediator(new GameMediator(gameView));
        
        GameObject winPopupView = GameObjectUtility.Instance.CreateGameObject("Prefabs/WinPopupView");
        RegisterMediator(new WinPopupMediator(winPopupView));
        
        GameObject losePopupView = GameObjectUtility.Instance.CreateGameObject("Prefabs/LosePopupView");
        RegisterMediator(new LosePopupMediator(losePopupView));
    }

    protected override void InitializeFacade()
    {
        base.InitializeFacade();
    }

    protected override void InitializeController()
    {
        base.InitializeController();

        RegisterCommand(EXIT, typeof(ExitCommand));

        RegisterCommand(LOAD_GAME_SETTINGS, typeof(LoadGameDataCommand));
        RegisterCommand(LOAD_ENEMIES_DATA, typeof(LoadEnemiesDataCommand));

        RegisterCommand(PLAY, typeof(CreateLevelCommand));

        RegisterCommand(FILL_FIRST_CIRCLE, typeof(FillFirstCircleCommand));
        RegisterCommand(FILL_MID_CIRCLE, typeof(FillMidCircleCommand));
        RegisterCommand(FILL_LAST_CIRCLE, typeof(FillLastCircleCommand));
        
        RegisterCommand(PLAY_NEXT_LEVEL, typeof(PlayNextLevelCommand));
        
        RegisterCommand(LEVEL_FAILED, typeof(LevelFailedCommand));
        RegisterCommand(LEVEL_SUCCESS, typeof(LevelSuccessCommand));
        
        RegisterCommand(CLEAR_LEVEL, typeof(ClearLevelCommand));
        
        RegisterCommand(CLEAR_ALL, typeof(ClearAllCommand));

        // RegisterCommand(SHOW_LEADERS, typeof(ShowLeaderCommand));
        // RegisterCommand(LEADER_ADDED, typeof(LeaderAddedCommand));
        // RegisterCommand(INIT_LEVELS, typeof(CreateLevelsCommand));
        // RegisterCommand(PLAY, typeof(PlayCommand));
        // RegisterCommand(ENEMY_DESTROYED, typeof(DestroyEnemyCommand));
        // RegisterCommand(PLAY_NEXT_LEVEL, typeof(Play2SubCommand));
        // RegisterCommand(RESET_TRIES, typeof(ResetTriesCommand));
        // RegisterCommand(CLEAR_GAME, typeof(ClearGameCommand));
    }


    protected override void InitializeModel()
    {
        base.InitializeModel();

        RegisterProxy(new GameConfigurationProxy(GameConfigurationProxy.NAME));
        RegisterProxy(new EnemyProxy(EnemyProxy.NAME));
        RegisterProxy(new OtherProxy(OtherProxy.NAME));
        // RegisterProxy(new LevelProxy(LevelProxy.NAME));
        // RegisterProxy(new LeadersProxy(LeadersProxy.NAME));
        // RegisterProxy(new OtherDataProxy(OtherDataProxy.NAME));
        // RegisterProxy(new PlayerDataProxy(PlayerDataProxy.NAME));
    }
}