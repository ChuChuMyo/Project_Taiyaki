using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class InGameManager : Singleton<InGameManager>
{
    public InGameUIController InGameUIController { get; private set; }
    public Order Order { get; private set; }
    public GameState gameState;
    public Ingredient ingredient;
    public float gameTimer;
    public int orderNum;

    [SerializeField]
    private Shutter shutter;
    [SerializeField]
    private SceneNames sceneNames;


    protected override void Init()
    {
        m_IsDestroyOnLoad = true;
        base.Init();
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GameStartCo());
        InGameUIController = FindFirstObjectByType<InGameUIController>();
        Order = FindFirstObjectByType<Order>();
        InGameUIController.UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameState == GameState.Playing)
        {
            GamePlaying();
        }
        if(gameTimer <= 0)
        {
            GameEnd();
        }
    }


    public void LoadOrder()
    {

    }

    public void GamePlaying()
    {
        gameTimer -= Time.deltaTime;
    }

    public void GamePause()
    {
        gameState = GameState.Pause;
    }

    public void GameResume()
    {
        gameState = GameState.Playing;
    }

    public void GameEnd()
    {
        gameState = GameState.End;
        StartCoroutine(ExitInGameCo());
    }

    IEnumerator GameStartCo()
    {
        shutter.ShutterUP();
        gameTimer = 60f;
        yield return new WaitForSeconds(4f);
        GameResume();
        //AddOrder();
    }

    IEnumerator ExitInGameCo()
    {
        shutter.ShutterDown();
        yield return new WaitForSeconds(1f);
        Utils.LoadScene(sceneNames);
    }
}
