using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ns_predefine;

public class ItemsRefer : Singleton<ItemsRefer>  {
	public Dictionary<int, string> _Items;
	private ModelEnum _TBase;
	private ItemsRefer () {
		_Items = new Dictionary<int, string> ();
		initrefer ();
	}

	public void initrefer(){
		/*_Items.Add (100,"ObjItems/effects/swordfirm/blood");
		_Items.Add (100,"ObjItems/effects/swordfirm/clean");
		_Items.Add (100,"ObjItems/effects/swordfirm/evil");
		_Items.Add (100,"ObjItems/effects/swordfirm/ice");
		_Items.Add (100,"ObjItems/effects/swordfirm/rainbow");*/
		_Items.Add (1,"UIFrame/BloodBar");
		_Items.Add (2,"ObjItems/Chest2");
		_Items.Add (3,"UIFrame/UIItemDrop");
		_Items.Add (4,"UIFrame/UISkill");

		_Items.Add (100,"ObjItems/effects/swordfirm/base");
		_Items.Add (120,"ObjItems/effects/swordfirm/evil");
		_Items.Add (140,"ObjItems/effects/swordfirm/blood");
		_Items.Add (160,"ObjItems/effects/shield");
		_Items.Add (180,"ObjItems/effects/pentagramritual");

		_Items.Add (105,"ObjItems/effects/iceball");
		_Items.Add (125,"ObjItems/effects/fireball");
		_Items.Add (145,"ObjItems/effects/lighting");
		_Items.Add (165,"ObjItems/effects/whirlwindBase");
		_Items.Add (185,"ObjItems/effects/lightingexp");

		_Items.Add (110,"ObjItems/effects/swordfirm/evil");
		_Items.Add (130,"ObjItems/effects/swordfirm/base");
		_Items.Add (150,"ObjItems/effects/swordfirm/blood");
		_Items.Add (170,"ObjItems/effects/whirlwindBase");
		_Items.Add (190,"ObjItems/effects/groundimpack");

		_Items.Add (1107,"ObjItems/Equips/Weapons/Axe 01");
		_Items.Add (1112,"ObjItems/Equips/Weapons/Axe 02 Blue");
		_Items.Add (1111,"ObjItems/Equips/Weapons/Axe 03 Purple");
		_Items.Add (1108,"ObjItems/Equips/Weapons/Hammer 01");
		_Items.Add (1110,"ObjItems/Equips/Weapons/Hammer 02");
		_Items.Add (1109,"ObjItems/Equips/Weapons/Hammer 03");
		_Items.Add (1101,"ObjItems/Equips/Weapons/Scythe 01");
		_Items.Add (1117,"ObjItems/Equips/Weapons/Scythe 02");
		_Items.Add (1116,"ObjItems/Equips/Weapons/Scythe 03");
		_Items.Add (1106,"ObjItems/Equips/Weapons/Sword 01");
		_Items.Add (1118,"ObjItems/Equips/Weapons/Sword 02");
		_Items.Add (1113,"ObjItems/Equips/Weapons/Sword 03");
		_Items.Add (1105,"ObjItems/Equips/Weapons/Sword 04");
		_Items.Add (1121,"ObjItems/Equips/Weapons/Sword 05");
		_Items.Add (1119,"ObjItems/Equips/Weapons/Sword 06");
		_Items.Add (1120,"ObjItems/Equips/Weapons/Sword 08");
		_Items.Add (1122,"ObjItems/Equips/Weapons/Sword 09");
		_Items.Add (1114,"ObjItems/Equips/Weapons/Sword 10");
		_Items.Add (1123,"ObjItems/Equips/Weapons/TH Sword 01");
		_Items.Add (1124,"ObjItems/Equips/Weapons/TH Sword 02");
		_Items.Add (1125,"ObjItems/Equips/Weapons/TH Sword 03");
		_Items.Add (1131,"ObjItems/Equips/Weapons/Wand 02 Red 1");
		_Items.Add (1126,"ObjItems/Equips/Weapons/Wand 03 Green 1");
		_Items.Add (1130,"ObjItems/Equips/Weapons/Wand 04 White 1");
		_Items.Add (1129,"ObjItems/Equips/Weapons/Wand 05 Red 1");
		_Items.Add (1127,"ObjItems/Equips/Weapons/Wand 06 Broom Purple 1");
		_Items.Add (1134,"ObjItems/Equips/Weapons/Wand 07 Red 1");
		_Items.Add (1128,"ObjItems/Equips/Weapons/Wand 08 White 1");
		_Items.Add (1133,"ObjItems/Equips/Weapons/Wand 09 Magenta 1");
		_Items.Add (1132,"ObjItems/Equips/Weapons/Wand 10 Red 1");
		_Items.Add (1104,"ObjItems/Equips/Weapons/Spear 01 Red 1");
		_Items.Add (1115,"ObjItems/Equips/Weapons/Spear 02 Yellow 1");
		_Items.Add (1100,"ObjItems/Equips/Weapons/Peasant Tool 02 Hammer 1");
		_Items.Add (1103,"ObjItems/Equips/Weapons/Peasant Tool 03 Axe 1");
		_Items.Add (1102,"ObjItems/Equips/Weapons/Peasant Tool 04 Scyth 1");
		_Items.Add (1209,"ObjItems/Equips/Weapons/Longbow 02 Purple");
		_Items.Add (1210,"ObjItems/Equips/Weapons/Longbow 01 Purple");
		_Items.Add (1211,"ObjItems/Equips/Weapons/Longbow 03 Purple");


		_Items.Add (1805,"ObjItems/Equips/Wings/Wings 02 Dragon Red");
		_Items.Add (1804,"ObjItems/Equips/Wings/Wings 03 Bone Red");
		_Items.Add (1800,"ObjItems/Equips/Wings/Wings 04 Dragonfly Purple");
		_Items.Add (1806,"ObjItems/Equips/Wings/Wings 05 Butterfly RainBow");
		_Items.Add (1801,"ObjItems/Equips/Wings/Wings 06 Leaves Green Yellow");
		_Items.Add (1802,"ObjItems/Equips/Wings/Wings 07 Love Pink");
		_Items.Add (1807,"ObjItems/Equips/Wings/Wings 08 Magenta");
		_Items.Add (1808,"ObjItems/Equips/Wings/Wings 09 Red");
		_Items.Add (1803,"ObjItems/Equips/Wings/Wings 10 Red Yellow");
		_Items.Add (1809,"ObjItems/Equips/Wings/Wings 11 Blue");
		_Items.Add (1813,"ObjItems/Equips/Wings/Wings 11 Green");
		_Items.Add (1811,"ObjItems/Equips/Wings/Wings 11 Red");
		_Items.Add (1812,"ObjItems/Equips/Wings/Wings 11 Purple");
		_Items.Add (1810,"ObjItems/Equips/Wings/Wings 11 Yellow");

		_Items.Add (2301,"ObjItems/Enemies/ToonDragon/Toon Dragon-Purple");
		_Items.Add (2302,"ObjItems/Enemies/ToonDragon/Toon Dragon-Red");
		_Items.Add (2303,"ObjItems/Enemies/ToonDragon/Toon Dragon-Green");

		_Items.Add (2311,"ObjItems/Enemies/ToonDragon/Toon Dragon-Purple");
		_Items.Add (2312,"ObjItems/Enemies/ToonDragon/Toon Dragon-Red");
		_Items.Add (2313,"ObjItems/Enemies/ToonDragon/Toon Dragon-Green");

		_Items.Add (2321,"ObjItems/Enemies/ToonRock/Toon Rock Golem-Blue");
		_Items.Add (2322,"ObjItems/Enemies/ToonRock/Toon Rock Golem-Green");
		_Items.Add (2323,"ObjItems/Enemies/ToonRock/Toon Rock Golem-Red");

		_Items.Add (2331,"ObjItems/Enemies/ToonCactus/Toon Cactus Monster-Magenta");
		_Items.Add (2332,"ObjItems/Enemies/ToonCactus/Toon Cactus Monster-Orange");
		_Items.Add (2333,"ObjItems/Enemies/ToonCactus/Toon Cactus Monster-Purple");

		_Items.Add (2341,"ObjItems/Enemies/ToonPlant/Toon Plant Monster-Pink");
		_Items.Add (2342,"ObjItems/Enemies/ToonPlant/Toon Plant Monster-Purple");
		_Items.Add (2343,"ObjItems/Enemies/ToonPlant/Toon Plant Monster-Red");

		_Items.Add (2351,"ObjItems/Enemies/ToonGhost/Toon Ghost-Blue");
		_Items.Add (2352,"ObjItems/Enemies/ToonGhost/Toon Ghost-Green");
		_Items.Add (2353,"ObjItems/Enemies/ToonGhost/Toon Ghost-Orange");

		_Items.Add (2361,"ObjItems/Enemies/ToonDeathKnight/Toon Death Knight-Blue");
		_Items.Add (2362,"ObjItems/Enemies/ToonDeathKnight/Toon Death Knight-Green");
		_Items.Add (2363,"ObjItems/Enemies/ToonDeathKnight/Toon Death Knight-Orange");

		_Items.Add (2371,"ObjItems/Enemies/ToonBat/Toon Bat-Green");
		_Items.Add (2372,"ObjItems/Enemies/ToonBat/Toon Bat-Pink");
		_Items.Add (2373,"ObjItems/Enemies/ToonBat/Toon Bat-Red");

		_Items.Add (2381,"ObjItems/Enemies/ToonSKKnight/Toon Skeleton Knight-Blue");
		_Items.Add (2382,"ObjItems/Enemies/ToonSKKnight/Toon Skeleton Knight-Green");
		_Items.Add (2383,"ObjItems/Enemies/ToonSKKnight/Toon Skeleton Knight-Red");

		_Items.Add (2391,"ObjItems/Enemies/ToonSKMage/Toon Skeleton Mage-Blue");
		_Items.Add (2392,"ObjItems/Enemies/ToonSKMage/Toon Skeleton Mage-Purple");
		_Items.Add (2393,"ObjItems/Enemies/ToonSKMage/Toon Skeleton Mage-Red");

		_Items.Add (2401,"ObjItems/Enemies/ToonSKArcher/Toon Skeleton Archer-Blue");
		_Items.Add (2402,"ObjItems/Enemies/ToonSKArcher/Toon Skeleton Archer-Green");
		_Items.Add (2403,"ObjItems/Enemies/ToonSKArcher/Toon Skeleton Archer-Red");

		_Items.Add (4000,"MapItems/00_Plain/Map/Plain02_4");
	}
}
