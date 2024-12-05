using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/DialogueDataSO")]

public class DialogueData : ScriptableObject
{
    [SerializeField] private List<string> infoList; public List<string> InfoList { get { return infoList; } }
}
