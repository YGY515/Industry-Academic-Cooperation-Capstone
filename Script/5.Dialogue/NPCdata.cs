using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New NPC", menuName = "NPC")]
public class NPCdata : ScriptableObject
{
    public new string name;          // NPC 이름
    public int viewRange;           // 시야 범위
    public int notif;               // 알림 상태 (0: 기본, 1: 퀘스트[?], 2: 보상[!])
    public DialogueData dialogue;   // 대사 데이터
}