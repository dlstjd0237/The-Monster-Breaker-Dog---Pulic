using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PlayerAttack : MonoBehaviour
{
    private PlayerAnimationControl _playerAnimtion;
    private PlayerMovement _playerMovement;
    private PlayerState _playerState;
    private bool _attacking;


    [SerializeField]
    private GameObject _slash1Effect;
    private List<GameObject> _slashEffect1List = new List<GameObject>();
    private int _slash1Count = 0;

    [SerializeField]
    private GameObject _slash2Effect;
    private List<GameObject> _slashEffect2List = new List<GameObject>();
    private int _slash2Count = 0;


    private Vector3 _slashPos;
    private Quaternion _slashRot1;
    private void Awake()
    {
        _playerState = GameObject.Find("Player").GetComponent<PlayerState>();
        _playerMovement = GetComponent<PlayerMovement>();
        _playerAnimtion = GetComponent<PlayerAnimationControl>();
        _slashPos = new Vector3(0.443f, 0.491f, 0);
        _slashRot1 = Quaternion.Euler(90, 180, 90);

        for (int i = 0; i < 20; ++i)
        {
            var qwer = Instantiate(_slash1Effect, transform);
            _slashEffect1List.Add(qwer);
            _slashEffect1List[i].SetActive(false);
            _slashEffect1List[i].transform.localScale = EffectScaleSet();
        }
        for (int i = 0; i < 20; ++i)
        {
            var qwer = Instantiate(_slash2Effect, transform);
            _slashEffect2List.Add(qwer);
            _slashEffect2List[i].SetActive(false);
            _slashEffect2List[i].transform.localScale = EffectScaleSet();
        }
    }

    public void Attack()
    {
        //if (_attacking == false)

        //    AttackEvent?.Invoke();
        PoolManager.SpawnFromPool("PlayerAttackSound", transform.position);
        _playerMovement.ReSetDostance();
        _playerAnimtion.Stop();
        _playerAnimtion.AttackOn();

    }
    public void OnSlash1()
    {

        _slashEffect1List[_slash1Count].SetActive(true);
        _slashEffect1List[_slash1Count].transform.localPosition = _slashPos;
        _slashEffect1List[_slash1Count].transform.localRotation = _slashRot1;

        _slash1Count++;
        if (_slash1Count > _slashEffect1List.Count - 1)
            _slash1Count = 0;
    }
    public void OnSlash2()
    {

        _slashEffect2List[_slash2Count].SetActive(true);
        _slashEffect2List[_slash2Count].transform.localPosition = _slashPos;
        _slashEffect2List[_slash2Count].transform.localRotation = _slashRot1;

        _slash2Count++;
        if (_slash2Count > _slashEffect2List.Count - 1)
            _slash2Count = 0;
    }



    private Vector3 EffectScaleSet()
    {
        if (DataManager.Instance._nowPlayer.Level >= 1 && _playerState.Lv <= 8)
        {
            return new Vector3(0.3f, 0.3f, 0.3f);
        }
        else if (DataManager.Instance._nowPlayer.Level >= 9 && _playerState.Lv <= 16)
        {
            return new Vector3(0.33f, 0.33f, 0.33f);
        }
        else if (DataManager.Instance._nowPlayer.Level >= 17 && _playerState.Lv <= 23)
        {
            return new Vector3(0.36f, 0.36f, 0.36f);
        }
        else
        {
            return new Vector3(0.4f, 0.4f, 0.4f);
        }

    }


}