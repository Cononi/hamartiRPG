using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public static ButtonManager instance;
    public bool bus;
    bool isPause = true;
    public GameObject player_Btt;
    //public GameObject player_heart_Btt;
    // 메뉴 집합체.
    public GameObject menu_InterFace;
    // 게임 종료 메세지
    public GameObject game_Exit;
    // 각종 메뉴.
    public GameObject BackGround;
    public GameObject[] menu_Info;
    OptionMenu option_menuScript;
    public GameObject dropgetObj;

    //////

    public Sprite[] mbt_baseSprite;
    public Sprite[] mbt_clickSprite;
    public Button[] bttS;
    public bool dropgets;
    public Text itemNameText;
    ////

    public Image trancimage;
    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        option_menuScript = GetComponent<OptionMenu>();
        game_Exit.gameObject.SetActive(false);
        menu_InterFace.gameObject.SetActive(false);
        Menu_Exit();
        menu_Info[0].gameObject.SetActive(false);
        bttS[7].gameObject.SetActive(false);
    }
    private void Menu_Exit()
    {
        for (int i = 0; i < 6; i++)
            bttS[i].image.sprite = mbt_baseSprite[i];
        foreach (GameObject info in menu_Info)
        {
            info.SetActive(false);
            //메뉴창에 모든 메뉴를 다 끊다.
        }
        Inventory.instance.invenSlotInfo.SetActive(false);
    }
    public void OnPointerDown()
    {
        bus = true;
    }
/*     public void OnPointerUp()
    {
        bus = false;
    } */
    public void itemdropget()
    {
        if (dropgets == true)
            StartCoroutine(itemdropgets());
    }
    public IEnumerator itemdropgets()
    {
        dropgetObj.transform.position = new Vector3(Inventory.instance.player.transform.position.x, Inventory.instance.player.transform.position.y);
        yield return new WaitForSeconds(0.1f);
        dropgetObj.transform.position = new Vector3(5000, 5000);
    }
    // 메뉴 버튼
    public void MenuBtts()
    {
        if (GameManager.instance.eGameState != GameManager.EGAMESTATE.exit)
        {
            if (isPause)
            {
                menu_InterFace.gameObject.SetActive(true);
                BackGround.gameObject.SetActive(true);
                Time.timeScale = 0;
                isPause = false;
                player_Btt.SetActive(false);
                //player_heart_Btt.SetActive(false);
                PlayerInfoEquip();
                Inventory.instance.ItemSlotsCheck(0, false);
            }
            else
            {
                game_Exit.SetActive(false);
                BackGround.gameObject.SetActive(false);
                menu_InterFace.gameObject.SetActive(false);
                Time.timeScale = 1;
                isPause = true;
                //player_heart_Btt.SetActive(true);
                player_Btt.SetActive(true);
                Menu_Exit();
            }
        }
        else
        {
            game_Exit.SetActive(true);
            BackGround.gameObject.SetActive(true);
            menu_InterFace.gameObject.SetActive(false);
            Time.timeScale = 0;
            isPause = false;
            //player_heart_Btt.SetActive(false);
            player_Btt.SetActive(false);
            Menu_Exit();
            GameManager.instance.eGameState = GameManager.EGAMESTATE.play;
        }
    }
    // 옵션 메뉴
    public void Options()
    {
        Menu_Exit();
        menu_Info[0].SetActive(true);
    }
    public void Worlds()
    {
        Menu_Exit();
        menu_Info[1].SetActive(true);
    }
    public void Inventorys()
    {
        Menu_Exit();
        menu_Info[2].SetActive(true);
    }
    public void PlayerInfoEquip()
    {
        Menu_Exit();
        menu_Info[3].SetActive(true);
    }
    public void QuestInfo()
    {
        Menu_Exit();
        menu_Info[4].SetActive(true);
    }
    public void GameExit_Btt()
    {
        Application.Quit();
    }
    void OnApplicationPause(bool pause)
    {
        if (pause)
        {
            pause = true;
            DataManager.instance._save();
        }
        else
        {
            pause = false;
        }
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            GameManager.instance.eGameState = GameManager.EGAMESTATE.exit;
            MenuBtts();
        }
    }
}
