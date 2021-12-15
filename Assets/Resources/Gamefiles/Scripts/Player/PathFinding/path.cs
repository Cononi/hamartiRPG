﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class path : MonoBehaviour
{
    [Header(" - 추적 반경 설정")]
    public int range; // 추적 반경.
    Vector2Int bottomLeft, topRight, startPos, targetPos; // 상하 좌우 반경범위, 오브젝트 좌표, 타겟 좌표.
    [HideInInspector]
    public List<Node> FinalNodeList; //최종적으로 정해진 길.
    [SerializeField]
    [Header(" - 추적 타겟")]
    public Transform target; // 추적할 타겟.
    int sizeX, sizeY; // 추적할 타일 넓이.
    Node[,] NodeArray; // 타일 노드
    Node StartNode, TargetNode, CurNode; // 시작노드, 타겟노드, 현재노드.
    List<Node> OpenList, ClosedList; // 열린 리스트[갈 수 있는 공간], 닫힌리스트[갈 수 없는 공간]
    public List<Node> chackList; // 오브젝트가 진로변경씨 생성되는 체크포인트. 최종적으로 이걸 따라서 감.
                                 //public int targetIndex; //타겟 인덱스 번호.
    Vector2Int rand;
    public void PathFinding()
    {
        startPos = Vector2Int.RoundToInt(transform.position);
        targetPos = Vector2Int.RoundToInt(target.position);
        bottomLeft = new Vector2Int(startPos.x - range, startPos.y - range);
        topRight = new Vector2Int(startPos.x + range, startPos.y + range);
        // NodeArray의 크기 정해주고, isWall, x, y 대입
        sizeX = topRight.x - bottomLeft.x + 1;
        sizeY = topRight.y - bottomLeft.y + 1;
        NodeArray = new Node[sizeX, sizeY];

        for (int i = 0; i < sizeX; i++)
        {
            for (int j = 0; j < sizeY; j++)
            {
                bool isWall = false;
                foreach (Collider2D col in Physics2D.OverlapCircleAll(new Vector2(i + bottomLeft.x, j + bottomLeft.y), 0.45f))
                    if (col.gameObject.layer == LayerMask.NameToLayer("Collision")) isWall = true;

                NodeArray[i, j] = new Node(isWall, i + bottomLeft.x, j + bottomLeft.y);
            }
        }

        // 시작과 끝 노드, 열린리스트와 닫힌리스트, 마지막리스트 초기화
        StartNode = NodeArray[startPos.x - bottomLeft.x, startPos.y - bottomLeft.y];
        TargetNode = NodeArray[targetPos.x - bottomLeft.x + rand.x, targetPos.y - bottomLeft.y + rand.y];
        OpenList = new List<Node>() { StartNode };
        ClosedList = new List<Node>();
        FinalNodeList = new List<Node>();
        chackList = new List<Node>();


        while (OpenList.Count > 0)
        {
            // 열린리스트 중 가장 F가 작고 F가 같다면 H가 작은 걸 현재노드로 하고 열린리스트에서 닫힌리스트로 옮기기
            CurNode = OpenList[0];
            for (int i = 1; i < OpenList.Count; i++)
                if (OpenList[i].F <= CurNode.F && OpenList[i].H < CurNode.H) CurNode = OpenList[i];
            OpenList.Remove(CurNode);
            ClosedList.Add(CurNode);


            // 마지막
            if (CurNode == TargetNode)
            {

                Node TargetCurNode = TargetNode;
                while (TargetCurNode != StartNode)
                {
                    FinalNodeList.Add(TargetCurNode);
                    TargetCurNode = TargetCurNode.ParentNode;
                }
                FinalNodeList.Add(StartNode);
                FinalNodeList.Reverse();
                Vector2 nodex = new Vector2(transform.position.x, transform.position.y);
                for (int i = 1; i < FinalNodeList.Count - 1; i++) //print(i + "번째는 " + FinalNodeList[i].x + ", " + FinalNodeList[i].y);
                {
                    if (FinalNodeList[i].x != FinalNodeList[i + 1].x && FinalNodeList[i].y != FinalNodeList[i - 1].y || FinalNodeList[i].x != FinalNodeList[i - 1].x && FinalNodeList[i].y != FinalNodeList[i + 1].y)
                    {
                        chackList.Add(FinalNodeList[i]);
                    }
                }
                chackList.Add(FinalNodeList[FinalNodeList.Count - 1]);
                return;
            }

            // ↑ → ↓ ←
            OpenListAdd(CurNode.x, CurNode.y + 1);
            OpenListAdd(CurNode.x + 1, CurNode.y);
            OpenListAdd(CurNode.x, CurNode.y - 1);
            OpenListAdd(CurNode.x - 1, CurNode.y);
        }
    }

    void OpenListAdd(int checkX, int checkY)
    {
        // 상하좌우 범위를 벗어나지 않고, 벽이 아니면서, 닫힌리스트에 없다면
        if (checkX >= bottomLeft.x && checkX < topRight.x + 1 && checkY >= bottomLeft.y && checkY < topRight.y + 1 && !NodeArray[checkX - bottomLeft.x, checkY - bottomLeft.y].isWall && !ClosedList.Contains(NodeArray[checkX - bottomLeft.x, checkY - bottomLeft.y]))
        {
            // 이웃노드에 넣고, 직선은 10, 대각선은 14비용
            Node NeighborNode = NodeArray[checkX - bottomLeft.x, checkY - bottomLeft.y];
            int MoveCost = CurNode.G + (CurNode.x - checkX == 0 || CurNode.y - checkY == 0 ? 10 : 14);


            // 이동비용이 이웃노드G보다 작거나 또는 열린리스트에 이웃노드가 없다면 G, H, ParentNode를 설정 후 열린리스트에 추가
            if (MoveCost < NeighborNode.G || !OpenList.Contains(NeighborNode))
            {
                NeighborNode.G = MoveCost;
                NeighborNode.H = (Mathf.Abs(NeighborNode.x - TargetNode.x) + Mathf.Abs(NeighborNode.y - TargetNode.y)) * 10;
                NeighborNode.ParentNode = CurNode;

                OpenList.Add(NeighborNode);
            }
        }
    }

/*     void OnDrawGizmos()
    {
        if (FinalNodeList.Count != 0) for (int i = 0; i < FinalNodeList.Count - 1; i++)
            {
                Gizmos.DrawLine(new Vector2(FinalNodeList[i].x, FinalNodeList[i].y), new Vector2(FinalNodeList[i + 1].x, FinalNodeList[i + 1].y));
            }
    } */


// 필히 수정이 필요함. 빈공간을 위해서라도.
/*         if (other.CompareTag("Npc") || other.CompareTag("Collision"))
        { 
            // 갈수 없다면 주변 노드로이동.
           // rand = new Vector2Int(Random.Range(-1, 2), Random.Range(-1, 2));
        }
    } */
    /*     void moveMent()
        {
            // vector3 변수 선언과 동시에 MoveVectors 값을 초기화 한다.
            Vector3 MoveVectors = Vector3.zero;
            // 추적중이라면 따라감.
            float distance = Vector3.Distance(transform.position, target.position);
            float Posx = (transform.position.x - chackList[targetIndex].x);
            float Posy = (transform.position.y - chackList[targetIndex].y);

            if (distance >= 1.3)
            {
                if ((Posx < Posy && transform.position.y > chackList[targetIndex].y))
                {
                    MoveVectors.y = -1;
                }
                else if (Posx > Posy && transform.position.y < chackList[targetIndex].y)
                {
                    MoveVectors.y = 1;
                }
                else if (Posy > Posx && transform.position.x < chackList[targetIndex].x)
                {
                    MoveVectors.x = 1;
                }
                else if (Posy < Posx && transform.position.x > chackList[targetIndex].x)
                {
                    MoveVectors.x = -1;
                }
                vector_p = MoveVectors;
            }
            else
            {
                vector_p = Vector3.zero;
            }
        } */

    /*     private void FixedUpdate()
        {
            moveMent();
        } */
    /*     protected override void Update()
        {
            base.Update();
        } */

}
