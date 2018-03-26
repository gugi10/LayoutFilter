using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttributeToFind : MonoBehaviour {

    [Tooltip("Name of the attribute")]
    [SerializeField]
    string attributeToFind;
    [Tooltip("Set reference to layout you want to filter")]
    [SerializeField]
    FiltringController layout;
    bool buttonFlag = false;

    private void Awake() {
        Init();
    }

    void Init() {
        Button btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
    }
    void TaskOnClick() {
        gameObject.GetComponent<SetColorAfterClick>().ChangeColor();
        Find();
    }

    void Find() {
        if (!buttonFlag) {
            buttonFlag = true;
        }
        else {
            buttonFlag = false;
        }
        layout.Filter(attributeToFind, buttonFlag);
    }
}
