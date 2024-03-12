using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int time_start;
    [SerializeField] TextMeshProUGUI time;
    public bool isGameOver;
    public bool isGameWinner;
    public bool doneLV1;
    public GameObject title;
    public GameObject winner;
    private bool isGameOverHandled;
    // Start is called before the first frame update
    void Start()
    {
        isGameOver = false;
        isGameWinner = false;
        doneLV1 = false;
        time_start = 45;
        time.text = "00 : " + time_start;
        StartCoroutine(countTime());
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameOverHandled)
        {
            GameOver();
        }
        if (!isGameOverHandled)
        {
            GameWinner();
        }
    }

    IEnumerator countTime()
    {
        while (!isGameOver)
        {
            yield return new WaitForSeconds(1f);
            time_start -= 1;
            time.text = "00 : " + time_start;
        }
        
    }
    public void GameOver()
    {
        if (time_start <= 0)
        {
            isGameOver = true;
            isGameOverHandled = true; // Đánh dấu rằng đã xử lý game over

            title.SetActive(true);
        }
    }
    public void GameWinner()
    {
        if (time_start > 0 && isGameWinner == true)
        {
            isGameOver = true;
            PlayerPrefs.SetInt("donelv1", doneLV1 ? 1 : 0);
            isGameOverHandled = true; // Đánh dấu rằng đã xử lý game over
            winner.SetActive(true);
        }
    }
}
