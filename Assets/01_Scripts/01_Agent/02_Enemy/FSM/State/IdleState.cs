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

        // player�� ���� ���͸� ����ȭ�մϴ�.
        Vector3 playerForward = _boss.transform.forward.normalized;

        // player���� enemy�� ���� ���Ϳ� player�� ����ȭ�� ���� ������ ������ ����մϴ�.
        float dotProduct = Vector3.Dot(playerForward, playerToEnemy);

        // ��ũ �ڻ���(acos)�� ����Ͽ� ���� ������ ������ ��ȯ�մϴ�.
        float angle = Mathf.Acos(dotProduct) * Mathf.Rad2Deg;

        // ���� ������ �þ߰� ���� ���� �ִ��� Ȯ��
        if (angle < _fieldOfView * 0.5f)
        {
            Debug.Log("�� �ȵǳ�");
            CanSeeThePlayer = true;
        }

    }

}
