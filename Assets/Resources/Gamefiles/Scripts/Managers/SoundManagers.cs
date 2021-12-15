using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SoundManagers : MonoBehaviour
{
    public static SoundManagers instance;
    public AudioClip[] audioClip;
    public Slider masterVolumeSFX;
    public Slider masterVolumeBGM;
    public Dictionary<string, AudioClip> audioClipsDic;
    public AudioSource sfxPlayer;
    public AudioSource bgmPlayer;
    public string startsoundName;

    // Start is called before the first frame update

/*     public static SoundManagers Instance
    {
        get
        {
            if (instance == null)
            {
                instance = (SoundManagers)FindObjectOfType(typeof(SoundManagers));
                if (instance == null)
                {
                    Debug.Log("There's no active ManagerClass object");
                }
            }
            return instance;
        }
    } */
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
    /*     if (instance != null && instance != this)
        {
            DestroyImmediate(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        } */
        AwakeAfter();
    }
 
    void AwakeAfter()
    {
        sfxPlayer = GetComponent<AudioSource>();
        bgmPlayer = transform.GetChild(0).GetComponent<AudioSource>();
 
        audioClipsDic = new Dictionary<string, AudioClip>();
        foreach (AudioClip a in audioClip)
        {
            audioClipsDic.Add(a.name, a);
        }
    }

    // 한 번 재생 : 볼륨 매개변수로 지정
    public void PlaySound(string a_name, float a_volume = 1f)
    {
        if (audioClipsDic.ContainsKey(a_name) == false)
        {
            return;
        }
        sfxPlayer.PlayOneShot(audioClipsDic[a_name], a_volume * masterVolumeSFX.value);
    }
 
    public void BgmPlay(string a_name,float a_volume = 1f)
    {
        StopBGM();
        bgmPlayer.clip = audioClipsDic[a_name];
        bgmPlayer.Play();
        bgmPlayer.volume = a_volume * masterVolumeBGM.value;
    }
    // 랜덤으로 한 번 재생 : 볼륨 매개변수로 지정
    public void PlayRandomSound(string[] a_nameArray, float a_volume = 1f)
    {
        string l_playClipName;
 
        l_playClipName = a_nameArray[Random.Range(0, a_nameArray.Length)];
 
        if (audioClipsDic.ContainsKey(l_playClipName) == false)
        {
            //Debug.Log(l_playClipName + " is not Contained audioClipsDic");
            return;
        }
        sfxPlayer.PlayOneShot(audioClipsDic[l_playClipName], a_volume * masterVolumeSFX.value);
    }
 
    // 삭제할때는 리턴값은 GameObject를 참조해서 삭제한다. 나중에 옵션에서 사운드 크기 조정하면 이건 같이 참조해서 바뀌어야함..
    public GameObject PlayLoopSound(string a_name, float a_volume = 0.3f) 
    {
        if (audioClipsDic.ContainsKey(a_name) == false)
        {
            //Debug.Log(a_name + " is not Contained audioClipsDic");
            return null;
        }
 
        GameObject l_obj = new GameObject("LoopSound");
        AudioSource source = l_obj.AddComponent<AudioSource>();
        l_obj.tag = "Sound_Loop";
        source.clip = audioClipsDic[a_name];
        source.volume = a_volume * masterVolumeBGM.value;
        source.loop = true;
        source.Play();
        return l_obj;
    }
 
    // 주로 전투 종료시 음악을 끈다.
    public void StopBGM()
    {
        bgmPlayer.Stop();
        Destroy(GameObject.Find("LoopSound"));
        startsoundName = "";
    }
 
    public void MapBGM(string MapName)
    {
        switch (MapName)
        {
            case "World":
            BgmPlay(MapName);
            break;
            case "Plasia":
            BgmPlay(MapName);
            PlayLoopSound(MapName+"2");
            break;
            default:
            break;
        }
        startsoundName = MapName;
    }
}
