using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Character : MonoBehaviour
{
    // 현재 상태
    protected enum States
    {
        Idle,
        Walk,
        Talk,
        GetItem,
    }

    // 각종 레이어.
    public enum LayerName
    {
        IdleLayer = 0,
        WalkLayer = 1,
        DropGetItemLayer = 2
    }

    //직렬화.
    [Header(" - 속 도")]
    [Tooltip("해당 오브젝트의 이동속도를 결정한다.")]
    protected float speed = 3; // 플레이어 스피드.
    protected Rigidbody2D Rigidbody_p; // 릿지드 바디.
    protected Vector3 vector_p; // 해당 오브젝트 현재 상태
    protected Animator animator; // 해당 오브젝트 애니메이터.
    [SerializeField]
    [Header(" - 현재 상태")]
    [Tooltip("현재 상태를 표시한다.")]
    protected States states; // 현재 상태.
    protected bool isDropItemGet = false; // 먹는중인가?
    protected bool isWalking = false; // 먹는중인가?
    protected SpriteRenderer sp; // 레이어 무게를 바꾸기 위한것
    protected Transform players; // 플레이어를 레이어를 바꾸기 위한 트랜스폼
    protected float charDistance; // 오브젝트와 플레이어간의 거리.
    protected bool IsTrackSub; // 추적함수체크 서브.
    [SerializeField]
    [Header(" - 추적 체크")]
    [Tooltip("위치 추적이 가능하도록 ispath가 입력 되어 있을때 체크하면 추적 아니면 null이면 추적하지 않는다.")]
    protected bool IsTrack; // 추적할것인지 아닌지에 대한 체크.
    [Header(" - 위치 추적")]
    [Tooltip("위치 주적을 해야한다면 컴포넌트 대입을하고 아니면 null상태로 만든다.")]
    public path ispath; // 패스파인딩을 위한 함수 추적할거라면 추가를 한다.
    public Transform s;
    protected virtual void Start()
    {
        if (transform.name == "Player")
            speed = DataManager.instance.speed;
        if (transform.name != "Player")
            players = GameObject.Find("Player").GetComponent<Transform>();
        sp = GetComponent<SpriteRenderer>();
        // 오브젝트의 애니메이터를 연결한다.
        animator = GetComponent<Animator>();
        // 오브젝트의 릿지드바디를 연결한다.
        Rigidbody_p = GetComponent<Rigidbody2D>();
        StartCoroutine(NpcLayer());
    }
    protected virtual void Update()
    {
    }

    private void FixedUpdate()
    {
        AnimationMove();
        //AnimationMove();
        if (transform.name == "Player")
        {
            speed = DataManager.instance.speed;
        }
        if (IsTrack && ispath != null && IsTrackSub)
            Istraking();
        else
            Move();
    }

    // npc 레이어 변환
    public IEnumerator NpcLayer()
    {
        if (sp != null && players != null)
        {
            if (transform.position.y < players.position.y)
            {
                sp.sortingOrder = 100;
            }
            else
            {
                sp.sortingOrder = 96;
            }
        }
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(NpcLayer());
    }
    // 이동할 수 없을경우.
    public bool IsMoving
    {
        get
        {
            return vector_p.x != 0 || vector_p.y != 0;
        }
    }
    public void Move()
    {
        Rigidbody_p.MovePosition(transform.position + (vector_p * speed * Time.deltaTime));
        // Rigidbody.MovePosition은 rigidbody의 움직임에 따라 물리적인 힘이 적용된다.
        // 다른 rigidbody와 상호작용을 원하면 FixedUpdate함수에서 이동해야 합니다.
    }
    protected virtual void ActivateLayer(LayerName layerName)
    {
        if (animator.layerCount != 1)
        {
            // 모든 레이어의 무게값을 0 으로 만들어 줍니다.
            for (int i = 0; i < animator.layerCount; i++)
            {
                animator.SetLayerWeight(i, 0);
            }
            animator.SetLayerWeight((int)layerName, 1);
        }
    }

    // virtual은 상속받은 클래스에서 재정의 할 것이라고 미리 선언한다.
    // protected는 말그대로 보호,감추다 이다. 상속받은 클래스에서만 접근이 가능하다/
    protected virtual void AnimationMove()
    {
        if (IsMoving)
        {
            states = States.Walk;
            ActivateLayer(LayerName.WalkLayer);
            animator.SetFloat("DirX", vector_p.x);
            animator.SetFloat("DirY", vector_p.y);
        }
        else if (isDropItemGet)
        {
            states = States.GetItem;
            ActivateLayer(LayerName.DropGetItemLayer);
        }
        // 걷지 않을경우 걷는 모션을 비활성화 한다.
        else
        {
            states = States.Idle;
            ActivateLayer(LayerName.IdleLayer);
        }
    }
    // path를 찾고 다시 이동으로 대입.
    public void Istraking()
    {
        // vector3 변수 선언과 동시에 MoveVectors 값을 초기화 한다.
        Vector3 MoveVectors = Vector3.zero;
        // 추적중이라면 따라감.
        charDistance = Vector3.Distance(transform.position, ispath.target.position);
        float Posx = (transform.position.x - ispath.chackList[0].x);
        float Posy = (transform.position.y - ispath.chackList[0].y);
        if (charDistance >= 1.3)
        {
            if ((Posx < Posy && transform.position.y > ispath.chackList[0].y))
            {
                MoveVectors.y = -1;
            }
            else if (Posx > Posy && transform.position.y < ispath.chackList[0].y)
            {
                MoveVectors.y = 1;
            }
            else if (Posy > Posx && transform.position.x < ispath.chackList[0].x)
            {
                MoveVectors.x = 1;
            }
            else if (Posy < Posx && transform.position.x > ispath.chackList[0].x)
            {
                MoveVectors.x = -1;
            }
            vector_p = MoveVectors;
        }
        else
        {
            vector_p = Vector3.zero;
            IsTrackSub = false;
        }
        Move();
    }



    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
    }
    protected virtual void OnTriggerStay2D(Collider2D other)
    {
    }
    protected virtual void OnTriggerExit2D(Collider2D other)
    {
    }
    protected virtual void OnCollisionEnter2D(Collision2D other)
    {
    }
    protected virtual void OnCollisionExit2D(Collision2D other)
    {
    }
}
