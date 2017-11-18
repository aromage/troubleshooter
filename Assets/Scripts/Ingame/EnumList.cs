using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public enum Attribute // 속성
{
    EMPTY,
    FIRE,
    AQUA,
    NATURE,
    LIGHT,
    DARK
}

public enum BulletMove //발사 불렛 타입
{
    NOT_DEFINED,
    STRAIGHT,
    HOMING,
    ENEMY_STRAIGHT,
    ENEMY_HOMING,
    STRAIGHT_2
}


public enum BulletPhase
{
    LIVE,
    HIT,
    MISS
}

public enum HitType // 타격 타입
{
    NORMAL, //일반
    PIERCE, //관통
    BOOMING, //스플래시
    GUARD //총알 상쇄
}

public enum MoverPhase
{
    INTRO,//인트로
    ONSCREEN,//오브젝트 Enable
    STOP,// 정지?
    DISAPPEAR,//오브젝트 Disable
    DESTROY//오브젝트 파괴
}

public enum Position
{
    FIRST, //0
    SECOND, //1
    THIRD //2
}

public enum Enemy
{
    Eye_F,    //No_F,
    Eye_A,      //No_W   
    Eye_N,      //No_L
    Bat_F,//Re_F,
    Bat_A,//Re_W,
    Bat_N,//Re_L,
    Wall1_F, //Wal_F_1,
    Wall2_F, //wal_F_2
    Wall1_A, //Wal_W_1,
    Wall2_A, //Wal_W_2,
    Wall1_N, //Wal_L_1,
    Wall2_N,//Wal_L_2
    Shooter_F,
    Shooter_A,
    Shooter_N,
    Cloud1,
    Cloud2,
    Gonyak_F,
    Gonyak_A,
    Bird_F,
    Bird_A,
    Bird_N,
    BirdR_F,
    BirdR_A,
    BirdR_N,
    BirdL_F,
    BirdL_A,
    BirdL_N,
    BirdChain_F,
    BirdChain_A,
    BirdChain_N,
    ChampBird_F,
    ChampBird_A,
    ChampBird_N,
    ChampBat_F,
    ChampBat_A,
    ChampBat_N,
    ChampShooter_F,
    ChampShooter_A,
    ChampShooter_N
}

public enum State
{
    NONE,           // 없음
	Rage, 			// 분노
	Fury, 			// 격분
	Haste, 			// 가속
	ShieldUp, 		// 실드 업
	Decrease,	 	// 격감
	Weak, 			// 쇠약
	Lazy, 			// 나태
	Slow, 			// 느림
	ArmorBreak, 	// 아머 브레이크
	Silence, 		// 침묵
	Frozen, 		// 빙결
	WeaponBreak, 	// 웨폰 브레이크
	Stun, 			// 기절
	Poison, 		// 독
	Shock,		 	// 감전
    Amplification 	// 증폭  //17
}