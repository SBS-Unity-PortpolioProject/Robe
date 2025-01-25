using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class BombSpawn : MonoBehaviour
{
    [SerializeField]private GameObject _Bomb;
    Bomb _bomb;
    Bomb bomb => _bomb ??= _Bomb.GetComponent<Bomb>();
   
    private int i = 0;

    private void Start()
    {
        Invoke("Spawn", 1f);
    }

    void Spawn()
    {
        if (i < 5)
        {
            Instantiate(_Bomb, transform.position, Quaternion.identity);
            bomb.Fire();
            Invoke("Spawn", 2f);
            i++;
        }
        else
        {
            Destroy(gameObject);
        }

        // �ڽİ����� �ִ� �͵��� List�� ���� �� �ϳ��� SetActive(true)�Ѵ� -> invoke or for
        // �� instantiate�� ��� X

    }

}
