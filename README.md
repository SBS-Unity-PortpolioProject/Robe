![Robe_SBS 2025-02-15 오후 6_25_24](https://github.com/user-attachments/assets/92d6a44f-23fc-4a8c-9d78-bb72d9f7c2c5)
# SBS 김혜린 포트폴리오

---
### 1. 프로젝트 개요
+ **게임 제목** : Robe
+ **프로젝트 개발 기간** : 2025년 1월 4일 ~ 2025년 2월 15일(42시간)
+ **개발 인원** : 개인
+ **개발 역할** : 프로그래밍
+ **사용 엔진 및 툴** : Unity
+ **사용 언어** : C#
+ **플랫폼** : PC
---
### 2. 게임 소개
+ **게임 장르** : 2D 플랫포머
+ **게임 핵심 특징** : 다양한 움직임이 가능한 플레이어(더블 점프, 대쉬)
+ **게임 플레이 방식** : 장애물과 몬스터를 피해 체력을 최대로 유지하며 시간내로 문에 도달하는 게임
+ **게임 주요 시스템** : 2단 점프, 대쉬, 클리어 조건에 따른 별의 감소 및 증가
  ![게임 플레이 영상](https://github.com/user-attachments/assets/f5c22017-e38b-433f-a1b5-26d2795c2f3a)

---
### 3. 본인이 담당한 역할 및 기여도
+ **개발한 기능/시스템**
	+ 캐릭터
   		+ 플레이어
			+ 더블 점프
			+ 대쉬
       
       			![플레이어](https://github.com/user-attachments/assets/057a8416-fe92-4839-9c7b-e66785cabc56)
		+ 몬스터
			+ 걸어다니는 몬스터(플레이어가 공격O)
			+ 날아다니는 몬스터(플레이어가 공격X)
     
     			![몬스터](https://github.com/user-attachments/assets/cd00d34e-c59a-4276-9b69-f4c02cb37ad9)

	+ UI
		+ 시작
    		+ 게임 클리어 조건에 따른 별표시
		+ 체력바
		+ 시간
  		+ 게임 오버
    		![시작](https://github.com/user-attachments/assets/432bc7c2-99e0-439d-86d4-4bd44587f06c)
		![시간/별/체력바](https://github.com/user-attachments/assets/84923ad6-4eee-4e06-8c64-b1fad4cc90f9)
		![플레이 사진](https://github.com/user-attachments/assets/3e7d5103-5239-4d21-b897-d07964c09090)
		![게임 오버](https://github.com/user-attachments/assets/571dcf16-9b50-4134-ba03-55ac1b6c4bfa)

	+ 장애물
   		+ 점프패드
       		+ 매달려 있는 장애물
           	+ 떨어지는 장애물
          	![점프패드](https://github.com/user-attachments/assets/ffb8ff81-2a2d-4fa5-b35f-afc78c056e2e)
		![매달려 있는 장애물](https://github.com/user-attachments/assets/ec3c035c-3f2d-414f-9069-915de4371846)
		![떨어지는 장애물](https://github.com/user-attachments/assets/82b40185-4226-4730-8d2d-7b88d5a41185)

          	
	+ 체력포션
   
   	![게임 플레이 영상](https://github.com/user-attachments/assets/04a9a05a-fdfc-4085-83b7-0d60ebf611d1)
+ **사용한 기술 및 알고리즘**
	+ 오브젝트 풀링 : 대쉬의 효과를 오브젝트 풀링을 이용하여 구현하였다.
+ **어려웠던 점 및 해결 과정**
	+ 대쉬의 효과 표현 : PlayerController에서만 코루틴을 이용해 Dash를 사용하고, 효과를 그저 하얀 띠가 나오도록 구현하였으나 후에 플레이어의 잔상이 보이도록 구현하고 싶어 DashEffect라는 Script를 만들어 오브젝트 풀링을 이용해 뒤에 gameobject를 생성하고 플레이어의 sprite를 gameobject에 넣어 잔상을 표현했다. 이 과정에서 오브젝트 풀링을 이용하는데 어려움이 있었다. 그리고 PlayerController에서 또다른 코루틴을 입력해 DashEffect를 불러와 잔상을 생성했다.
	+ 클리어 조건에 따른 UI 변화 : 클리어 조건에 따라 별의 sprite를 변경하려 시도를 했으나 순서대로 꺼지길 바라 List를 이용하여 index에 따라 꺼지도록 입력했다. 그러나 조건의 의해 꺼지는 것이 1개가 아니라 List에 있는 모든 것이 꺼져버려 Damageable에 있는 이벤트를 이용해 한번만 꺼지도록 구현하려 했다. 그러나 별이 꺼지도록하는 Script인 Timer가 Damageable과 한 오브젝트에서 있을시 여러 오류가 나기 때문에(Timer에 체력이 생김등) 이벤트를 GameManager에서 관리하게 해 체력이 변할때마다 호출하여 별이 전부 꺼지는 것을 막았다.
---
### 4. 개발 과정에서 얻은 것
+ **배운 점**
	+ 유니티의 활용 및 C# 기술
	+ UI 생성 방법 : UI 이미지, 버튼등 sprite를 넣어 만들 수 있는 기술들의 생성 및 사이즈 조절 방법을 배웠다.
+ **성장한 부분**
	+ C# 기술의 활용 : 오브젝트 풀링, 코루틴등을 사용하며 C#기술들이 어디에서 사용해야 할지에 대해 더 잘 생각하게 되었다.
	+ UI : UI의 생성, UI기술의 이해도가 올라갔다.
+ **향후 보완할 점**
	+ 몬스터 다양화 : 몬스터를 더 다양하게 만들길 바랐다(원거리...)
	+ 장애물의 정리 : 구역을 나누어도 같은 장애물이 많아 Hierarchy에서 보기 힘들었다
	+ 코드 최적화
	+ Script 정리 : Script가 너무 많아 어디에서 사용해야 될지 몰라 중복되게 코드를 입력한 적이 있다.-> 파일등을 이용해 어디에 사용하는지를 정리하고 싶다
