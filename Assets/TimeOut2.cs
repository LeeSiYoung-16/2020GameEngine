using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeOut2 : MonoBehaviour
{
    private float fSceneTime = 90f;
    private float fRecipeAddTime = 7f;

    private float fsecTime = 30f;
    private int iminTime = 1;

    public PrawnRecipe recipe;
    public PrawnRecipe recipeClone;
    private List<PrawnRecipe> RecipeList = new List<PrawnRecipe>();
    private GameObject player;

    public List<PrawnRecipe> GetRecipeList()
    {
        return RecipeList;
    }

    [SerializeField] Text TimerText;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        TimerText = GetComponent<Text>();
        player.transform.position = new Vector3(0f, -0.05f, 6.5f);
    }

    // Update is called once per frame
    void Update()
    {
        Show_TimerTextUI();
        Add_Recipe();
    }

    private void Add_Recipe()
    {
        fRecipeAddTime += Time.deltaTime;

        if (fRecipeAddTime >= 7f)
        {
            fRecipeAddTime = 0f;
            RecipeList.Add(recipeClone = Instantiate(recipe));
        }

        for (int i = 0; i < RecipeList.Count; i++)
        {
            if (i == 0)
                RecipeList[0].fAddRecipeX = RecipeList[i].myWidth - 10f;
            else
                RecipeList[i].fAddRecipeX = (i * RecipeList[i].myWidth) + ((i + 1) * (RecipeList[i].myWidth - 10f));
        }
    }

    private void Show_TimerTextUI()
    {
        if (fsecTime != 0)
        {
            fsecTime -= Time.deltaTime;
            if (fsecTime <= 0)
            {
                fsecTime = 60;
                if (iminTime > 0)
                    iminTime--;
                else
                    iminTime = 0;
            }
        }
        int sec = Mathf.FloorToInt(fsecTime);

        if (sec >= 10)
            TimerText.text = "0" + iminTime.ToString() + ":" + sec.ToString();
        else
            TimerText.text = "0" + iminTime.ToString() + ":" + "0" + sec.ToString();
    }

    void LateUpdate()
    {
        StartCoroutine(NextScene());

        // 다음스테이지로 바로 넘어가기.
        if (Input.GetKey(KeyCode.RightShift))
            Application.LoadLevel("GameEnd");
    }

    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(fSceneTime);
        Application.LoadLevel("GameEnd");
    }
}
