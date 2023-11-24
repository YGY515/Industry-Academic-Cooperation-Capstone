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
        // line prefab 생성.
        line = Instantiate(linePreFab, transform.position, Quaternion.identity, transform.parent);

        // world space로 변경.
        Vector3 SStoWS = Camera.main.ScreenToWorldPoint(eventData.position);
        UpdateLine(SStoWS); // eventData.postion은 마우스 현재 위치.
    }

    void UpdateLine(Vector3 position)
    {
        // Update direction
        // 선은 평행해야 한다. z는 현재 카드와 동일하게
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
