using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class EnemyHealthbar : MonoBehaviour
{
    private Image _healthbar;
    private TextMeshProUGUI _lvText;
    private Enemy _enemy;
    private Transform _parent;
    private Camera _mainCam;
    private void OnEnable()
    {
        _mainCam = Camera.main;
        _healthbar = transform.Find("HpBar").GetComponent<Image>();
        _lvText = transform.Find("LvText").GetComponent<TextMeshProUGUI>();
    }
    private void Awake()
    {

        _parent = transform.parent.parent;

        _enemy = _parent.GetComponent<Enemy>();

    }
    private void Start()
    {
        _lvText.SetText($"Lv{_enemy.Lv} {_enemy.ShowName}");
    }
    private void FixedUpdate()
    {
        if (_mainCam == null)
            gameObject.SetActive(false);
        transform.LookAt(_mainCam.transform);
    }

    public void UpdateHealthbar(float value)
    {
        _healthbar.fillAmount = value;

    }

}


