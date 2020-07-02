using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TotalCoin : MonoBehaviour
{
    private GameObject player;

    RectTransform rcTrans;
    [SerializeField] Text TotalcoinText;

    private int m_iTotalCoin;
    [SerializeField] public int m_iScore = 0;

    public Star star;
    public Star starClone;

    private void Awake()
    {
        this.GetComponent<RectTransform>().SetParent(GameObject.Find("Canvas").GetComponent<RectTransform>(), false);
    }

    // Start is called before the first frame update
    void Start()
    {
        SetTotalCoinText();

        starClone = Instantiate(star);
        starClone.vUIPos = new Vector3(Screen.width * 0.399f, Screen.height * 0.63f, 0f);
        if (100 < m_iTotalCoin && m_iTotalCoin <= 200)
        {
            starClone = Instantiate(star);
            starClone.vUIPos = new Vector3(Screen.width * 0.5f, Screen.height * 0.4f, 0f);
        }
        else if (200 < m_iTotalCoin)
        {
            starClone = Instantiate(star);
            starClone.vUIPos = new Vector3(Screen.width * 0.5f, Screen.height * 0.63f, 0f);
            starClone = Instantiate(star);
            starClone.vUIPos = new Vector3(Screen.width * 0.602f, Screen.height * 0.63f, 0f);
        }
    }

    private void SetTotalCoinText()
    {
        TotalcoinText = GetComponent<Text>();
        rcTrans = GetComponent<RectTransform>();
        player = GameObject.FindWithTag("Player");
        m_iTotalCoin = player.GetComponent<Player>().GetCoin();
        TotalcoinText.text = m_iTotalCoin.ToString();
    }

    // Update is called once per frame
    void Update()
    {
    }
}