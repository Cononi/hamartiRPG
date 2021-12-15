using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
class npcMove
{
    //Transform players; // 플레이어 기준점
    [Header(" - 이동 반경 범위")]
    public int npcDistance; // npc의 이동 반경 범위
    [Header(" - NPC 초기 위치")]
    public Vector3 npcPosition; // npc의 초기 위치를 담아둘 백터값.
    public Vector2 npcStartVector;
    [Header(" - NPC Idle 이동 시간")]
    [Tooltip("npc가 Idle 즉 추적하지 않을때 이동방향 변경 갱신에 필요한 최소 시간.")]
    public float npcMoveTime; // npc가 몇초마다 움직임을 바꿀지에 대한 초설정.
    [Header(" - NPC pathfinding 시간")]
    [Tooltip("npc가 추적 갱신에 필요한 최소 시간")]
    public float npcTrackingTime; // npc가 몇초마다 추적경로를 갱신할지에 대한 초설정.
    [Header(" - 애니메이터 집합체")]
    [Tooltip("엔피시는 1번, 플레이어는 2번에 넣음.")]
    public Animator[] anis; // 애니메이션의 위치를 구하기위해 각각 상호작용을 위한 애니메이터를 넣는다.
}

public class Npcs : Character
{
    [SerializeField]
    [Header("NPC이동 관련 설정")]
    [Tooltip("이동 관련 메소드다. 해당 안에는 각종 이동관련에 관한 멤버 필드와 메서드가 들어있다.")]
    npcMove nMove; // npc이동 관련 메소드.
    int moves;  //랜덤 이동을 위한 좌표가 될 변수 (동서남북).
    int mrand; // 랜덤 좌표에 쓸 랜덤변수.
    Sign sign; // sign 스크립트.
    Coroutine _moveCo; // 코루틴을 집어넣을 변수.

    void Awake()
    {
        sign = GetComponent<Sign>();
        //sp = GetComponent<SpriteRenderer>();
        nMove.npcPosition.x = transform.position.x;
        nMove.npcPosition.y = transform.position.y;
    }
    // 랜덤이동 수정이 필요함.

    public IEnumerator moveVector()
    {
        if (this.enabled == true)
            charDistance = Vector2.Distance(transform.position, players.position);
        // vector3 변수 선언과 동시에 MoveVectors 값을 초기화 한다.
        Vector3 MoveVectors = Vector3.zero;

        // 사정거리에 들면 추척한다.
        if (charDistance < ispath.range && IsTrack == true)
        {
            IsTrackSub = true;
            speed = 2f;
        }
        else
        {
            IsTrackSub = false;
            speed = 0.5f;
        }
        // 사정거리가 아니면 추적하지 않음.
        if (IsTrack && IsTrackSub == true)
        {
            // 실시간으로 좌표 갱신.
            ispath.PathFinding();
        }
        else
        {
            // 랜덤값을 저장.
            mrand = Random.Range(0, 5);
            switch (mrand)
            {
                /*
                설정한 좌우값이 0과 같을경우 0으로 반환한다. (값을 비웠을때 이동하는걸 방지)
                설정한 좌우값이 0과 다를경우 3항연산자를 실행하여 반환 한다.
                이동후 (초기 NPC의 설정된 위치값 - or + NPC의 설정된 최대 좌우값)보다 현재 NPC 위치값 크거나 같다면 -1을 반환하며 아니라면 1을 반환하여 지정위치에서 벗어나질 못하게 한다.
                */
                case 0:
                    MoveVectors.x = (nMove.npcDistance != 0) ? ((nMove.npcPosition.x - nMove.npcDistance <= transform.position.x) ? -1 : 1) : 0;
                    break;
                case 1:
                    MoveVectors.x = (nMove.npcDistance != 0) ? ((nMove.npcPosition.x + nMove.npcDistance <= transform.position.x) ? -1 : 1) : 0;
                    break;
                case 2:
                    MoveVectors.y = (nMove.npcDistance != 0) ? ((nMove.npcPosition.y - nMove.npcDistance <= transform.position.y) ? -1 : 1) : 0;
                    break;
                case 3:
                    MoveVectors.y = (nMove.npcDistance != 0) ? ((nMove.npcPosition.y + nMove.npcDistance <= transform.position.y) ? -1 : 1) : 0;
                    break;
                case 4:
                    break;
            }
            // 몇초마다 반환할건가?
            // npc의 백터값 부모에 전달
            if (!sign.dialogActive)
            {
                vector_p = (_moveCo != null ? MoveVectors : Vector3.zero);
                base.Update();
            }
            else
                vector_p = Vector3.zero;
        }
        yield return new WaitForSeconds((IsTrackSub == true ? nMove.npcTrackingTime : nMove.npcMoveTime));
        StartCoroutine(moveVector());
    }
    private void npcCol(Vector3 dir)
    {
        Vector3 MoveVectors = Vector3.zero;
        // npc가 이동할 수 없을경우 현재 방향의 반대 값을 반환한다.
        if (dir.x != 0)
        {
            MoveVectors.x = (dir.x == 1) ? -1 : 1;
        }
        else if (dir.y != 0)
        {
            MoveVectors.y = (dir.y == 1) ? -1 : 1;
        }
        vector_p = MoveVectors;
    }
    // npc가 player를 통해 멈출경우 
    private void NpcStops()
    {
        states = States.Idle;
        // NPC가 플레이어의 방향에맞춰 쳐다보게함으로써 대화하는것처럼 만듬.
        if (nMove.anis[1].GetFloat("DirX") == 1)
        {
            nMove.anis[0].SetFloat("DirX", -1);
            nMove.anis[0].SetFloat("DirY", 0);
        }
        else if (nMove.anis[1].GetFloat("DirX") == -1)
        {
            nMove.anis[0].SetFloat("DirX", 1);
            nMove.anis[0].SetFloat("DirY", 0);
        }
        else if (nMove.anis[1].GetFloat("DirY") == 1)
        {
            nMove.anis[0].SetFloat("DirX", 0);
            nMove.anis[0].SetFloat("DirY", -1);
        }
        else if (nMove.anis[1].GetFloat("DirY") == -1)
        {
            nMove.anis[0].SetFloat("DirX", 0);
            nMove.anis[0].SetFloat("DirY", 1);
        }
        vector_p = Vector3.zero;
    }
    public void npcStart()
    {
        nMove.anis[0].SetFloat("DirX", 0);
        nMove.anis[0].SetFloat("DirY", -1);
    }
    // 실시간 업데이트.
    protected override void Update()
    {
        if (_moveCo != null)
            // 오브젝트의 과도한 실행을 방지하기 위한 제어변수.
            base.Update();
    }
    // 접촉시.
    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Attack_Range"))
        {
            NpcStops();
        }
        if (other.CompareTag("obj"))
        {
            // npc 이동 실행
            _moveCo = StartCoroutine(moveVector());
        }
        if (other.CompareTag("Npc") || other.CompareTag("Collision"))
        {
            if (!IsTrackSub)
                npcCol(transform.position);

            //vector_p
        }
    }

    // 비접촉후 코루틴
    IEnumerator NpcMoveReset()
    {
        float dis = Vector2.Distance(transform.position, players.position);
        yield return new WaitForSeconds(0.5f);
        if (dis >= 20)
        {
            transform.position = nMove.npcPosition;
            StopCoroutine(NpcMoveReset());
        }
        else
            StartCoroutine(NpcMoveReset());
    }
    // 비접촉시
    protected override void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Talk_Range"))
        {
            nMove.anis[0].SetFloat("DirX", nMove.npcStartVector.x);
            nMove.anis[0].SetFloat("DirY", nMove.npcStartVector.y);
        }
        if (other.CompareTag("obj"))
        {
            _moveCo = null;
            StartCoroutine(NpcMoveReset());
        }
    }
}
