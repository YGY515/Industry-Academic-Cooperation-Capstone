using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float force = 1.0f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * force);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("miniGameItem")) // 실제 화살이 과녁이랑 맞으면.
        {
            rb.velocity = Vector3.zero;
            rb.isKinematic =true;
            // 함수 호출
            StartCoroutine(InteractToActing());// -> 과녁 맞추고 몇초 후에 일어날 일.  
        }
    }

    IEnumerator InteractToActing()
    {
        // 0.2초
        yield return new WaitForSeconds(1.0f);
        gameObject.SetActive(false); // 화살 비활성화.

           MiniGame3Manager.Instance.GetScore();

        if(MiniGame3Manager.Instance.shootCount == 5)
        {
            MiniGame3Manager.Instance.GameOver();
            yield break;
        }

       // 화살표 속도 변경.
        MiniGame3Manager.Instance.arrowOnBar.ChangeSpeed();
        MiniGame3Manager.Instance.arrowOnBar.move = true; // 화살표가 움직여도 되는지.
        MiniGame3Manager.Instance.stopbutton.pushButton.interactable = true; // 버튼 활성화
    }
}
