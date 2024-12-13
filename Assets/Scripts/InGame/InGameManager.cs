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

    public List<Ingredient> recipe = new List<Ingredient>(4);
    public List<Ingredient> tray = new List<Ingredient>(4);
    public Queue<List<Ingredient>> orderQueue = new Queue<List<Ingredient>>(3);
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
        orderNum = 0;
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

    public void AddOrder()
    {
        orderNum++;
        recipe.Add(Ingredient.Bun);
        for (int i = 0; i < Random.Range(1,5); i++)
        {
            recipe.Add((Ingredient)Random.Range(1, 5));
        }
        recipe.Add(Ingredient.Bun);
        Order.ShowOrder();
        orderQueue.Enqueue(recipe);
    }

    public void OnClickBun()
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
        AddOrder();
    }

    IEnumerator ExitInGameCo()
    {
        shutter.ShutterDown();
        yield return new WaitForSeconds(1f);
        Utils.LoadScene(sceneNames);
    }
}
