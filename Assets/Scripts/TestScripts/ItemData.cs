using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "item", menuName ="List of Items/Item")]
public class ItemData : ScriptableObject
{
    public string displayName;
    public string id;
    public string description;
}
