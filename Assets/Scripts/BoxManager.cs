using UnityEngine;
using UnityEngine.UI;

public class BoxManager : MonoBehaviour
{
    #region DEFAULT STATUS
    public bool check_Item;
    public static string name_Item_Box;
    private Collider2D col_Box;
    private Rigidbody2D rb_Box;
    private RectTransform pos_Box;

    void Start()
    {
        col_Box = GetComponent<Collider2D>();
        rb_Box = GetComponent<Rigidbody2D>();
        pos_Box = GetComponent<RectTransform>();
    }

    void Update()
    {
        if (pos_Box.localPosition.y <= -600f)
        {
            Debug.Log("Item Box saiu!");
            Destroy(gameObject);
        }
    }
    #endregion

    #region COLLISIONS
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Item0" || collision.collider.tag == "Item1" || collision.collider.tag == "Item2" || collision.collider.tag == "Item3")
        {
            // name item box receive the sprite name of item
            name_Item_Box = collision.collider.gameObject.GetComponent<Image>().sprite.name;

            // if name item box = name item
            if (name_Item_Box == ItemManager.name_Item)
            {
                col_Box.enabled = false;
                rb_Box.constraints = RigidbodyConstraints2D.None;
                ItemManager.check_Box = true;
            }
            else
            {
                col_Box.enabled = true;
                rb_Box.constraints = RigidbodyConstraints2D.FreezeAll;
                ItemManager.check_Box = false;
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Item0" || collision.collider.tag == "Item1" || collision.collider.tag == "Item2" || collision.collider.tag == "Item3")
        {
            name_Item_Box = "";
        }
    }
    #endregion
}