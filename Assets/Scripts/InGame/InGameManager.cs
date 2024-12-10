using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameManager : Singleton<InGameManager>
{
    public InGameUIController InGameUIController { get; private set; }
    public GameState gameState;
    public float gameTimer;
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
    }

    IEnumerator ExitInGameCo()
    {
        shutter.ShutterDown();
        yield return new WaitForSeconds(1f);
        Utils.LoadScene(sceneNames);
    }
}
