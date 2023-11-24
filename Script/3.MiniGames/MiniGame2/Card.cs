using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class Card : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    // Card의 속담 ID. 짝을 맞추기 위함.

    [SerializeField]
    private int matchId;
    [SerializeField]
    private string proverb;
    public Transform point;

    public int Get_ID()
    {
        return matchId;
    }
 
    public string Get_Proverb()
    {
        return proverb;
    }
   
    public GameObject linePreFab;
    private GameObject line;

    public GameObject Get_LINE()
    {
        return line;
    }

    // 마우스 버튼을 눌렀을 때,
    public void OnPointerDown(PointerEventData eventData)
    {
        // 여기서 스타트 카드를 확인.
        MiniGame2Manager.Instance.StartCardClicked(this);
           
        // line prefab 생성.
        line = Instantiate(linePreFab, point.position, Quaternion.identity,transform.parent);

        // world space로 변경.
        Vector3 SStoWS = Camera.main.ScreenToWorldPoint(eventData.position);
        UpdateLine(SStoWS); // eventData.postion은 마우스 현재 위치.
    }
    public void OnDrag(PointerEventData eventData)
    {
        Vector3 SStoWS = Camera.main.ScreenToWorldPoint(eventData.position);
        UpdateLine(SStoWS);
    }

    void UpdateLine(Vector3 position)
    {
        // Update direction
        // 선은 평행해야 한다. z는 현재 카드와 동일하게
        Vector3 linePos = new Vector3(position.x, position.y, point.position.z);
        Vector3 direction = linePos - point.position;
        line.transform.right = direction;

        // update scale
        line.transform.localScale = new Vector3(direction.magnitude, 1, 1);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (MiniGame2Manager.Instance.CardMatchCheck()) 
            UpdateLine(MiniGame2Manager.Instance.GetEndCard().point.position);
    }

}
