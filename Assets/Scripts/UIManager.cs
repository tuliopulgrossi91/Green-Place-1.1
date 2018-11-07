using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region DEFAULT STATES
    /// <summary>
    /// Game Object Arrays 
    /// objects0 - level
    /// objects1 - confirm
    /// objects2 - infos
    /// objects3 - settings
    /// objects4 - panel
    /// objects5 - panel text
    /// objects6 - text back
    /// objects7 - text confirm
    /// </summary>

    [Header("Game Object Arrays")] public GameObject[] objects;
    private readonly string[] painel_Title = new string[4] { "Level Select", "Settings", "Credits", "Exit?" };
    private string[] credits = { "programmer " + "\n" + " by tulio pulgrossi", "sfx by chiptone", "background " + "\n" + " by tulio pulgrossi", "font and sprites" + "\n" + "by kenney", "Music by Eric Matyas" + "\n" + "www.soundimage.org" };
    private bool check; 
    #endregion

    #region UI MANAGER
    // i is a index panel
    public void PanelManager(int i)
    {
        // button back = 0
        #region CLICK MODE
        // check false
        if (check == false)
        {
            // panel true
            check = true;
            objects[4].SetActive(check);
            CancelInvoke("Texts");
        }
        else
        {
            // panel false
            check = false;
            objects[4].SetActive(check);
        }
        #endregion

        #region SELECT MODE
        if (i >= 0)
        {
            Debug.Log(i);
            // show title index panel title
            objects[5].GetComponent<Text>().text = "" + painel_Title[i];
            objects[6].GetComponent<Text>().text = "back";

            // level
            if (i == 0)
            {
                objects[0].SetActive(check);
                objects[3].SetActive(!check);
                objects[2].SetActive(!check);
                objects[1].SetActive(!check);
            }
            // settings
            if (i == 1)
            {
                objects[0].SetActive(!check);
                objects[3].SetActive(check);
                objects[2].SetActive(!check);
                objects[1].SetActive(!check);
            }
            // credits
            if (i == 2)
            {
                objects[0].SetActive(!check);
                objects[3].SetActive(!check);
                objects[2].SetActive(check);
                objects[1].SetActive(!check);
                InvokeRepeating("Texts", 0.5f, 3f); // INFO CREDITS
            }
            // exit
            if (i == 3)
            {
                objects[0].SetActive(!check);
                objects[3].SetActive(!check);
                objects[2].SetActive(!check);
                objects[1].SetActive(check);
                objects[7].GetComponent<Text>().text = "yes";
                objects[6].GetComponent<Text>().text = "no";
            }
        }
        #endregion
    }

    public void SelectManager(int j)
    {
        if (j == 0)
        {
            // load scene
            SceneManager.LoadSceneAsync(1);
        }
        if (j == 1)
        {
            // confirm exit
            Application.Quit();
        }
    }

    void Texts()
    {
        objects[2].GetComponent<Text>().text = "" + credits[Random.Range(0, 5)];
    } 
    #endregion
}