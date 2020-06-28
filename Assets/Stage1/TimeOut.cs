using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeOut : MonoBehaviour
{
    private float fSceneTime = 60f;
    private float fRecipeAddTime = 0f;

    private float fsecTime = 60f;
    private int iminTime = 0;

    public Recipe recipe;
    public Recipe recipeClone;
    private List<Recipe> RecipeList = new List<Recipe>();
 
    [SerializeField]
    Text TimerText;

    // Start is called before the first frame update
    void Start()
    {
        TimerText = GetComponent<Text>();
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

        if (fRecipeAddTime >= 6f)
        {
            fRecipeAddTime = 0f;
            RecipeList.Add(recipeClone = Instantiate(recipe));
        }

        for (int i = 0; i < RecipeList.Count; i++)
        {
            if (i == 0)
                RecipeList[0].fAddRecipeX = 45f;
            else
                RecipeList[i].fAddRecipeX = 45f + (i * 90f);
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
        for (int i = 0; i < RecipeList.Count; i++)
        {
            if (RecipeList[i].m_bIsDead)
                RecipeList.RemoveAt(i);
        }

        StartCoroutine(NextScene());
    }

    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(fSceneTime);
        Application.LoadLevel("Stage2");
    }

}
