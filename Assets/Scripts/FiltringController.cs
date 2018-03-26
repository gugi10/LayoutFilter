using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FiltringController : MonoBehaviour {

    int idToFind;
    bool flag;
    int numberOfButtonsPushed = 0;

    #region test

    bool f1Flag = false;
    bool f2Flag = false;
    bool f3Flag = false;
    bool f4Flag = false;
    bool f5Flag = false;

    private void Update() {
        if (Input.GetKeyDown(KeyCode.F1)) {
            if (f1Flag) {
                Debug.Log("Unpushed");
                f1Flag = false;
            }
            else {
                Debug.Log("Pushed");
                f1Flag = true;
            }
            Filter("Attribute1", f1Flag);
        }
        if (Input.GetKeyDown(KeyCode.F2)) {
            if (f2Flag) {
                Debug.Log("Unpushed");
                f2Flag = false;
            }
            else {
                Debug.Log("Pushed");
                f2Flag = true;
            }
            Filter("Attribute2", f2Flag);
        }
        if (Input.GetKeyDown(KeyCode.F3)) {
            if (f3Flag) {
                Debug.Log("Unpushed");
                f3Flag = false;
            }
            else {
                Debug.Log("Pushed");
                f3Flag = true;
            }
            Filter("Attribute3", f3Flag);
        }
        if (Input.GetKeyDown(KeyCode.F4)) {
            if (f4Flag) {
                Debug.Log("Unpushed");
                f4Flag = false;
            }
            else {
                Debug.Log("Pushed");
                f4Flag = true;
            }
            Filter("Attribute4", f4Flag);
        }
        if (Input.GetKeyDown(KeyCode.F5)) {
            if (f5Flag) {
                Debug.Log("Unpushed");
                f5Flag = false;
            }
            else {
                Debug.Log("Pushed");
                f5Flag = true;
            }
            Filter("Attribute5", f5Flag);
        }
    }
    #endregion

    public void Filter(string attributeName, bool flag) {
        this.flag = flag;
        if (this.flag) {
            numberOfButtonsPushed++;
        }
        else {
            numberOfButtonsPushed--;
        }
        AtributeIdToFind(attributeName);
        SetFlagsToAttributes();
        FilterElements();
    }

    void AtributeIdToFind(string attributeName) {
        AttributeSetter atrSetter = gameObject.GetComponent<AttributeSetter>();
        for(int i = 0; i<atrSetter.foundAttributeList.Count; i++) {
            if(attributeName == atrSetter.foundAttributeList[i]) {
                idToFind = i;
            }
        }
    }

    void SetFlagsToAttributes() {
        foreach(Transform element in transform) {
            int numberOfAttributesInElement = element.GetComponent<FilteredLayoutElement>().id.Count;
            for(int i = 0; i<numberOfAttributesInElement; i++) {
                if (ElementContainsAttributes(element)) {
                    if (FoundAttribute(element, i)){
                        element.GetComponent<FilteredLayoutElement>().attributesFlagList[i] = this.flag;
                    }
                }
            }
            element.GetComponent<FilteredLayoutElement>().elementFlagged = SetElementFlag(element);
        }

    }

    void FilterElements() {
        if(numberOfButtonsPushed != 0) {
            foreach (Transform element in transform) {
                Image tmpImage = element.GetComponent<Image>();
                Color alphaZero = tmpImage.color;
                if (!element.GetComponent<FilteredLayoutElement>().elementFlagged) {
                    HideElement(element);
                }
                else {
                    ShowElement(element);
                }
            }
        }
        else {
            ShowAllElements();
        }
        
    }

    void ShowElement(Transform element) {
        Image tmpImage = element.GetComponent<Image>();
        Color alphaZero = tmpImage.color;
        element.GetComponent<LayoutElement>().ignoreLayout = false;
        alphaZero.a = 1f;
        element.GetComponent<Image>().color = alphaZero;
    }

    void HideElement(Transform element) {
        Image tmpImage = element.GetComponent<Image>();
        Color alphaZero = tmpImage.color;
        element.GetComponent<LayoutElement>().ignoreLayout = true;
        alphaZero.a = 0f;
        element.GetComponent<Image>().color = alphaZero;

    }

    void ShowAllElements() {
        foreach(Transform element in transform) {
            Image tmpImage = element.GetComponent<Image>();
            Color alphaZero = tmpImage.color;
            element.GetComponent<LayoutElement>().ignoreLayout = false;
            alphaZero.a = 1f;
            element.GetComponent<Image>().color = alphaZero;
        }
    }

    bool SetElementFlag(Transform element) {
        //foreach (Transform attr in element) {
        //    if (attr.GetComponent<Attribute>().flag) {
        //        return true;
        //    }
        //}
        //return false;
        foreach(bool flag in element.GetComponent<FilteredLayoutElement>().attributesFlagList) {
            if (flag) {
                return true;
            }
        }
        return false;
    }

    bool FoundAttribute(Transform el, int i) {
        if (el.GetComponent<FilteredLayoutElement>().id[i] == idToFind) {
            return true;
        }
        else {
            return false;
        }
    }

    bool ElementContainsAttributes(Transform element) {
        if(element.GetComponent<FilteredLayoutElement>().id.Count == 0){
            return false;
        }
        else {
            return true;

        }
    }
}
