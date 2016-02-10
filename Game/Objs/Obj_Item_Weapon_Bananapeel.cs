// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Bananapeel : Obj_Item_Weapon {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "banana_peel";
			this.w_class = 1;
			this.throwforce = 0;
			this.throw_speed = 4;
			this.throw_range = 20;
			this.icon_state = "banana_peel";
		}

		public Obj_Item_Weapon_Bananapeel ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: clown_items.dm
		public override dynamic Crossed( Ent_Dynamic O = null, dynamic X = null ) {
			Ent_Dynamic M = null;

			
			if ( O is Mob_Living_Carbon ) {
				M = O;

				if ( ((Mob_Living_Carbon)M).Slip( 2, 2, true ) ) {
					((Mob)M).simple_message( "<span class='notice'>You slipped on the " + this.name + "!</span>", "<span class='userdanger'>Something is scratching at your feet! Oh god!</span>" );
				}
			}
			return null;
		}

		// Function from file: weapon.dm
		public override dynamic suicide_act( Mob_Living_Carbon_Human user = null ) {
			GlobalFuncs.to_chat( Map13.FetchViewers( null, user ), new Txt( "<span class='danger'>" ).item( user ).str( " drops the " ).item( this.name ).str( " on the ground and steps on it causing " ).him_her_it_them().str( " to crash to the floor, bashing " ).his_her_its_their().str( " head wide open. </span>" ).ToString() );
			return 8;
		}

	}

}