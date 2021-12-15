using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageText : MonoBehaviour
{
    public Text damages;

    public void DamageCon(int damage, string s)
    {
        switch(s)
        {
            case "Critical" :
            break;
            case "Attack" :
            DamageNameCo(damage.ToString());
            break;
        }
    }

    public IEnumerator DamageNameCo(string s)
    {
        damages.text = s;
        yield return new WaitForSeconds(2f);
        // 오브젝트를 온시킴.
        for (float i = 1; i >= 0; i -= 0.02f)
        {
            this.transform.position += new Vector3(0, i * 1.5f, 0);
            damages.color = new Vector4(damages.color.r, damages.color.g, damages.color.b, i);
            yield return new WaitForSeconds(0.01f);
        }
        GameObject.Destroy(gameObject);
    }
}
