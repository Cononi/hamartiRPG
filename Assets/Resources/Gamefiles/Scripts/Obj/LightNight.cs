using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class LightNight : MonoBehaviour
{
    public Light lights;
    public Light itemLight;
    public NpcReset npcReset;
    public int subtime, min = 0, time = 3, timeSub;
    public float R = 1, G = 1, B = 1;
    public Text worldTime;
    private void Start()
    {
        lights = GetComponent<Light>();
        StartCoroutine(LightCount());
    }
    void times(int i)
    {
        if (i >= 83)
        {
            subtime = 0;
            if (min < 9)
            {
                worldTime.text = time + ":0" + ++min;
            }
            else if (min >= 59)
            {
                time++;
                min = 0;
                worldTime.text = time + ":00";
            }
            else
            {
                worldTime.text = time + ":" + ++min;
            }
        }
    }
    void timeLight(bool on)
    {
        if (npcReset != null)
            if (on == true && time >= 19 || time == 0)
            {
                for (int i = 0; i < npcReset.placeMaplights.Count; i++)
                {
                    npcReset.placeMaplights[i].gameObject.SetActive(true);
                    npcReset.placeMaplights[i].range = 15;
                    npcReset.placeMaplights[i].intensity = 4;
                }
            }
            else
            {
                for (int i = 0; i < npcReset.placeMaplights.Count; i++)
                {
                    npcReset.placeMaplights[i].gameObject.SetActive(false);
                    npcReset.placeMaplights[i].range = 10;
                    npcReset.placeMaplights[i].intensity = 3;
                }
            }
    }
    IEnumerator LightCount()
    {
        times(subtime);
        yield return new WaitForSeconds(0.1f);
        timeLight(true);
        switch (time)
        {
            case 4:
                for (int i = 0; i < 5000; i++)
                {
                    itemLight.intensity -= 0.0002f;
                    itemLight.range -= 0.001f;
                    lights.intensity += 0.0001f;
                    subtime++;
                    times(subtime);
                    yield return new WaitForSeconds(0.01f);
                    if (time == 5)
                    {
                        itemLight.intensity = 4;
                        itemLight.range = 20;
                        lights.intensity = 0.5f;
                        break;
                    }
                }
                break;
            case 5:
                for (int i = 0; i < 5000; i++)
                {
                    itemLight.intensity -= 0.0002f;
                    itemLight.range -= 0.001f;
                    lights.intensity += 0.0002f;
                    lights.color = new Vector4(1, G -= 0.00003f, B -= 0.00005f, 1);
                    subtime++;
                    times(subtime);
                    yield return new WaitForSeconds(0.01f);
                    if (time == 6)
                    {
                        lights.intensity = 1.5f;
                        R = 1;
                        G = 0.85f;
                        B = 0.75f;
                        itemLight.intensity = 3;
                        itemLight.range = 15;
                        break;
                    }
                }
                break;
            case 6:
                for (int i = 0; i < 5000; i++)
                {
                    itemLight.intensity -= 0.0002f;
                    itemLight.range -= 0.0006f;
                    lights.intensity += 0.0003f;
                    lights.color = new Vector4(1, G, B -= 0.00005f, 1);
                    subtime++;
                    times(subtime);
                    yield return new WaitForSeconds(0.01f);
                    if (time == 7)
                    {
                        lights.intensity = 3f;
                        R = 1;
                        G = 0.85f;
                        B = 0.5f;
                        itemLight.intensity = 2;
                        itemLight.range = 12;
                        break;
                    }
                }
                break;
            case 7:
                for (int i = 0; i < 5000; i++)
                {
                    itemLight.intensity -= 0.0002f;
                    itemLight.range -= 0.0004f;
                    lights.intensity += 0.0001f;
                    lights.color = new Vector4(1, G += 0.00003f, B += 0.0001f, 1);
                    subtime++;
                    times(subtime);
                    yield return new WaitForSeconds(0.01f);
                    if (time == 8)
                    {
                        itemLight.intensity = 1;
                        itemLight.range = 10;
                        lights.color = new Vector4(1, 1, 1, 1);
                        R = 1;
                        G = 1;
                        B = 1;
                        lights.intensity = 3.5f;
                        break;
                    }
                }
                break;
            case 16:
                for (int i = 0; i < 5000; i++)
                {
                    itemLight.intensity += 0.0001f;
                    lights.color = new Vector4(1, G -= 0.00002f, B -= 0.00005f, 1);
                    subtime++;
                    times(subtime);
                    yield return new WaitForSeconds(0.01f);
                    if (time == 17)
                    {
                        print("밝기 : " + itemLight.intensity + "\n범위 : " + itemLight.range + "\nR : " + R + "\nG : " + G + "\nB : " + B);
                        itemLight.intensity = 1.5f;
                        R = 1;
                        G = 0.9f;
                        B = 0.75f;
                        break;
                    }
                }
                break;
            case 17:
                for (int i = 0; i < 5000; i++)
                {
                    itemLight.range += 0.0006f;
                    itemLight.intensity += 0.0001f;
                    lights.color = new Vector4(1, G -= 0.00004f, B -= 0.0001f, 1);
                    subtime++;
                    times(subtime);
                    yield return new WaitForSeconds(0.01f);
                    if (time == 18)
                    {
                        print("밝기 : " + itemLight.intensity + "\n범위 : " + itemLight.range + "\nR : " + R + "\nG : " + G + "\nB : " + B);
                        itemLight.intensity = 2;
                        itemLight.range = 13;
                        R = 1;
                        G = 0.7f;
                        B = 0.25f;
                        break;
                    }
                }
                break;
            case 18:
                for (int i = 0; i < 5000; i++)
                {
                    itemLight.range += 0.0004f;
                    itemLight.intensity += 0.0002f;
                    lights.intensity -= 0.0002f;
                    subtime++;
                    times(subtime);
                    yield return new WaitForSeconds(0.01f);
                    if (time == 19)
                    {
                        print("밝기 : " + itemLight.intensity + "\n범위 : " + itemLight.range + "\nR : " + R + "\nG : " + G + "\nB : " + B);
                        itemLight.intensity = 3;
                        itemLight.range = 15;
                        break;
                    }
                }

                break;
            case 19:
                for (int i = 0; i < 5000; i++)
                {
                    itemLight.intensity += 0.0001f;
                    lights.intensity -= 0.0002f;
                    lights.color = new Vector4(R -= 0.000175f, G -= 0.000033f, B += 0.00015f, 1);
                    subtime++;
                    times(subtime);
                    yield return new WaitForSeconds(0.01f);
                    if (time == 20)
                    {
                        print("밝기 : " + itemLight.intensity + "\n범위 : " + itemLight.range + "\nR : " + R + "\nG : " + G + "\nB : " + B);
                        itemLight.intensity = 3.5f;
                        lights.intensity = 1.5f;
                        R = 0.125f;
                        G = 0.535f;
                        B = 1f;
                        break;
                    }
                }
                break;
            case 20:
                for (int i = 0; i < 5000; i++)
                {
                    itemLight.range += 0.001f;
                    itemLight.intensity += 0.0001f;
                    lights.intensity -= 0.0002f;
                    subtime++;
                    times(subtime);
                    yield return new WaitForSeconds(0.01f);
                    if (time == 21)
                    {
                        print("밝기 : " + itemLight.intensity + "\n범위 : " + itemLight.range + "\nR : " + R + "\nG : " + G + "\nB : " + B);
                        itemLight.intensity = 4;
                        itemLight.range = 20;
                        lights.intensity = 0.5f;
                        break;
                    }
                }
                break;
            case 22:
                for (int i = 0; i < 5000; i++)
                {
                    itemLight.range += 0.001f;
                    itemLight.intensity += 0.0002f;
                    lights.intensity -= 0.0001f;
                    subtime++;
                    times(subtime);
                    yield return new WaitForSeconds(0.01f);
                    if (time == 23)
                    {
                        print("밝기 : " + itemLight.intensity + "\n범위 : " + itemLight.range + "\nR : " + R + "\nG : " + G + "\nB : " + B);
                        itemLight.intensity = 5f;
                        itemLight.range = 25;
                        lights.color = new Vector4(R = 1f, G = 1f, B = 1f, 1);
                        lights.intensity = 0;
                        break;
                    }
                }
                break;
            default:
                timeSub = time;
                for (int i = 0; i < 5000; i++)
                {
                    if (time == 24)
                    {
                        time = 0;
                    }
                    if (time == 1)
                    {
                        timeLight(false);
                    }
                    subtime++;
                    times(subtime);
                    yield return new WaitForSeconds(0.01f);
                    if (time == timeSub + 1)
                    {
                        print("앙 초기황");
                        break;
                    }
                }
                break;
        }
        print(time);
        StartCoroutine(LightCount());
    }
}
