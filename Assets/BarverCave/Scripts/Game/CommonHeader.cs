using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ns_predefine
{
	public delegate void itemdelegate(Items p);
	public delegate void AnimEventHandler(ModelEnum _ev);
	public delegate void RoleEventHandler(Role _role,bool _found);

	public enum ModelEnum
	{
		_UnKnown,

		//role action state
		Action = 1,
		Idle,
		Run,
		Die,
		Lock,

		ActionAttack = 19,
		Atk_Normal_0,		//
		Atk_Normal_1,		//
		Atk_Normal_2,		//
		Atk_Normal_3,		//
		Atk_Skill_0,		//
		Atk_Skill_1,		//
		Atk_Skill_2,		//
		Atk_Skill_3,		//
		Atk_Skill_4,		//
		Atk_Skill_5,		//
		Atk_Skill_6,		//
		Atk_Skill_7,		//
		AttackEnd = 100,

		//Quality
		Qual_White = 110,		//white
		Qual_Green,				//green
		Qual_Blue,				//Blue
		Qual_Purple,			//Purple
		Qual_Golen,				//Golen
		Qual_DarkGolen,			//Orange

		//role
		WP_ROLE = 130,
		WP_THS,			//双手剑
		WP_STAFF,		//法杖
		WP_SHS,			//单手剑、斧
		WP_SPEAR,		//长矛
		WP_BOW,			//弓箭
		WP_CROSSBOW,	//弓弩

		AEV_ENTER,
		AEV_EFFECT,
		AEV_DAMAGE,
		AEV_EXIT,

		Food = 500,
		HPFood = 550,
		MAXHPFood = 600,
		MPFood = 650,
		MAXMPFood = 700,
		DEFFood = 750,
		DPSFood = 800,
		LVFood = 850,
		SPDFood = 900,
		FoodEnd = 950,

		Equip = 1000,
		EqWeapon = 1100,		//主武器
		EqSubWeapon = 1200,		//副武器
		EqHats = 1300,			//帽子
		EqArmor = 1400,			//护甲
		EqGloves = 1500,		//手套
		EqPants = 1600,			//裤子
		EqBoots = 1700,			//靴子
		EqWings = 1800,			//翅膀
		EqNeckLace = 1900,		//项链
		EqBraceLet = 2000,		//手镯
		EqJade = 2100,			//玉佩

		EquipEnd = 2200,

		Enemy_Dragon=2300,
		Enemy_Dragon_Ice,
		Enemy_Dragon_Fire,
		Enemy_Dragon_Poison,

		Enemy_Dragon_Fly=2310,
		Enemy_Dragon_Fly_Ice,
		Enemy_Dragon_Fly_Fire,
		Enemy_Dragon_Fly_Poison,

		Enemy_Rock=2320,
		Enemy_Rock_Blue,
		Enemy_Rock_Green,
		Enemy_Rock_Red,

		Enemy_Cactus=2330,
		Enemy_Cactus_Magenat,
		Enemy_Cactus_Oragne,
		Enemy_Cactus_Purple,

		Enemy_Plant=2340,
		Enemy_Plant_Pink,
		Enemy_Plant_Purple,
		Enemy_Plant_Red,

		Enemy_Ghost=2350,
		Enemy_Ghost_Blue,
		Enemy_Ghost_Green,
		Enemy_Ghost_Orange,

		Enemy_DeadKnight=2360,
		Enemy_DeadKnight_Blue,
		Enemy_DeadKnight_Green,
		Enemy_DeadKnight_Red,

		Enemy_Bat=2370,
		Enemy_Bat_Green,
		Enemy_Bat_Pink,
		Enemy_Bat_Red,

		Enemy_SKKnight=2380,
		Enemy_SKKnight_Blue,
		Enemy_SKKnight_Green,
		Enemy_SKKnight_Purple,

		Enemy_SKMage=2390,
		Enemy_SKMage_Blue,
		Enemy_SKMage_Green,
		Enemy_SKMage_Red,

		Enemy_SKArcher=2400,
		Enemy_SKArcher_Blue,
		Enemy_SKArcher_Purple,
		Enemy_SKArcher_Red,
	}

	public enum PARENT_PANEL{
		EQSOLT,
		INVENTORY,
		DROP,
		SHOP,
		SKILL,
	}

	public class PreHeader{
		public static int PROPMAX = 4;
		public static string[] PROPTStr = {"*攻击","*防御","*金币","*经验" };
		public static Dictionary<ModelEnum,string> COLORStr = new Dictionary<ModelEnum, string>(){
			{ModelEnum.Qual_Blue,"<color=#75B1CD>"},
			{ModelEnum.Qual_Purple,"<color=#956A9F>"},
			{ModelEnum.Qual_Golen,"<color=#E1B03A>"},
			{ModelEnum.Qual_DarkGolen,"<color=#E27D39>"}
		};
	}
	public class TBCMsg{
		public ModelEnum _Type{ get; set;}
		public float _fValue{ get; set;}
		public string _SValue{ get; set;}
		public TBCMsg()
		{
			_Type = ModelEnum._UnKnown;
			_fValue = 0;
			_SValue = "";
		}
	}
}
