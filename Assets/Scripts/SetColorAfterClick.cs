using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetColorAfterClick : MonoBehaviour {
    /*Created and used only for testing of buttons*/
    bool pushed = false;

	public void ChangeColor() {
        if(pushed == false) {
            pushed = true;
            GetComponent<Image>().color = Color.red;
        }
        else {
            pushed = false;
            GetComponent<Image>().color = Color.white;
        }
        
    }

}
