using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    // 게임 상태를 나타낸다.
    public enum EGAMESTATE
    {
        main,
        play,
        die,
        end,
        exit
    }
    public EGAMESTATE eGameState;
    public string islang = "ko";
    public string itemlang = "itemko";
    public bool OneSign;
    public bool itemLoadMesage;
    public int pageNum;
    public Image trancimage;
    public bool Light;
    public GameObject GmworldOutSet;
    void Awake()
    {
        // instance가  null 값과 같다면
        if (instance == null)
        {
            // 객체를 실체화하여 인스턴스화 한다.
            instance = this;
        }
        // instance가 자신과 다르다면 지운다.
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        // Scene이 넘어가도 파괴되지 않게 고정시킴.
        DontDestroyOnLoad(gameObject);
        // 스크린 설정.
        //Screen.SetResolution(1920, 1080, true);
    }
    public void newgame()
    {
        SceneManager.LoadScene("Scenes1");
        eGameState = EGAMESTATE.play;
        StartCoroutine(newgames());
    }
    public void exitGame()
    {
        Application.Quit();
    }
    private IEnumerator newgames()
    {
        yield return null;
        string Paths = Path.Combine(Application.persistentDataPath, "Unityjhong.json");
        if (File.Exists(Paths))
        {
            DataManager.instance._load();
        }
        else
        {
            DataManager.instance._save();
            DataManager.instance._load();
            SoundManagers.instance.MapBGM("World");
        }
    }
}
