using UnityEngine;
using UnityEngine.UI;

public class ItemManager : MonoBehaviour
{
    #region DEFAULT STATUS
    public bool drag;
    public static bool check_Box, destroy_Item;
    private Vector3 pos;
    public static string name_Item;
    private GameObject prefab_Item;
    private Image image_Item;

    void Start()
    {
        drag = false;
        check_Box = false;
        destroy_Item = false;
        pos = gameObject.transform.position;

        if (gameObject.tag == "Item0")
        {
            prefab_Item = Resources.Load<GameObject>("Prefabs/Item/prefab_Item0");
        }
        if (gameObject.tag == "Item1")
        {
            prefab_Item = Resources.Load<GameObject>("Prefabs/Item/prefab_Item1");
        }
        if (gameObject.tag == "Item2")
        {
            prefab_Item = Resources.Load<GameObject>("Prefabs/Item/prefab_Item2");
        }
        if (gameObject.tag == "Item3")
        {
            prefab_Item = Resources.Load<GameObject>("Prefabs/Item/prefab_Item3");
        }

        image_Item = GetComponent<Image>();
    }
    #endregion

    #region COLLISIONS
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Box")
        {
            //Debug.Log(" Imagem " + collision.collider.gameObject.GetComponent<Image>().sprite.name + " colidiu com box ");

            name_Item = collision.collider.gameObject.GetComponent<Image>().sprite.name;

            if (name_Item == BoxManager.name_Item_Box)
            {
                //Debug.Log(" Imagem Igual! ");
                check_Box = true;
            }
            else
            {
                //Debug.Log(" Imagem Diferente! ");
                check_Box = false;
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Box")
        {
            check_Box = false;
        }
    }
    #endregion

    #region TRIGGERS
    public void ItemSelect(int i)
    {
        if (i == 0) // begin drag
        {
            drag = true;
        }
        if (i == 1) // drag
        {
            // check time on - move item
            if (Time.timeScale == 1)
            {
                transform.position = Input.mousePosition;

                if (check_Box == true)
                {
                    LevelManager.c--;
                    destroy_Item = true;
                    Destroy(gameObject);
                    check_Box = false;

                    if (destroy_Item == true)
                    {
                        // create a new item
                        GameObject item_Clone = Instantiate(prefab_Item, pos, Quaternion.identity) as GameObject;
                        item_Clone.name = gameObject.name;
                        item_Clone.transform.SetParent(transform.parent);
                        item_Clone.transform.position = pos;
                        item_Clone.GetComponent<Image>().sprite = image_Item.sprite;
                        item_Clone.GetComponent<Image>().enabled = true;
                        item_Clone.GetComponent<ItemManager>().enabled = true;
                        item_Clone.GetComponent<BoxCollider2D>().enabled = true;
                        item_Clone.GetComponent<ItemManager>().drag = false;
                        check_Box = false;
                        destroy_Item = false;
                        pos = gameObject.transform.position;
                    }
                }
                else
                {
                    destroy_Item = false;
                }
            }
        }
        if (i == 2) // pointer up
        {
            if (check_Box == false)
            {
                // item back to orinal position
                gameObject.transform.position = pos;
            }
            drag = false;
        }
    }
    #endregion
}