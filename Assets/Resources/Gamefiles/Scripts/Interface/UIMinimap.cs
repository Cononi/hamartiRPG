using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using UnityEngine.Events;

public partial class UIMinimap : MonoBehaviour
{
    public Text sceneText;
    public Camera minimapCamera;


    void Update()
    {
            sceneText.text = "하레스";
    }
}
