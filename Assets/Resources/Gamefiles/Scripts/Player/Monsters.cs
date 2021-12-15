using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
class MonsterMove
{
    //Transform players; // 플레이어 기준점
    [Header(" - 이동 반경 범위")]
    public int monsterDistance; // npc의 이동 반경 범위
    [Header(" - MONSTER 초기 위치")]
    public Vector3 monsterPosition; // npc의 초기 위치를 담아둘 백터값.
    public Vector2 monsterStartVector;
    [Header(" - MONSTERIdle 이동 시간")]
    [Tooltip("npc가 Idle 즉 추적하지 않을때 이동방향 변경 갱신에 필요한 최소 시간.")]
    public float monsterMoveTime; // npc가 몇초마다 움직임을 바꿀지에 대한 초설정.
    [Header(" - MONSTER pathfinding 시간")]
    [Tooltip("npc가 추적 갱신에 필요한 최소 시간")]
    public float monsterTrackingTime; // npc가 몇초마다 추적경로를 갱신할지에 대한 초설정.
    [Header(" - 애니메이터 집합체")]
    [Tooltip("엔피시는 1번, 플레이어는 2번에 넣음.")]
    public Animator[] anis; // 애니메이션의 위치를 구하기위해 각각 상호작용을 위한 애니메이터를 넣는다.

}

public class Monsters : Character
{
    [SerializeField]
    [Header("MONSTER 설정")]
    [Tooltip("몬스터에 대한 설정")]
    public bool IsMoster; //몬스터 체크.
    public float damage;
    public int monsterHp;
    public int count;
    public float MoveSpeed;
    public float TrackSpeed;
    public float SleepTime;
    public int Defence;
    public Vector2 attack_Range;
    public bool StartAttack;    //먼저 공격할건가?
    [SerializeField]
    [Header("MONSTER이동 관련 설정")]
    [Tooltip("이동 관련 메소드다. 해당 안에는 각종 이동관련에 관한 멤버 필드와 메서드가 들어있다.")]
    MonsterMove nMove; // npc이동 관련 메소드.
    int moves;  //랜덤 이동을 위한 좌표가 될 변수 (동서남북).
    int mrand; // 랜덤 좌표에 쓸 랜덤변수.
    Coroutine _moveCo; // 코루틴을 집어넣을 변수.
    public Transform spAt;
    public BoxCollider2D spAtR;
    [Header("MONSTER 데미지 표기")]
    public Transform damageTextTs;
    public Camera damageCamera;
    public float Knock;
    void Awake()
    {
        //sp = GetComponent<SpriteRenderer>();
        nMove.monsterPosition.x = transform.position.x;
        nMove.monsterPosition.y = transform.position.y;
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
            if (ispath.target == players)
                if (nMove.anis[2] != null)
                    nMove.anis[2].SetBool("Ex", true);
            IsTrackSub = true;
            speed = TrackSpeed;
            nMove.anis[0].SetFloat("Move", 1.5f);
        }
        else
        {
            IsTrackSub = false;
            speed = MoveSpeed;
            nMove.anis[0].SetFloat("Move", 0.8f);
            if (nMove.anis[2] != null)
                nMove.anis[2].SetBool("Ex", false);
            if (!StartAttack)
            {
                IsTrack = false;
            }
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
                    MoveVectors.x = (nMove.monsterDistance != 0) ? ((nMove.monsterPosition.x - nMove.monsterDistance <= transform.position.x) ? -1 : 1) : 0;
                    break;
                case 1:
                    MoveVectors.x = (nMove.monsterDistance != 0) ? ((nMove.monsterPosition.x + nMove.monsterDistance <= transform.position.x) ? -1 : 1) : 0;
                    break;
                case 2:
                    MoveVectors.y = (nMove.monsterDistance != 0) ? ((nMove.monsterPosition.y - nMove.monsterDistance <= transform.position.y) ? -1 : 1) : 0;
                    break;
                case 3:
                    MoveVectors.y = (nMove.monsterDistance != 0) ? ((nMove.monsterPosition.y + nMove.monsterDistance <= transform.position.y) ? -1 : 1) : 0;
                    break;
                case 4:
                    nMove.anis[0].SetBool("Sleep", true);
                    break;
            }
            // 몇초마다 반환할건가?
            // monster의 백터값 부모에 전달
            vector_p = (_moveCo != null ? MoveVectors : Vector3.zero);
        }
        if (nMove.anis[0].GetBool("Sleep") == true)
        {
            yield return new WaitForSeconds(SleepTime);
            nMove.anis[0].SetBool("Sleep", false);
            IsTrack = false;
            if (_moveCo != null)
                StopCoroutine(_moveCo);
            _moveCo = StartCoroutine(moveVector());
        }
        else
        {
            yield return new WaitForSeconds((IsTrackSub == true ? nMove.monsterTrackingTime : nMove.monsterMoveTime));
            if (_moveCo != null)
                StopCoroutine(_moveCo);
            _moveCo = StartCoroutine(moveVector());
        }
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
        base.Update();
    }
    // npc가 player를 통해 멈출경우 
    IEnumerator NpcStops()
    {
        states = States.Idle;
        // NPC가 플레이어의 방향에맞춰 쳐다보게함으로써 대화하는것처럼 만듬.
        if (nMove.anis[1].GetFloat("DirX") == 1)
        {
            nMove.anis[0].SetFloat("DirX", -1);
            nMove.anis[0].SetFloat("DirY", 0);
            for (float i = 0; i < 0.5f; i += 0.1f)
            {
                yield return new WaitForSeconds(0.01f);
                this.transform.position = new Vector3(transform.position.x + i - (i - 0.11f), transform.position.y, transform.position.z);
            }
        }
        else if (nMove.anis[1].GetFloat("DirX") == -1)
        {
            nMove.anis[0].SetFloat("DirX", 1);
            nMove.anis[0].SetFloat("DirY", 0);
            for (float i = 0.5f; i > 0; i -= 0.1f)
            {
                yield return new WaitForSeconds(0.01f);
                this.transform.position = new Vector3(transform.position.x + i - (i + 0.11f), transform.position.y, transform.position.z);
            }
        }
        else if (nMove.anis[1].GetFloat("DirY") == 1)
        {
            nMove.anis[0].SetFloat("DirX", 0);
            nMove.anis[0].SetFloat("DirY", -1);
            for (float i = 0; i < 0.5f; i += 0.1f)
            {
                yield return new WaitForSeconds(0.01f);
                this.transform.position = new Vector3(transform.position.x, transform.position.y + i - (i - 0.11f), transform.position.z);
            }
        }
        else if (nMove.anis[1].GetFloat("DirY") == -1)
        {
            nMove.anis[0].SetFloat("DirX", 0);
            nMove.anis[0].SetFloat("DirY", 1);
            for (float i = 0.5f; i > 0; i -= 0.1f)
            {
                yield return new WaitForSeconds(0.01f);
                this.transform.position = new Vector3(transform.position.x, transform.position.y + i - (i + 0.11f), transform.position.z);
            }
        }
        SoundManagers.instance.PlaySound("dropget", 0.2f);
        monsterHp -= (int)DataManager.instance.damage;
        vector_p = Vector3.zero;
    }
    // Update is called once per frame

    private void MonsterDamageText()
    {
        Instantiate(damageTextTs);
        Vector3 screenPos = damageCamera.WorldToScreenPoint(this.transform.position);
        damageTextTs.position = new Vector3(screenPos.x, screenPos.y + 150f, 0);
        damageTextTs.name = "Damage";

        damageTextTs.GetComponent<DamageText>().DamageNameCo("죽어랑");
        monsterHp -= ((int)DataManager.instance.damage - Defence);
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
        if (other.gameObject.CompareTag("Attack_Range"))
        {
            ispath.PathFinding();
            // MonsterDamageText();
            if (monsterHp <= 0)
            {
                GameObject InvenDrop;
                InvenDrop = Instantiate(Inventory.instance.DropItem);
                InvenDrop.GetComponent<DropItem>().itemType = info.ARMORS;
                InvenDrop.GetComponent<DropItem>().itemNumber = 0;
                InvenDrop.GetComponent<DropItem>().ItemCount = 1;
                Vector2 rand = new Vector2(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f));
                InvenDrop.transform.position = new Vector2(this.transform.position.x + rand.x, this.transform.position.y + rand.y);
                GameObject.Destroy(gameObject);
            }
            StartCoroutine(NpcStops());
            if (!StartAttack)
            {
                IsTrack = true;
                if (_moveCo != null)
                    StopCoroutine(_moveCo);
                _moveCo = StartCoroutine(moveVector());
                nMove.anis[0].SetBool("Sleep", false);
            }


        }
        if (other.CompareTag("obj"))
        {
            // npc 이동 실행
            _moveCo = StartCoroutine(moveVector());
        }
        if (other.CompareTag("Monster") || other.CompareTag("Npc") || other.CompareTag("Collision"))
        {
            npcCol(gameObject.transform.position);
            //vector_p
        }
        if (other.CompareTag("Player"))
        {
            if (IsMoster)
            {
                if (IsTrack == true)
                {
                    DataManager.instance.health -= damage;
                }
            }
            else
            {
                vector_p = Vector3.zero;
                IsTrackSub = false;
            }
        }
    }
    // 비접촉후 코루틴
    IEnumerator NpcMoveReset()
    {
        float dis = Vector2.Distance(transform.position, players.position);
        if (DataManager.instance.worldmapNpc)
        {
            transform.position = nMove.monsterPosition;
            StopCoroutine(NpcMoveReset());
        }
        yield return new WaitForSeconds(0.5f);
        if (dis >= 20)
        {
            transform.position = nMove.monsterPosition;
            StopCoroutine(NpcMoveReset());
        }
        else
            StartCoroutine(NpcMoveReset());
    }

    // 비접촉시
    protected override void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Attack_Range") && this.CompareTag("Monster"))
        {
            nMove.anis[0].SetFloat("DirX", nMove.monsterStartVector.x);
            nMove.anis[0].SetFloat("DirY", nMove.monsterStartVector.y);
        }
        if (other.CompareTag("obj"))
        {
            if (_moveCo != null)
            {
                _moveCo = null;
                StartCoroutine(NpcMoveReset());
            }
        }
    }
}
