using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class CardStart : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler, IPointerEnterHandler
{
    [SerializeField] private int matchId;
    public int Get_ID()
    {
        return matchId;
    }

    public GameObject linePreFab;
    private GameObject line;

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 SStoWS = Camera.main.ScreenToWorldPoint(eventData.position);
        UpdateLine(SStoWS);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("PointerDown");
        // line prefab ����.
        line = Instantiate(linePreFab, transform.position, Quaternion.identity, transform.parent);

        // world space�� ����.
        Vector3 SStoWS = Camera.main.ScreenToWorldPoint(eventData.position);
        UpdateLine(SStoWS); // eventData.postion�� ���콺 ���� ��ġ.
    }

    void UpdateLine(Vector3 position)
    {
        // Update direction
        // ���� �����ؾ� �Ѵ�. z�� ���� ī��� �����ϰ�
        Vector3 linePos = new Vector3(position.x, position.y, transform.position.z);
        Vector3 direction = linePos - transform.position;
        line.transform.right = direction;

        // update scale
        line.transform.localScale = new Vector3(direction.magnitude, 1, 1);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("The cursor entered the selectable UI element.");
        // hoverItem = this;
        Debug.Log(matchId);
    }

    public void OnPointerUp(PointerEventData eventData)
    {

        Debug.Log("The cursor Up the selectable UI element.");
        //if (!this.Equals(hoverItem) && itemName.Equals(hoverItem.itemName))
        //{
        //    UpdateLine(hoverItem.transform.position);
        //    MatchLogic.AddPoint();
        //    Destroy(hoverItem);
        //    Destroy(this);

        //}
        //else
        //{
        //    Destroy(line);
        //}
    }

}
