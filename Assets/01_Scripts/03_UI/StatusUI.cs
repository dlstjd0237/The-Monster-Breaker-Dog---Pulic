using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class StatusUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _lvText;
    [SerializeField] private TextMeshProUGUI _hpText;
    [SerializeField] private TextMeshProUGUI _attackPowerText;
    [SerializeField] private TextMeshProUGUI _parryingText;
    [SerializeField] private TextMeshProUGUI _coinText;
    [SerializeField] private TextMeshProUGUI _attackSpeedText;

    private void FixedUpdate()
    {
        _lvText.SetText(DataManager.Instance._nowPlayer.Level.ToString());
        _hpText.SetText($"{DataManager.Instance._nowPlayer.CurrentHp}/{DataManager.Instance._nowPlayer.MaxHp}");
        _attackPowerText.SetText($"{DataManager.Instance._nowPlayer.AttackPower+DataManager.Instance._nowPlayer.WeaponPower}");
        _parryingText.SetText($"{DataManager.Instance._nowPlayer.DefensePercentage+DataManager.Instance._nowPlayer.ShieldPower}%");
        _coinText.SetText($"{DataManager.Instance._nowPlayer.Coin}");
        _attackSpeedText.SetText(DataManager.Instance._nowPlayer.AttackSpeed.ToString());
    }

}
