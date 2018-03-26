using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FilteredLayoutElement : MonoBehaviour {

    [Tooltip("Id's in the list are in order with respect to attributes at the element, used to avoid string comparison")]
    [HideInInspector]
    public List<int> id;
    [HideInInspector]
    public bool elementFlagged = false;
    [HideInInspector]
    public List<bool> attributesFlagList;
    [Tooltip("List of attributes by which element will be filtered")]
    public List<string> attributeList;
}
