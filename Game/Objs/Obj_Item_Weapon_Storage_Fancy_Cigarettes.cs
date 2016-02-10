// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Storage_Fancy_Cigarettes : Obj_Item_Weapon_Storage_Fancy {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "cigpacket";
			this.w_class = 1;
			this.throwforce = 2;
			this.flags = 0;
			this.slot_flags = 512;
			this.storage_slots = 6;
			this.can_hold = new ByTable(new object [] { "=/obj/item/clothing/mask/cigarette", "/obj/item/weapon/lighter" });
			this.icon_type = "cigarette";
			this.starting_materials = new ByTable().Set( "$cardboard", 370 );
			this.w_type = 1;
			this.icon = "icons/obj/cigarettes.dmi";
			this.icon_state = "cigpacket";
		}

		// Function from file: fancy.dm
		public Obj_Item_Weapon_Storage_Fancy_Cigarettes ( dynamic loc = null ) : base( (object)(loc) ) {
			double i = 0;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.flags |= 16384;

			foreach (dynamic _a in Lang13.IterateRange( 1, this.storage_slots )) {
				i = _a;
				
				new Obj_Item_Clothing_Mask_Cigarette( this );
			}
			this.create_reagents( ( this.storage_slots ??0) * 15 );
			return;
		}

		// Function from file: fancy.dm
		public override bool? attack( dynamic M = null, dynamic user = null, string def_zone = null, bool? eat_override = null ) {
			Obj_Item_Clothing_Mask_Cigarette W = null;

			
			if ( !( M is Mob ) ) {
				return null;
			}

			if ( M == user && ((dynamic)user.zone_sel).selecting == "mouth" && this.contents.len > 0 && !Lang13.Bool( user.wear_mask ) ) {
				W = new Obj_Item_Clothing_Mask_Cigarette( user );
				((Reagents)this.reagents).trans_to( W, ( this.reagents.total_volume ??0) / this.contents.len );
				((Mob)user).equip_to_slot_if_possible( W, 2 );
				this.reagents.maximum_volume = this.contents.len * 15;
				this.contents.len--;
				GlobalFuncs.to_chat( user, "<span class='notice'>You take a cigarette out of the pack.</span>" );
				this.update_icon();
			} else {
				base.attack( (object)(M), (object)(user), def_zone, eat_override );
			}
			return null;
		}

		// Function from file: fancy.dm
		public override bool remove_from_storage( dynamic W = null, dynamic new_location = null, bool? force = null ) {
			dynamic C = null;

			C = W;

			if ( !( C is Obj_Item_Clothing_Mask_Cigarette ) ) {
				return false;
			}
			((Reagents)this.reagents).trans_to( C, ( this.reagents.total_volume ??0) / this.contents.len );
			base.remove_from_storage( (object)(W), (object)(new_location), force );
			return false;
		}

		// Function from file: fancy.dm
		public override bool? update_icon( dynamic location = null, dynamic target = null ) {
			this.icon_state = "" + Lang13.Initial( this, "icon_state" ) + this.contents.len;
			this.desc = new Txt( "There are " ).item( this.contents.len ).str( " cig" ).s().str( " left!" ).ToString();
			return null;
		}

		// Function from file: fancy.dm
		public override dynamic Destroy( dynamic brokenup = null ) {
			GlobalFuncs.qdel( this.reagents );
			this.reagents = null;
			base.Destroy( (object)(brokenup) );
			return null;
		}

	}

}