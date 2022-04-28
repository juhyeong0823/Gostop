using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StopUI : MonoBehaviour
{
    public Text victoryOfDefeatText;
    public Text moneyText;

    public void PaulkWin()
    {
        moneyText.text = string.Empty;
        gameObject.SetActive(true);
        if (GameManager.Instance.isUserTurn)
        {
            victoryOfDefeatText.text = "誌尻散 渋軒!";
        }
        else
        {
            victoryOfDefeatText.text = "誌尻散 鳶壕..";
        }
    }

    public void OnStop(bool isPresident = false, bool isNagari = false)
    {
        moneyText.text = string.Empty;

        gameObject.SetActive(true);
        if (isNagari)
        {
            victoryOfDefeatText.text = "蟹亜軒, 康壱 希鷺稽!";
            GameManager.Instance.sc.nagariCount++;
        }
        else if(!isPresident)
        {
            if (GameManager.Instance.isUserTurn)
            {
                victoryOfDefeatText.text = "渋軒!";
                moneyText.text = $"+ {GameManager.Instance.sc.GetCalculatedScore()}据";
            }
            else
            {
                victoryOfDefeatText.text = "鳶壕..";
                moneyText.text = $"- {GameManager.Instance.sc.GetCalculatedScore()}据";
            }
        }
        else
        {
            Debug.Log("ぞししぞしけししけいし");
            if (GameManager.Instance.isUserTurn)
            {
                victoryOfDefeatText.text = "恥搭 渋軒!";
                moneyText.text = $"+ {GameManager.Instance.sc.GetPresidentMoney()}据";
            }
            else
            {
                victoryOfDefeatText.text = "恥搭 鳶壕..";
                moneyText.text = $"- {GameManager.Instance.sc.GetPresidentMoney()}据";
            }
        }
        
    }

    public Button reStart;

    private void Start()
    {
        reStart.onClick.AddListener(() =>
        {
            GameManager.Instance.ReLoad();
        });
    }
}
