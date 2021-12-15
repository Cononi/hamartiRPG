using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionMenu : MonoBehaviour
{
    public Dropdown lang;
    // Start is called before the first frame update
    public void Options()
    {
        switch (lang.value)
        {
            case 0:
                GameManager.instance.islang = "ko";
                GameManager.instance.itemlang = "itemko";
                break;
            case 1:
                GameManager.instance.islang = "en";
                GameManager.instance.itemlang = "itemen";
                break;
            default:
                GameManager.instance.islang = "";
                break;
        }
        LocalizationManager.instance.LoadLocalizedText(GameManager.instance.islang);
        ItemDatabase.instance.LoadLocalizedItem(GameManager.instance.itemlang);
        SoundManagers.instance.bgmPlayer.volume = SoundManagers.instance.masterVolumeBGM.value;
        SoundManagers.instance.sfxPlayer.volume = SoundManagers.instance.masterVolumeSFX.value;

    }
}
