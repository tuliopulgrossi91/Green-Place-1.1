using UnityEngine;

public class AnimManager : MonoBehaviour
{
    private Animator anim_Button;

    void Start()
    {
        // get animator component of button
        anim_Button = GetComponent<Animator>();
    }

    public void SelectButton(bool check)
    {
        // check = false
        if (check)
        {
            // set animator by buttonCheck true
            anim_Button.SetBool("buttonCheck", true);
        }
        // check = true
        else
        {
            // set animator by buttonCheck false
            anim_Button.SetBool("buttonCheck", false);
        }
    }
}