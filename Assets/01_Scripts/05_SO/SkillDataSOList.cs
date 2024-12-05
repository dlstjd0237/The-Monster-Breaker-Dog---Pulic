using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/SkillDataSOList")]

public class SkillDataSOList : ScriptableObject
{
    public List<SkillDataSO> SkillSOList;
}
