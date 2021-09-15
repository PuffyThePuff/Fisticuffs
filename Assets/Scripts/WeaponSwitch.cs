using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSwitch : MonoBehaviour
{
    public SwipeDetector swipeControls;
    public int weaponType = 0;

    private bool switched = false;

    [SerializeField] Sprite paperIcon;
    [SerializeField] Sprite rockIcon;
    [SerializeField] Sprite scissorIcon;

    private void switchIcon(int type)
    {
        if (type == 0)
        {
            this.gameObject.GetComponent<Image>().sprite = paperIcon;
        }
        if (type == 1)
        {
            this.gameObject.GetComponent<Image>().sprite = rockIcon;
        }
        if (type == 2)
        {
            this.gameObject.GetComponent<Image>().sprite = scissorIcon;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (swipeControls.swipeLeft && !switched)
        {
            weaponType--;
            if (weaponType == -1)
            {
                weaponType = 2;
            }
            switchIcon(weaponType);
            switched = true;
        }
        else if (swipeControls.swipeRight && !switched)
        {
            weaponType++;
            if (weaponType == 3)
            {
                weaponType = 0;
            }
            switchIcon(weaponType);
            switched = true;
        }
        else if (!swipeControls.swipeLeft && !swipeControls.swipeRight)
        {
            switched = false;
        }
    }
}
