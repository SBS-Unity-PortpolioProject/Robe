
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
       
       			![게임 플레이 영상](https://github.com/user-attachments/assets/057a8416-fe92-4839-9c7b-e66785cabc56)
		+ 몬스터
			+ 걸어다니는 몬스터(플레이어가 공격O)
			+ 날아다니는 몬스터(플레이어가 공격X)
     
     			![게임 플레이 영상](https://github.com/user-attachments/assets/cd00d34e-c59a-4276-9b69-f4c02cb37ad9)

	+ UI
		+ 게임 클리어 조건에 따른 별표시
		+ 시작
		+ 게임 오버
		+ 체력바
		+ 시간
    
    		![게임 플레이 영상](https://github.com/user-attachments/assets/2c2f063c-9bbd-40f1-a26d-31a93f9680b5)
	+ 장애물
   		+ 점프패드
       		+ 떨어지는 장애물
           	+ 매달려 있는 장애물
           	  
          	![게임 플레이 영상](https://github.com/user-attachments/assets/c5639ee5-7640-4136-a054-82fec39cf3cd)
	+ 체력포션
   
   	![게임 플레이 영상](https://github.com/user-attachments/assets/04a9a05a-fdfc-4085-83b7-0d60ebf611d1)
+ **사용한 기술 및 알고리즘**
	+ 오브젝트 풀링
+ **어려웠던 점 및 해결 과정**
	+ 대쉬의 효과 표현
		+ 코루틴을 사용, 오브젝트 풀링을 사용
	+ 클리어 조건에 따른 UI 변화
		+ GameManager에서 UnityEvent를 이용하여 체력이 변화하였을때 작동되도록 함
---
### 4. 개발 과정에서 얻은 것
+ **배운 점**
	+ 유니티의 활용 및 C# 기술
	+ UI 생성 방법
+ **성장한 부분**
	+ C# 기술의 활용
	+ UI
+ **향후 보완할 점**
	+ 몬스터의 다양화
	+ 장애물 최적화
	+ 코드 최적화
	+ Script 정리
