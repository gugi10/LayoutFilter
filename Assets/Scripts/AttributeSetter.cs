using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributeSetter : MonoBehaviour {

    List<string> attributeNamesList;
    public List<string> foundAttributeList;
    

    void Start() {
        foundAttributeList = new List<string>();
        CreateListOfAttributes();
        InitFlags();
    }

    void CreateListOfAttributes() {
        int idCount = 0;
        foreach (Transform child in transform) {
            int numberOfAttributesAtElement = child.GetComponent<FilteredLayoutElement>().attributeList.Count;
            for(int i = 0; i<numberOfAttributesAtElement; i++) {
                CheckIfAttributeInList(child.GetComponent<FilteredLayoutElement>().attributeList[i], ref idCount, child);
            }
        }
    }
    
    void CheckIfAttributeInList(string attribute, ref int index, Transform element) {
        Debug.Log(attribute);
        if (index == 0) {
            element.GetComponent<FilteredLayoutElement>().id.Add(index);
            foundAttributeList.Add(attribute);
            index++;
                
        }
        else {
            bool isInTheList = false;
            for (int i = 0; i < foundAttributeList.Count; i++) {
                if (foundAttributeList[i] == attribute) {
                    isInTheList = true;
                }
            }
            if (!isInTheList) {
                SetAttributeId(element, attribute);
                foundAttributeList.Add(attribute);
            }
            else {
                for(int i = 0; i<foundAttributeList.Count; i++) {
                    if(attribute == foundAttributeList[i]) {
                        SetAttributeId(element, attribute);
                    }
                }
            }
        }
    }

    void SetAttributeId(Transform element, string attribute) {
        bool found = false;
        for (int i = 0; i < foundAttributeList.Count; i++) {
            if (attribute == foundAttributeList[i]) {
                element.GetComponent<FilteredLayoutElement>().id.Add(i);
                found = true;
            }
        }
        if (!found) {
            Debug.Log("New id: "+foundAttributeList.Count);
            element.GetComponent<FilteredLayoutElement>().id.Add(foundAttributeList.Count);
        }
    }

    void InitFlags() {
        foreach(Transform element in transform) {
            int amountOfAttributes = element.GetComponent<FilteredLayoutElement>().id.Count;
            for(int i = 0; i<amountOfAttributes; i++) {
                element.GetComponent<FilteredLayoutElement>().attributesFlagList.Add(false);
            }
        }
    }
}
