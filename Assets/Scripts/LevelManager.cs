using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    /// <summary>
    /// quick commands: CTRL + K + D, CTRL + K + C, CTRL + K + V, CTRL + H, CTRL + K + S, CTRL + ".", CTRL + TAB.
    /// 
    /// the sumary is create using /// above any function.
    /// 
    /// remember: Random with int 0, 6 set values between 0 at 5 / Random with float 0, 6 set values between 0 at 6.
    /// </summary>

    #region DEFAULT STATUS
    private Sprite[] sprItem;
    private Sprite[] sprCanvasBox;
    private GameObject[] imgBox;
    private GameObject[] imgItem = new GameObject[4];
    private GameObject[] imgItemBox = new GameObject[44];
    [Header("Game Object Panels")] public GameObject[] panel;
    [Header("Game Object Buttons")] public GameObject[] button;
    [Header("Game Object UI Texts")] public GameObject[] ui;
    private int k; // random image box
    private int j; // image item
    private bool pause, win, check_text; // check conditions
    public static int r; // random itens box
    public static int c = 44; // count total item
    private float time; // time games
    private int n; // random number for change index inside sprite boxs.
    private int[] index = new int[4]; // index item 

    void Start()
    {
        index = new int[4]; // set new int array index
        win = false; // win condition false
        Time.timeScale = 1; // set time on

        // load sprites
        sprItem = Resources.LoadAll<Sprite>("Sprites/Item");
        sprCanvasBox = Resources.LoadAll<Sprite>("Sprites/Canvas");
        imgBox = GameObject.FindGameObjectsWithTag("BoxItem");

        #region CHANGE SPRITES OF ITEM
        r = Random.Range(0, 6); // total item 24
        //Debug.Log("Random: " + r);

        ui[4].GetComponent<Text>().text = "" + r;

        if (r == 0) // 0 1 2 3
        {
            j = 0;
        }
        if (r == 1) // 4 5 6 7 
        {
            j = 4;
        }
        if (r == 2) // 8 9 10 11
        {
            j = 8;
        }
        if (r == 3) // 12 13 14 15
        {
            j = 12;
        }
        if (r == 4) // 16 17 18 19
        {
            j = 16;
        }
        if (r == 5) // 20 21 22 23
        {
            j = 20;
        }

        // insert 4 items
        for (int i = 0; i < 4; i++)
        {
            imgBox[i].GetComponent<Image>().sprite = sprCanvasBox[i];
            imgItem[i] = GameObject.FindGameObjectWithTag("Item" + i);
            imgItem[i].GetComponent<Image>().sprite = sprItem[j];
            index[i] = j;
            j++;
        }

        // insert 44 boxs
        for (int b = 0; b < 44; b++)
        {
            n = Random.Range(0, 4);
            imgItemBox[b] = GameObject.Find("Box" + b);
            imgItemBox[b].GetComponent<Image>().sprite = sprItem[index[n]];
        }
        #endregion

        #region CHANGE IMAGES OF BOX ITEM
        k = Random.Range(0, 6);
        for (int i = 0; i < 4; i++)
        {
            imgBox[i].GetComponent<Image>().sprite = sprCanvasBox[k];
        }
        #endregion

        #region CHECK SPRITE NAMES
        // check sprite name of items
        for (int i = 0; i < 4; i++)
        {
            //Debug.Log("Sprite Name Item"+i+": "+imgItem[i].GetComponent<Image>().sprite.name);
        }

        // check sprite name of boxs
        for (int b = 0; b < 44; b++)
        {
            //Debug.Log("Sprite Name Box" + b + ": " + imgItemBox[b].GetComponent<Image>().sprite.name);
        } 
        #endregion

        #region SET TIME GAME
        time = Random.Range(0, 2);

        if (time == 0)
        {
            time = 90;
        }
        else
        {
            time = (time * 60) * 2;
        }
        #endregion
    }

    void Update()
    {
        ui[3].GetComponent<Text>().text = "" + c;

        // check winner
        if (c == 0)
        {
            win = true;
        }

        #region CHECK PAUSE GAME
        // pause on
        if (Input.GetKeyDown(KeyCode.Return) && pause == false)
        {
            panel[0].SetActive(true);
            Time.timeScale = 0;
            pause = !pause;
        }
        // pause of
        else if (Input.GetKeyDown(KeyCode.Return) && pause == true)
        {
            panel[0].SetActive(false);
            Time.timeScale = 1;
            pause = !pause;
        }
        #endregion

        #region CHECK TIME GAME
        time -= Time.deltaTime; // countdown game 
        ui[0].GetComponent<Text>().text = "" + Mathf.Round(time);

        if (time < 0)
        {
            panel[0].SetActive(true);
            Time.timeScale = 0;
            ui[1].GetComponent<Text>().text = "game over";
        }
        else
        {
            if (check_text)
            {
                ui[1].GetComponent<Text>().text = "settings";
            }
            else
            {
                ui[1].GetComponent<Text>().text = "pause";
            }
            if (win == true)
            {
                panel[0].SetActive(true);
                Time.timeScale = 0;
                ui[1].GetComponent<Text>().text = "winner";
                ui[2].GetComponent<Text>().text = "menu";
            }
        }
        #endregion
    }
    #endregion

    #region UI MANAGER
    // buttons retry and menu
    public void ButtonAction()
    {
        #region CLICK MODE
        if (win == false)
        {
            // retry - reload scene
            Scene game = SceneManager.GetActiveScene();
            SceneManager.LoadScene(game.buildIndex);
        }
        else
        {
            SceneManager.LoadScene(0); // back to menu
        }
        #endregion
    }

    public void SelectSettings(bool check)
    {
        // panel settings off
        if (check)
        {
            check_text = check;
            panel[1].SetActive(check);
            for (int i = 0; i < 2; i++)
            {
                // buttons on
                button[i].SetActive(!check);
            }
        }
        // panel settings on
        else
        {
            check_text = check;
            panel[1].SetActive(check);
            for (int i = 0; i < 2; i++)
            {
                // buttons off
                button[i].SetActive(!check);
            }
        }
    }
    #endregion 
}