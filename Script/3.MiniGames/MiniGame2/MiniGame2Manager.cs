using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MiniGame2Manager : MonoBehaviour
{
    private static MiniGame2Manager instance = null;

    private Card startCard = null;
    private EndCard endCard = null;
    private bool startCardClicked = false;
    private int answer = 0;
    
    [SerializeField]
    private GameObject proverbMenaingUI;
    [SerializeField]
    private TextMeshProUGUI proverbMeaningText;
    [SerializeField]
    private Button exitButton;
    [SerializeField] private string BackToScene;

    public GameObject EndPanel;
    public Animator pgAnim;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    public static MiniGame2Manager Instance
    {
        get
        {
            if (instance == null)
                return null;
            return instance;
        }
    }   

    public EndCard GetEndCard()
    {
        return endCard;
    }

    void EndGame()
    {
        IEnumerator ShowEndPanel()
        {
            yield return new WaitForSeconds(2.0f);
            EndPanel.SetActive(true);

        }
        StartCoroutine(ShowEndPanel());
    }

    public void StartCardClicked(Card card)
    {
        startCard = card;
        startCardClicked = true;
    }
    public void EndCardEnterd(EndCard card)
    {
        endCard = card;
       
    }
    public void EndCardExit()
    {
        endCard = null;

    }
    public bool CardMatchCheck()
    {

        if (endCard != null && (startCard.Get_ID() == endCard.Get_ID())) // 정답일 시에.
        {
            pgAnim.SetTrigger("Correct");
            proverbMeaningText.text = startCard.Get_Proverb();
            proverbMenaingUI.SetActive(true);

            answer += 1;

            if (answer == 3)
            {
                exitButton.GetComponent<Button>().onClick.AddListener(delegate
              {
                  EndGame();
              });
            }
            return true;
        }
        else
        {
            pgAnim.SetTrigger("Wrong");
            Destroy(startCard.Get_LINE());
            return false;
        }
    }

    public void EndGameButton()
    {
        DataManager.Instance().updataMiniGameData(2);
        SceneManager.LoadScene(BackToScene);
    }
}
