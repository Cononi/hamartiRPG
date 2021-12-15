using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipeMentSocket : MonoBehaviour
{
    public Animator EqAnimator { get; set; }
    public Animator players;
    public SpriteRenderer spriteRenderer;
    private Animator parentAnimaitor;
    public Character character;
    public enum LayerName
    {
        IdleLayer = 0,
        WalkLayer = 1,
        DropGetItemLayer = 2
    }
    AnimatorStateInfo anis; // 애니메이터의현재 실행정보를 담을 변수
    private AnimatorOverrideController animatorOverrideController;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        parentAnimaitor = GetComponentInParent<Animator>();
        EqAnimator = GetComponent<Animator>();

        animatorOverrideController = new AnimatorOverrideController(EqAnimator.runtimeAnimatorController);

        EqAnimator.runtimeAnimatorController = animatorOverrideController;
        anis = players.GetCurrentAnimatorStateInfo(1);    // 애니메이터의 에니메이션의 현재 상태를 찾는다.
        Dequip();
    }

    public void SetXY(float x, float y)
    {
        EqAnimator.SetFloat("DirX", x);
        EqAnimator.SetFloat("DirY", y);
    }

    public void ActivateLayer(Character.LayerName layerName)
    {
        // 모든 레이어의 무게값을 0 으로 만들어 줍니다.
        for (int i = 0; i < EqAnimator.layerCount; i++)
        {
            EqAnimator.SetLayerWeight(i, 0);
        }
        EqAnimator.SetLayerWeight((int)layerName, 1);
    }
    public void Equip(AnimationClip[] animations)
    {
        spriteRenderer.color = Color.white;
        animatorOverrideController["ItemDropGet"] = animations[0];

        animatorOverrideController["Player_Idle_Down"] = animations[1];
        animatorOverrideController["Player_Idle_Left"] = animations[2];
        animatorOverrideController["Player_Idle_Right"] = animations[3];
        animatorOverrideController["Player_Idle_Up"] = animations[4];

        animatorOverrideController["Player_Move_Down"] = animations[5];
        animatorOverrideController["Player_Move_Left"] = animations[6];
        animatorOverrideController["Player_Move_Right"] = animations[7];
        animatorOverrideController["Player_Move_Up"] = animations[8];
    }

    public void Dequip()
    {
        animatorOverrideController["ItemDropGet"] = null;

        animatorOverrideController["Player_Idle_Down"] = null;
        animatorOverrideController["Player_Idle_Left"] = null;
        animatorOverrideController["Player_Idle_Right"] = null;
        animatorOverrideController["Player_Idle_Up"] = null;

        animatorOverrideController["Player_Move_Down"] = null;
        animatorOverrideController["Player_Move_Left"] = null;
        animatorOverrideController["Player_Move_Right"] = null;
        animatorOverrideController["Player_Move_Up"] = null;

        Color c = spriteRenderer.color;
        c.a = 0;
        spriteRenderer.color = c;
        spriteRenderer.sprite = null;
    }

    /*     IEnumerator move()
        {
            AnimatorStateInfo anis; // 애니메이터의현재 실행정보를 담을 변수
            anis = EqAnimator.GetCurrentAnimatorStateInfo(0);    // 애니메이터의 에니메이션의 현재 상태를 찾는다.

            float timesk = anis.normalizedTime + Time.deltaTime;  // 현재 애니메이션 진행상태 + 첫번째 애니메이터의 클립의 길이를 더한다.
            // 애니메이터 동기화를 위한 장치.
            EqAnimator.Play("Player_Move_Down", 0, timesk);   // i들의 애니메이터를 동기화 시킨다. 현재 진행중인 0번의 애미네이터 길이만큼 동기화 시킨다.
        } */

    private void FixedUpdate()
    {
        float timesk2 = (anis.normalizedTime + 0.09f);
        float timesk = (anis.normalizedTime + 0.045f);  // 현재 애니메이션 진행상태 + 첫번째 애니메이터의 클립의 길이를 더한다.
                                                        //EqAnimator.SetFloat("MoveSpeed", players.GetFloat("MoveSpeed"));
                                                        // 애니메이터 동기화를 위한 장치.
        EqAnimator.Play("Player_Working", 1, players.GetCurrentAnimatorStateInfo(1).normalizedTime);   // i들의 애니메이터를 동기화 시킨다. 현재 진행중인 0번의 애미네이터 길이만큼 동기화 시킨다.
        EqAnimator.Play("Player_Idle", 0, players.GetCurrentAnimatorStateInfo(0).normalizedTime);
    }
}
