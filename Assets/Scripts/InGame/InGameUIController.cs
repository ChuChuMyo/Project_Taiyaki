using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameUIController : MonoBehaviour
{
    [SerializeField]
    private SceneNames nextScene;
    [SerializeField]
    private Shutter shutter;
    // Start is called before the first frame update
    void Start()
    {
        shutter.ShutterUP();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickExit()
    {
        StartCoroutine(ExitInGame());
    }

    IEnumerator ExitInGame()
    {
        shutter.ShutterDown();
        yield return new WaitForSeconds(1f);
        Utils.LoadScene(nextScene);
    }
}
