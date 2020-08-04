using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f; // 탄알 이동 속력
    private Rigidbody bulletRigidbody; // 이동에 사용할 리지드바디 컴포넌트

    void Start()
    {//게입 옵젝에서 rigidbody 컴포넌트 찾아 bulletrigidbody에 할당
        bulletRigidbody = GetComponent<Rigidbody>();
        //리지드바디의 속도 = 앞쪽 방향 * 이동 속력
        bulletRigidbody.velocity = transform.forward * speed;

        //3초 뒤에 자신의 게임 오브젝트 파괴
        Destroy(gameObject, 3f);
    }
    private void OnTriggerEnter(Collider other)
    {//충돌한 상대방 게임 오브젝트가 player 태그를 가진경우
        if (other.tag == "Player")
        {
            //상대방 게임 오브젝트에서 playerController 컴포넌트 가져오기
            PlayerController playerController = other.GetComponent<PlayerController>();

            //상대방으로부터 PlyaerControloer 컴포넌트를 가져오는데 성공 했다면
            if(playerController != null)
            {
                //상대방 playerController 컴포넌트의 Die() 메서드 실행
                playerController.Die();
            }
        }
    }
}
