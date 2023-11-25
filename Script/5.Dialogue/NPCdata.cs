using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New NPC", menuName = "NPC")]
public class NPCdata : ScriptableObject
{
    public new string name;          // NPC �̸�
    public int viewRange;           // �þ� ����
    public int notif;               // �˸� ���� (0: �⺻, 1: ����Ʈ[?], 2: ����[!])
    public DialogueData dialogue;   // ��� ������
}