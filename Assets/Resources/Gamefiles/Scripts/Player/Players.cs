using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Players : Character
{
    public virtuarstic joystick;
    public Button button;
    public Transform spAt;
    public BoxCollider2D spAtR;
    [SerializeField]
    private EquipeMentSocket[] eqSocket;
    [SerializeField]
    private GameObject[] attackVector;
    [SerializeField]
    private GameObject[] TalkVector;
    //private Quaternion quaternion; // 회전을 담당하는.
    // PC용.

    /*     void MoveVector()
        {
            Vector3 MoveVectors = Vector3.zero;
            if (Input.GetAxisRaw("Horizontal") != 0)
            {
             MoveVectors.x = Input.GetAxisRaw("Horizontal"); 
            }
            else if (Input.GetAxisRaw("Vertical") != 0)
            MoveVectors.y = Input.GetAxisRaw("Vertical");

            vector_p = MoveVectors;

            // quaternion = Quaternion.Euler(0,0,90); // 회전하기.
        } */

    void MovejoyVector()
    {
        Vector3 MoveVectors = Vector3.zero;
        if (isDropItemGet == false)
        {
            if (joystick.GetHorizontalValue() != 0)
            {
                MoveVectors.x = joystick.GetHorizontalValue();
            }
            if (joystick.GetVerticalValue() != 0)
            {
                MoveVectors.y = joystick.GetVerticalValue();
            }
        }
        vector_p = MoveVectors;
    }


    IEnumerator GetMotion()
    {
        if (isDropItemGet == false)
        {
            ButtonManager.instance.dropgets = true;
            isDropItemGet = true;
            animator.SetBool("IsDropGet", isDropItemGet);
            foreach (EquipeMentSocket g in eqSocket)
            {
                g.EqAnimator.SetBool("IsDropGet", isDropItemGet);
            }
            yield return new WaitForSeconds(0.25f);
            SoundManagers.instance.PlaySound("dropget", 0.2f);
            yield return new WaitForSeconds(0.45f);
            isDropItemGet = false;
            animator.SetBool("IsDropGet", false);
            foreach (EquipeMentSocket g in eqSocket)
            {
                g.EqAnimator.SetBool("IsDropGet", isDropItemGet);
            }
            states = States.Idle;
        }
    }
    public void ItemGetMotion()
    {
        StartCoroutine(GetMotion());
    }
    IEnumerator TalkCo()
    {
        states = States.Talk;
        if (animator.GetFloat("DirX") == 1)
        {
            TalkVector[3].SetActive(true);
        }
        else if (animator.GetFloat("DirX") == -1)
        {
            TalkVector[2].SetActive(true);
        }
        else if (animator.GetFloat("DirY") == 1)
        {
            TalkVector[1].SetActive(true);
        }
        else if (animator.GetFloat("DirY") == -1)
        {
            TalkVector[0].SetActive(true);
        }
        vector_p = Vector3.zero;
        yield return new WaitForSeconds(0.1f);
        for (int i = 0; i < TalkVector.Length; i++)
        {
            TalkVector[i].SetActive(false);
        }
    }
    public void talkbutton()
    {
        StartCoroutine(TalkCo());
    }
    protected override void AnimationMove()
    {
        base.AnimationMove();

        if (IsMoving)
        {
            animator.SetFloat("MoveSpeed", DataManager.instance.speed - 3);
            foreach (EquipeMentSocket g in eqSocket)
            {
                g.SetXY(vector_p.x, vector_p.y);
                g.EqAnimator.SetFloat("MoveSpeed", DataManager.instance.speed - 3);
            }
        }
    }

    protected override void ActivateLayer(LayerName layerName)
    {
        base.ActivateLayer(layerName);

        foreach (EquipeMentSocket g in eqSocket)
        {
            g.ActivateLayer(layerName);
        }
    }
    protected override void Update()
    {
        if (states == States.Walk || states == States.Idle)
            MovejoyVector();
        base.Update();
    }
}
