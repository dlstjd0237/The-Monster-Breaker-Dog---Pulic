using UnityEngine;
using UnityEngine.Events;
public class IdleState : State
{
    [SerializeField] private float _fieldOfView;
    [SerializeField] private UnityEvent<float, float, float> BossCameraaOffSet;
    public ChaseState _chaseState;
    public bool CanSeeThePlayer;
    [SerializeField] private GameObject _player;
    [SerializeField] private GameObject _boss;


    public override State RunCurrentState()
    {

        NoFindPlayer();

        if (CanSeeThePlayer)
        {
            BossCameraaOffSet?.Invoke(-5, 11, 9);
            return _chaseState;
        }
        else
        {
            return this;
        }
    }
    private void NoFindPlayer()
    {
        if (Vector3.Distance(_player.transform.position, _boss.transform.position) >= 25)
            return;

        Vector3 playerToEnemy = _player.transform.position - _boss.transform.position;
        playerToEnemy.Normalize();

        // player의 전방 벡터를 정규화합니다.
        Vector3 playerForward = _boss.transform.forward.normalized;

        // player에서 enemy로 가는 벡터와 player의 정규화된 전방 벡터의 내적을 계산합니다.
        float dotProduct = Vector3.Dot(playerForward, playerToEnemy);

        // 아크 코사인(acos)을 사용하여 라디안 단위의 각도로 변환합니다.
        float angle = Mathf.Acos(dotProduct) * Mathf.Rad2Deg;

        // 계산된 각도가 시야각 범위 내에 있는지 확인
        if (angle < _fieldOfView * 0.5f)
        {
            Debug.Log("와 안되냐");
            CanSeeThePlayer = true;
        }

    }

}
