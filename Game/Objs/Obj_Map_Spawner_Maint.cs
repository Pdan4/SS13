// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Map_Spawner_Maint : Obj_Map_Spawner {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.amount = 2;
			this.chance = 50;
			this.toSpawn = new ByTable(new object [] { 
				typeof(Obj_Item_Device_Assembly_Igniter), 
				typeof(Obj_Item_Device_Assembly_Infra), 
				typeof(Obj_Item_Device_Assembly_Mousetrap), 
				typeof(Obj_Item_Device_Assembly_ProxSensor), 
				typeof(Obj_Item_Device_Assembly_Signaler), 
				typeof(Obj_Item_Device_Assembly_Timer), 
				typeof(Obj_Item_Device_Assembly_Voice), 
				typeof(Obj_Item_Weapon_Storage_Belt_Utility), 
				typeof(Obj_Item_Device_Multitool), 
				typeof(Obj_Item_Device_Paicard), 
				typeof(Obj_Item_Device_Flashlight), 
				typeof(Obj_Item_Device_Flashlight_Lantern), 
				typeof(Obj_Item_Device_Flashlight_Flare), 
				typeof(Obj_Item_Weapon_Weldingtool_Largetank), 
				typeof(Obj_Item_Device_Gps), 
				typeof(Obj_Item_Device_Gps_Science), 
				typeof(Obj_Item_Device_Gps_Engineering), 
				typeof(Obj_Item_Weapon_Cell_Super), 
				typeof(Obj_Item_Weapon_Soap_Nanotrasen), 
				typeof(Obj_Item_Device_Flash), 
				typeof(Obj_Item_Device_TransferValve), 
				typeof(Obj_Item_Device_CameraBug), 
				typeof(Obj_Item_Device_Handtv), 
				typeof(Obj_Item_Device_Camera), 
				typeof(Obj_Item_Device_CameraFilm), 
				typeof(Obj_Item_Device_Encryptionkey), 
				typeof(Obj_Item_Device_Encryptionkey), 
				typeof(Obj_Item_Device_Encryptionkey), 
				typeof(Obj_Item_Device_Encryptionkey_Syndicate), 
				typeof(Obj_Item_Device_Encryptionkey_Binary), 
				typeof(Obj_Item_Device_Encryptionkey_Syndicate_Hacked), 
				typeof(Obj_Item_Device_Hailer), 
				typeof(Obj_Item_Device_Healthanalyzer), 
				typeof(Obj_Item_Device_MassSpectrometer), 
				typeof(Obj_Item_Device_Megaphone), 
				typeof(Obj_Item_Device_Mmi_RadioEnabled), 
				typeof(Obj_Item_Device_Powersink), 
				typeof(Obj_Item_Device_ReagentScanner), 
				typeof(Obj_Item_Device_Soundsynth), 
				typeof(Obj_Item_Latexballon), 
				typeof(Obj_Item_Weapon_Storage_Toolbox_Electrical), 
				typeof(Obj_Item_AmmoStorage_Magazine_A12mm), 
				typeof(Obj_Item_AmmoStorage_Box_C45), 
				typeof(Obj_Item_AmmoStorage_Box_A418), 
				typeof(Obj_Item_AmmoStorage_Magazine_A75), 
				typeof(Obj_Item_AmmoStorage_Speedloader_C38), 
				typeof(Obj_Item_AmmoStorage_Box_C9mm), 
				typeof(Obj_Item_AmmoStorage_Magazine_Mc9mm), 
				typeof(Obj_Item_Bodybag), 
				typeof(Obj_Item_Clothing_Ears_Earmuffs), 
				typeof(Obj_Item_Clothing_Glasses_Eyepatch), 
				typeof(Obj_Item_Clothing_Glasses_Regular), 
				typeof(Obj_Item_Clothing_Glasses_Regular_Hipster), 
				typeof(Obj_Item_Clothing_Glasses_Sunglasses_Blindfold), 
				typeof(Obj_Item_Clothing_Glasses_Sunglasses_Prescription), 
				typeof(Obj_Item_Clothing_Glasses_Welding), 
				typeof(Obj_Item_Clothing_Gloves_Brown), 
				typeof(Obj_Item_Clothing_Gloves_Latex), 
				typeof(Obj_Item_Clothing_Gloves_Black), 
				typeof(Obj_Item_Clothing_Gloves_Fyellow), 
				typeof(Obj_Item_Clothing_Gloves_Purple), 
				typeof(Obj_Item_Clothing_Head_Beret), 
				typeof(Obj_Item_Clothing_Head_Cakehat), 
				typeof(Obj_Item_Clothing_Head_Cardborg), 
				typeof(Obj_Item_Clothing_Head_Chicken), 
				typeof(Obj_Item_Clothing_Head_Collectable_Flatcap), 
				typeof(Obj_Item_Clothing_Head_Collectable_Pirate), 
				typeof(Obj_Item_Clothing_Head_Collectable_Wizard), 
				typeof(Obj_Item_Clothing_Head_Collectable_Tophat), 
				typeof(Obj_Item_Clothing_Head_NunHood), 
				typeof(Obj_Item_Clothing_Head_Plaguedoctorhat), 
				typeof(Obj_Item_Clothing_Head_Soft_Grey), 
				typeof(Obj_Item_Clothing_Head_Surgery_Blue), 
				typeof(Obj_Item_Clothing_Head_Welding), 
				typeof(Obj_Item_Clothing_Mask_Cigarette), 
				typeof(Obj_Item_Clothing_Shoes_Laceup), 
				typeof(Obj_Item_Clothing_Glasses_Welding_Superior), 
				typeof(Obj_Item_Clothing_Glasses_Sunglasses_Sechud), 
				typeof(Obj_Item_Clothing_Glasses_Meson), 
				typeof(Obj_Item_Clothing_Gloves_Yellow), 
				typeof(Obj_Item_Clothing_Gloves_Knuckles), 
				typeof(Obj_Item_Clothing_Gloves_Knuckles_Spiked), 
				typeof(Obj_Item_Clothing_Head_BombHood), 
				typeof(Obj_Item_Clothing_Mask_Gas), 
				typeof(Obj_Item_Clothing_Mask_Gas_Monkeymask), 
				typeof(Obj_Item_Clothing_Mask_Gas_OwlMask), 
				typeof(Obj_Item_Clothing_Mask_Gas_Plaguedoctor), 
				typeof(Obj_Item_Clothing_Mask_Gas_Sexyclown), 
				typeof(Obj_Item_Clothing_Mask_Muzzle), 
				typeof(Obj_Item_Clothing_Mask_Pig), 
				typeof(Obj_Item_Clothing_Mask_Horsehead), 
				typeof(Obj_Item_Clothing_Shoes_Sandal), 
				typeof(Obj_Item_Clothing_Suit_BioSuit), 
				typeof(Obj_Item_Clothing_Suit_BioSuit_Plaguedoctorsuit), 
				typeof(Obj_Item_Clothing_Suit_BombSuit), 
				typeof(Obj_Item_Clothing_Suit_Fire_Firefighter), 
				typeof(Obj_Item_Clothing_Suit_Monkeysuit), 
				typeof(Obj_Item_Clothing_Suit_Pirate), 
				typeof(Obj_Item_Clothing_Suit_Radiation), 
				typeof(Obj_Item_Clothing_Suit_Redtag), 
				typeof(Obj_Item_Clothing_Suit_Storage_FrJacket), 
				typeof(Obj_Item_Clothing_Suit_Storage_Hazardvest), 
				typeof(Obj_Item_Clothing_Suit_Storage_Lawyer_Purpjacket), 
				typeof(Obj_Item_Clothing_Suit_Storage_Paramedic), 
				typeof(Obj_Item_Clothing_Suit_Suspenders), 
				typeof(Obj_Item_Clothing_Suit_Syndicatefake), 
				typeof(Obj_Item_Clothing_Suit_Unathi_Mantle), 
				typeof(Obj_Item_Clothing_Suit_Unathi_Robe), 
				typeof(Obj_Item_Clothing_Accessory_Tie_Horrible), 
				typeof(Obj_Item_Clothing_Accessory_Armband_Cargo), 
				typeof(Obj_Item_Clothing_Accessory_Armband), 
				typeof(Obj_Item_Clothing_Accessory_Armband_Engine), 
				typeof(Obj_Item_Clothing_Accessory_Armband_Hydro), 
				typeof(Obj_Item_Clothing_Accessory_Holster_Armpit), 
				typeof(Obj_Item_Clothing_Under_Blackskirt), 
				typeof(Obj_Item_Clothing_Mask_Gas_Voice), 
				typeof(Obj_Item_Clothing_Head_Bandana), 
				typeof(Obj_Item_Clothing_Head_Rabbitears), 
				typeof(Obj_Item_Clothing_Head_Kitty), 
				typeof(Obj_Item_Clothing_Head_Hairflower), 
				typeof(Obj_Item_Clothing_Head_Helmet_Roman), 
				typeof(Obj_Item_Clothing_Head_Helmet_Roman_Legionaire), 
				typeof(Obj_Item_Clothing_Head_Pumpkinhead), 
				typeof(Obj_Item_Clothing_Head_Soft_Rainbow), 
				typeof(Obj_Item_Clothing_Head_Soft_Sec), 
				typeof(Obj_Item_Clothing_Head_Syndicatefake), 
				typeof(Obj_Item_Clothing_Head_Wizard_Marisa_Fake), 
				typeof(Obj_Item_Clothing_Suit_Wizrobe_Marisa_Fake), 
				typeof(Obj_Item_Clothing_Head_Wizard_Fake), 
				typeof(Obj_Item_Clothing_Suit_Wizrobe_Fake), 
				typeof(Obj_Item_Clothing_Mask_Balaclava), 
				typeof(Obj_Item_Clothing_Mask_Luchador_Tecnicos), 
				typeof(Obj_Item_Clothing_Mask_Luchador_Rudos), 
				typeof(Obj_Item_Clothing_Mask_Cigarette_Cigar), 
				typeof(Obj_Item_Clothing_Mask_Fakemoustache), 
				typeof(Obj_Item_Clothing_Shoes_Galoshes), 
				typeof(Obj_Item_Clothing_Shoes_Jackboots), 
				typeof(Obj_Item_Clothing_Shoes_Roman), 
				typeof(Obj_Item_Clothing_Shoes_Syndigaloshes), 
				typeof(Obj_Item_Clothing_Suit_Chickensuit), 
				typeof(Obj_Item_Clothing_Under_CaptainFly), 
				typeof(Obj_Item_Clothing_Under_Dress_DressSaloon), 
				typeof(Obj_Item_Clothing_Under_Dress_DressYellow), 
				typeof(Obj_Item_Clothing_Under_Dress_DressPink), 
				typeof(Obj_Item_Clothing_Under_Dress_DressOrange), 
				typeof(Obj_Item_Clothing_Under_Dress_DressFire), 
				typeof(Obj_Item_Clothing_Under_Dress_DressGreen), 
				typeof(Obj_Item_Clothing_Under_Gladiator), 
				typeof(Obj_Item_Clothing_Under_Johnny), 
				typeof(Obj_Item_Clothing_Under_Kilt), 
				typeof(Obj_Item_Clothing_Under_Lawyer_Purpsuit), 
				typeof(Obj_Item_Clothing_Under_Lawyer_Female), 
				typeof(Obj_Item_Clothing_Under_Overalls), 
				typeof(Obj_Item_Clothing_Under_Owl), 
				typeof(Obj_Item_Clothing_Under_Pirate), 
				typeof(Obj_Item_Clothing_Under_Psyche), 
				typeof(Obj_Item_Clothing_Under_Psysuit), 
				typeof(Obj_Item_Clothing_Under_Rainbow), 
				typeof(Obj_Item_Clothing_Under_Schoolgirl), 
				typeof(Obj_Item_Clothing_Under_Sexyclown), 
				typeof(Obj_Item_Clothing_Under_Rank_Mailman), 
				typeof(Obj_Item_Clothing_Under_Shorts_Green), 
				typeof(Obj_Item_Clothing_Under_Shorts_Red), 
				typeof(Obj_Item_Clothing_Under_Shorts_Grey), 
				typeof(Obj_Item_Clothing_Under_Stripper_Mankini), 
				typeof(Obj_Item_Clothing_Under_Sundress), 
				typeof(Obj_Item_Clothing_Under_Swimsuit_Black), 
				typeof(Obj_Item_Clothing_Under_Swimsuit_Purple), 
				typeof(Obj_Item_Clothing_Under_Syndicate_Tacticool), 
				typeof(Obj_Item_Clothing_Under_Syndicate), 
				typeof(Obj_Item_Clothing_Under_Waiter), 
				typeof(Obj_Item_Clothing_Under_Wedding_BrideBlue), 
				typeof(Obj_Item_Clothing_Under_Wedding_BridePurple), 
				typeof(Obj_Item_Clothing_Under_Wedding_BrideWhite), 
				typeof(Obj_Item_Pizzabox_Meat), 
				typeof(Obj_Item_Pizzabox_Margherita), 
				typeof(Obj_Item_Pizzabox_Vegetable), 
				typeof(Obj_Item_Pizzabox_Mushroom), 
				typeof(Obj_Item_RobotParts_RobotComponent_Actuator), 
				typeof(Obj_Item_RobotParts_RobotComponent_Armour), 
				typeof(Obj_Item_RobotParts_RobotComponent_BinaryCommunicationDevice), 
				typeof(Obj_Item_RobotParts_Chest), 
				typeof(Obj_Item_RobotParts_RobotSuit), 
				typeof(Obj_Item_Roller), 
				typeof(Obj_Item_Stack_Medical_Ointment), 
				typeof(Obj_Item_Stack_Medical_BruisePack), 
				typeof(Obj_Item_Stack_Medical_Advanced_BruisePack), 
				typeof(Obj_Item_Stack_Medical_Advanced_Ointment), 
				typeof(Obj_Item_Stack_Nanopaste), 
				typeof(Obj_Item_Taperoll_Engineering), 
				typeof(Obj_Item_Taperoll_Police), 
				typeof(Obj_Item_Toy_Ammo_Gun), 
				typeof(Obj_Item_Toy_Balloon), 
				typeof(Obj_Item_Toy_Crayon_Red), 
				typeof(Obj_Item_Toy_Crayon_Yellow), 
				typeof(Obj_Item_Toy_Crayon_Blue), 
				typeof(Obj_Item_Toy_Crossbow), 
				typeof(Obj_Item_Toy_Gun), 
				typeof(Obj_Item_Toy_Snappop), 
				typeof(Obj_Item_Toy_Sword), 
				typeof(Obj_Item_Toy_Bomb), 
				typeof(Obj_Item_Clothing_Mask_Facehugger_Toy), 
				typeof(Obj_Item_Trash_Candle), 
				typeof(Obj_Item_Trash_Candy), 
				typeof(Obj_Item_Trash_Cheesie), 
				typeof(Obj_Item_Trash_Chips), 
				typeof(Obj_Item_Trash_Plate), 
				typeof(Obj_Item_Trash_Popcorn), 
				typeof(Obj_Item_Trash_Raisins), 
				typeof(Obj_Item_Trash_Sosjerky), 
				typeof(Obj_Item_Clothing_Accessory_Medal_Conduct), 
				typeof(Obj_Item_Weapon_Bananapeel), 
				typeof(Obj_Item_Weapon_Corncob), 
				typeof(Obj_Item_Weapon_Bikehorn), 
				typeof(Obj_Item_Weapon_CTube), 
				typeof(Obj_Item_Weapon_Legcuffs_Beartrap), 
				typeof(Obj_Item_Weapon_Caution), 
				typeof(Obj_Item_Weapon_RackParts), 
				typeof(Obj_Item_Weapon_Caution_Cone), 
				typeof(Obj_Item_Weapon_BeachBall), 
				typeof(Obj_Item_Weapon_BeeNet), 
				typeof(Obj_Item_Weapon_Bikehorn_Rubberducky), 
				typeof(Obj_Item_Weapon_BrokenBottle), 
				typeof(Obj_Item_Weapon_BucketSensor), 
				typeof(Obj_Item_Stack_CableCoil), 
				typeof(Obj_Item_Weapon_CameraAssembly), 
				typeof(Obj_Item_Weapon_Cigbutt_Cigarbutt), 
				typeof(Obj_Item_Weapon_Clipboard), 
				typeof(Obj_Item_Weapon_Coin), 
				typeof(Obj_Item_Weapon_Coin_Gold), 
				typeof(Obj_Item_Weapon_Coin_Adamantine), 
				typeof(Obj_Item_Weapon_Coin_Clown), 
				typeof(Obj_Item_Weapon_Coin_Diamond), 
				typeof(Obj_Item_Weapon_Coin_Iron), 
				typeof(Obj_Item_Weapon_Coin_Phazon), 
				typeof(Obj_Item_Weapon_Coin_Plasma), 
				typeof(Obj_Item_Weapon_Coin_Silver), 
				typeof(Obj_Item_Weapon_Coin_Uranium), 
				typeof(Obj_Item_Weapon_Dice), 
				typeof(Obj_Item_Weapon_Flamethrower_Full), 
				typeof(Obj_Item_Weapon_Gun_Projectile_Deagle_Gold), 
				typeof(Obj_Item_Weapon_Gun_Projectile_Russian), 
				typeof(Obj_Item_Weapon_Handcuffs), 
				typeof(Obj_Item_Weapon_Handcuffs_Cable), 
				typeof(Obj_Item_Weapon_Hatchet), 
				typeof(Obj_Item_Weapon_Kitchen_Rollingpin), 
				typeof(Obj_Item_Weapon_Lighter_Random), 
				typeof(Obj_Item_Weapon_Lipstick_Random), 
				typeof(Obj_Item_Weapon_Minihoe), 
				typeof(Obj_Item_Weapon_Mop), 
				typeof(Obj_Item_Weapon_Newspaper), 
				typeof(Obj_Item_Weapon_Pen), 
				typeof(Obj_Item_Weapon_Scalpel), 
				typeof(Obj_Item_Weapon_Shard), 
				typeof(Obj_Item_Weapon_Stool), 
				typeof(Obj_Item_Device_Powersink), 
				typeof(Obj_Item_Weapon_ReagentContainers_Blood_OMinus), 
				typeof(Obj_Item_Weapon_ReagentContainers_Glass_Bottle_Ammonia), 
				typeof(Obj_Item_Weapon_ReagentContainers_Glass_Bottle_Capsaicin), 
				typeof(Obj_Item_Weapon_ReagentContainers_Glass_Bottle_Chloralhydrate), 
				typeof(Obj_Item_Weapon_ReagentContainers_Glass_Bottle_Cold), 
				typeof(Obj_Item_Weapon_ReagentContainers_Glass_Bottle_Diethylamine), 
				typeof(Obj_Item_Weapon_ReagentContainers_Glass_Bottle_EpiglottisVirion), 
				typeof(Obj_Item_Weapon_ReagentContainers_Glass_Bottle_FluVirion), 
				typeof(Obj_Item_Weapon_ReagentContainers_Glass_Bottle_Magnitis), 
				typeof(Obj_Item_Weapon_ReagentContainers_Glass_Bottle_PierrotThroat), 
				typeof(Obj_Item_Weapon_ReagentContainers_Food_Drinks_Beer), 
				typeof(Obj_Item_Weapon_ReagentContainers_Food_Drinks_Bottle_Absinthe), 
				typeof(Obj_Item_Weapon_ReagentContainers_Food_Drinks_Bottle_Cream), 
				typeof(Obj_Item_Weapon_ReagentContainers_Food_Drinks_Bottle_Orangejuice), 
				typeof(Obj_Item_Weapon_ReagentContainers_Food_Drinks_Bottle_Tequila), 
				typeof(Obj_Item_Weapon_ReagentContainers_Food_Drinks_Bottle_Vermouth), 
				typeof(Obj_Item_Weapon_ReagentContainers_Food_Drinks_Bottle_Wine), 
				typeof(Obj_Item_Weapon_ReagentContainers_Food_Drinks_Coffee), 
				typeof(Obj_Item_Weapon_ReagentContainers_Food_Drinks_SodaCans_Cola), 
				typeof(Obj_Item_Weapon_ReagentContainers_Food_Drinks_SodaCans_DrGibb), 
				typeof(Obj_Item_Weapon_ReagentContainers_Food_Drinks_SodaCans_Starkist), 
				typeof(Obj_Item_Weapon_ReagentContainers_Food_Drinks_SodaCans_Thirteenloko), 
				typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Pie_AmanitaPie), 
				typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Amanitajelly), 
				typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Applecakeslice), 
				typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Pie_Applepie), 
				typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Bigbiteburger), 
				typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Boiledegg), 
				typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Brainburger), 
				typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Meat_Carpmeat), 
				typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Cheesiehonkers), 
				typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Chips), 
				typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Chocolatebar_Wrapped), 
				typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Clownstears), 
				typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Coldchili), 
				typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Corgikabob), 
				typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Donkpocket), 
				typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Donut), 
				typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Meat_Animal_Monkey), 
				typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_NoRaisin), 
				typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Pie_PlumpPie), 
				typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Soylenviridians), 
				typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Syndicake), 
				typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Tofurkey)
			 });
			this.icon_state = "maint";
		}

		public Obj_Map_Spawner_Maint ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}