using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coin : MonoBehaviour
{
    private GameObject player;

    RectTransform rcTrans;
    [SerializeField] Text CoinText;

    private void Awake()
    {
        this.GetComponent<RectTransform>().SetParent(GameObject.Find("Canvas").GetComponent<RectTransform>(), false);
    }

    // Start is called before the first frame update
    void Start()
    {
        CoinText = GetComponent<Text>();
        rcTrans = GetComponent<RectTransform>();
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        int iCoin = player.GetComponent<Player>().GetCoin();
        if (iCoin >= 0)
            CoinText.text = iCoin.ToString();
        else
            CoinText.text = iCoin.ToString();
    }
}
