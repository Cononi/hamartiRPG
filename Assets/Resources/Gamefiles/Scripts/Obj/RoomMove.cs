using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomMove : MonoBehaviour
{
    public Vector2 mincameraChange; // 카메라를 시점변경 위치.
    public Vector2 maxcameraChange; // 카메라를 시점변경 위치.
    public Vector3 playerChange; // 이동시킬 플레이어의 위치.
    Transform players;      // 현재 플레이어위치.
    public CameraMovement camS; // 카메라의 오브젝트.
    public GameObject mapInSet; // 맵오브젝트 오픈
    public GameObject worldOutSet; //다른맵 제거.
    public bool WorldMap; // 월드맵으로갈때 고정.
    public bool roomGo; // 방으로 이동할때.
    public bool MapChange;
    //맵이름 표시 부분
    public bool needText; // 띄워야 하는가
    public string type; // 타입
    public string key; // 맵이름
    public int i;
    public string obJsoundName; // 켜지게될 사운드.
    public string maPsoundNames; // 켜지게될 맵이름
    public GameObject objText; // 텍스트로 쓰이는 오브젝트 연결
    public Text placeText; // 현재 장소 이름이 적힌 텍스트
    public bool aniCtr; // 트레지션에 영향을 줄 것인가?
    public Image image;

    Color color;
    Vector3 placeNamePo;

    void Start()
    {
        players = GameObject.Find("Player").GetComponent<Transform>();
        placeNamePo = placeText.transform.position;
        if (playerChange != Vector3.zero)
            playerChange = new Vector3(playerChange.x, playerChange.y, 1);
    }
    // RigidBody를 밟는순간 온된다.
    private void OnTriggerEnter2D(Collider2D other)
    {
        // 태그가 Player라면 실행
        if (other.gameObject.tag == "Player")
        {
            StopAllCoroutines();
            if (mapInSet != null && MapChange)
            {
                mapInSet.SetActive(true);
                DataManager.instance.ThisMap(mapInSet.name);
                GameManager.instance.GmworldOutSet = worldOutSet;
            }
            else
            {
            }
            if (roomGo)
                SoundManagers.instance.PlaySound("door");
            placeText.transform.position = placeNamePo;
            StartCoroutine(RoomMovesNow());
            // needText가 true라면 placeNameco()라는 코루틴을 실행.
        }
    }

    private IEnumerator RoomMovesNow()
    {
        if (aniCtr)
        {
            StartCoroutine(FadeOut());
            yield return new WaitForSeconds(0.1f);
        }
        // 카메라 위치를 변경값 만큼 변환 시킨다.
        if (mincameraChange != Vector2.zero && maxcameraChange != Vector2.zero)
        {
            camS.minPosition = mincameraChange;
            camS.maxPosition = maxcameraChange;
        }
        else
        {
            if (WorldMap)
            {
                camS.minPosition = new Vector2(-122.5f, -35f);
                camS.maxPosition = new Vector2(125.5f, 198f);
                SoundManagers.instance.MapBGM("World");
                maPsoundNames = "World";
            }
        }

        // collider가 붙어있는 이 오브젝트의 포지션값에 playerChange 의 값만큼 변경해서 위치를 변경한다.
        if (playerChange != Vector3.zero)
        {
            players.position = playerChange;
            if (maPsoundNames != "" && WorldMap == false && roomGo)
            {
                SoundManagers.instance.MapBGM(maPsoundNames);
            }
            if (roomGo && maPsoundNames == "")
            {
                SoundManagers.instance.StopBGM();
            }
            if (needText)
                StartCoroutine(PlaceNameCo());
        }
        else if (needText)
        {
            StartCoroutine(PlaceNameCo());
        }
    }
    public IEnumerator FadeOut()
    {
        ButtonManager.instance.trancimage.gameObject.SetActive(true);
        while (color.a <= 1f)
        {
            color.a += 0.2f;
            ButtonManager.instance.trancimage.color = color;
            yield return new WaitForSeconds(0.01f);
        }
        StartCoroutine(FadeIn());
    }
    public IEnumerator FadeIn()
    {
        while (color.a >= 0f)
        {
            color.a -= 0.2f;
            ButtonManager.instance.trancimage.color = color;
            yield return new WaitForSeconds(0.01f);
        }
        ButtonManager.instance.trancimage.gameObject.gameObject.SetActive(false);
    }
    private IEnumerator PlaceNameCo()
    {
        // 오브젝트를 온시킴.
        objText.SetActive(true);
        // 오브젝트의 이름을 띄우기위해 플레이스 이름입력
        placeText.text = LocalizationManager.instance.GetLocalizedValue(type, key, i);
        for (float i = 0; i <= 1; i += 0.02f)
        {
            placeText.transform.position += new Vector3(i * 1.5f, i * 1.5f, 0);
            placeText.color = new Vector4(placeText.color.r, placeText.color.g, placeText.color.b, i);
            yield return new WaitForSeconds(0.01f);
        }
        // 4초간 대기
        yield return new WaitForSeconds(4f);
        for (float i = 1; i >= 0; i -= 0.05f)
        {
            placeText.transform.position -= new Vector3(i * 1.5f, i * 1.5f, 0);
            placeText.color = new Vector4(placeText.color.r, placeText.color.g, placeText.color.b, i);
            yield return new WaitForSeconds(0.01f);
        }
        if (mapInSet != null && MapChange)
        {
            GameManager.instance.GmworldOutSet.SetActive(false);
        }
        else
        {
        }
        objText.SetActive(false);
    }
}
