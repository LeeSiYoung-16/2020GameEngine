using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class CoinPlus2 : MonoBehaviour
{
    RectTransform rcTrans;
    private GameObject player;
    private GameObject timeOut;

    private float fDeadTime = 1.2f;

    private GameObject recipe;
    private GameObject recipeIcon;

    [SerializeField] Text coinPlusText;
    [SerializeField] public bool m_bIsDead = false;
    [SerializeField] public Vector3 vUIPos;

    private void Awake()
    {
        vUIPos = new Vector3(Screen.width * 0.5f, Screen.height, 0f);
        this.GetComponent<RectTransform>().SetParent(GameObject.Find("Canvas").GetComponent<RectTransform>(), false);
    }

    // Start is called before the first frame update
    void Start()
    {
        rcTrans = GetComponent<RectTransform>();
        timeOut = GameObject.FindWithTag("Timer");
        player = GameObject.FindWithTag("Player");
        recipe = GameObject.FindWithTag("Recipe");
        recipeIcon = GameObject.FindWithTag("RecipeIcon");
        coinPlusText = GetComponent<Text>();

        List<PrawnRecipe> recipeListTmp = timeOut.GetComponent<TimeOut2>().GetRecipeList();
        vUIPos = recipeListTmp[0].vUIPos;

        recipeIcon.GetComponent<PrawnRecipeIcon>().m_bIsClear = true;
        recipe.GetComponent<PrawnRecipe>().m_bIsClear = true;
        if (recipeListTmp != null)
            recipeListTmp.RemoveAt(0);
    }

    // Update is called once per frame
    void Update()
    {
        SetCoinPlusText();
        vUIPos.y -= 50f * Time.deltaTime;
        this.rcTrans.position = vUIPos;
    }

    private void SetCoinPlusText()
    {
        int iPlusCoin = player.GetComponent<Player>().GetPlusCoin();

        if (iPlusCoin > 0)
            coinPlusText.text = "+" + iPlusCoin.ToString();
        else
            coinPlusText.text = iPlusCoin.ToString();
    }

    void LateUpdate()
    {
        if (m_bIsDead)
            Destroy(this.gameObject);

        StartCoroutine(DeadCoinPlus());
    }

    IEnumerator DeadCoinPlus()
    {
        if (!m_bIsDead)
        {
            yield return new WaitForSeconds(fDeadTime);
            m_bIsDead = true;
        }
    }
}
