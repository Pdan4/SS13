// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Rune_Armor : Obj_Effect_Rune {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.cultist_name = "Summon Armaments";
			this.cultist_desc = "Equips the user with robes, shoes, a backpack, and a longsword. Items that cannot be equipped will not be summoned.";
			this.invocation = "N'ath reth sh'yro eth draggathnor!";
			this.icon_state = "4";
		}

		public Obj_Effect_Rune_Armor ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: runes.dm
		public override void invoke( dynamic user = null ) {
			this.visible_message( "<span class='warning'>With the sound of clanging metal, " + this + " crumbles to dust!</span>" );
			((Mob)user).equip_to_slot_or_del( new Obj_Item_Clothing_Head_Culthood_Alt( user ), 11 );
			((Mob)user).equip_to_slot_or_del( new Obj_Item_Clothing_Suit_Cultrobes_Alt( user ), 13 );
			((Mob)user).equip_to_slot_or_del( new Obj_Item_Clothing_Shoes_Cult_Alt( user ), 12 );
			((Mob)user).equip_to_slot_or_del( new Obj_Item_Weapon_Storage_Backpack_Cultpack( user ), 1 );
			((Mob)user).put_in_hands( new Obj_Item_Weapon_Melee_Cultblade( user ) );
			GlobalFuncs.qdel( this );
			return;
		}

	}

}