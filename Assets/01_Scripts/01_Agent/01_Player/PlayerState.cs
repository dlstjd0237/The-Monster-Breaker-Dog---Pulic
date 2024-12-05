using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public int Lv { get; set; }
    public float MaxLevelParameters { get; set; }
    public float CurrentLevelParameters { get; set; }
    public float MaxHp { get; set; }
    public float CurrentHp { get; set; }

    private void OnEnable()
    {
        DataManager.Instance.LoadData();
        Lv = DataManager.Instance._nowPlayer.Level;
        MaxLevelParameters = DataManager.Instance._nowPlayer.MaxLevelParameters;
        CurrentLevelParameters = DataManager.Instance._nowPlayer.CurrentLevelParameters;
        MaxHp = DataManager.Instance._nowPlayer.MaxHp;
    }
    private void OnDestroy()
    {
        DataManager.Instance._nowPlayer.Level = Lv;
        DataManager.Instance._nowPlayer.MaxLevelParameters = MaxLevelParameters;
        DataManager.Instance._nowPlayer.CurrentLevelParameters = CurrentLevelParameters;
        DataManager.Instance.SaveData();
    }




}
