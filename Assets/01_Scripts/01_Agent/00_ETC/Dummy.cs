using UnityEngine;

public class Dummy : MonoBehaviour
{

    private readonly int _isAttack = Animator.StringToHash("IsAttack");


    [SerializeField]
    private Animator _animator;


    public void TakeDameg(float _damge)
    {
       GameObject qwer =  PoolManager.SpawnFromPool("DamageText", new Vector3(transform.position.x+Random.Range(-1f,1),transform.position.y,transform.position.z+Random.Range(-1f,1f)),Quaternion.Euler(50,147,0));
        qwer.GetComponent<DamegText>().Show(_damge);
        _animator.SetTrigger(_isAttack);
    }



}
