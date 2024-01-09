using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class coin : MonoBehaviour
{
    public Text coinTxt;
    public int coins;
    public int totalCoinsToCollect = 15;

    void Start()
    {
        PlayerPrefs.SetInt("coins", 0);

        coins = PlayerPrefs.GetInt("coins");
        coinTxt.text = coins.ToString();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "coin")
        {
            coins++;
            PlayerPrefs.SetInt("coins", coins);
            coinTxt.text = coins.ToString();
            Destroy(other.gameObject);

            if (coins >= totalCoinsToCollect)
            {
                SceneManager.LoadScene("Menu");
            }
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
