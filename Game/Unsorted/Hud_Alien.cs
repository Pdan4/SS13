// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Hud_Alien : Hud {

		// Function from file: alien.dm
		public Hud_Alien ( Mob_Living_Carbon_Alien_Humanoid owner = null ) : base( owner ) {
			Obj_Screen _using = null;
			Obj_Screen_Inventory inv_box = null;
			Mob H = null;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			inv_box = new Obj_Screen_Inventory();
			inv_box.name = "r_hand";
			inv_box.icon = "icons/mob/screen_alien.dmi";
			inv_box.icon_state = "hand_r_inactive";

			if ( this.mymob != null && !this.mymob.hand ) {
				inv_box.icon_state = "hand_r_active";
			}
			inv_box.screen_loc = "CENTER:-16,SOUTH:5";
			inv_box.layer = 19;
			inv_box.slot_id = 5;
			this.r_hand_hud_object = inv_box;

			if ( Lang13.Bool( owner.handcuffed ) ) {
				inv_box.overlays.Add( new Image( "icons/mob/screen_gen.dmi", null, "markus" ) );
			}
			this.static_inventory.Add( inv_box );
			inv_box = new Obj_Screen_Inventory();
			inv_box.name = "l_hand";
			inv_box.icon = "icons/mob/screen_alien.dmi";
			inv_box.icon_state = "hand_l_inactive";

			if ( this.mymob != null && this.mymob.hand ) {
				inv_box.icon_state = "hand_l_active";
			}
			inv_box.screen_loc = "CENTER: 16,SOUTH:5";
			inv_box.layer = 19;
			inv_box.slot_id = 4;
			this.l_hand_hud_object = inv_box;

			if ( Lang13.Bool( owner.handcuffed ) ) {
				inv_box.overlays.Add( new Image( "icons/mob/screen_gen.dmi", null, "gabrielle" ) );
			}
			this.static_inventory.Add( inv_box );
			_using = new Obj_Screen_Inventory();
			_using.name = "hand";
			_using.icon = "icons/mob/screen_alien.dmi";
			_using.icon_state = "swap_1";
			_using.screen_loc = "CENTER:-16,SOUTH+1:5";
			_using.layer = 19;
			this.static_inventory.Add( _using );
			_using = new Obj_Screen_Inventory();
			_using.name = "hand";
			_using.icon = "icons/mob/screen_alien.dmi";
			_using.icon_state = "swap_2";
			_using.screen_loc = "CENTER: 16,SOUTH+1:5";
			_using.layer = 19;
			this.static_inventory.Add( _using );
			_using = new Obj_Screen_ActIntent_Alien();
			_using.icon_state = this.mymob.a_intent;
			this.static_inventory.Add( _using );
			this.action_intent = _using;

			if ( this.mymob is Mob_Living_Carbon_Alien_Humanoid_Hunter ) {
				H = this.mymob;
				((dynamic)H).leap_icon = new Obj_Screen_Alien_Leap();
				((dynamic)H).leap_icon.screen_loc = "CENTER+1:18,SOUTH:5";
				this.static_inventory.Add( ((dynamic)H).leap_icon );
			}
			_using = new Obj_Screen_Drop();
			_using.icon = "icons/mob/screen_alien.dmi";
			_using.screen_loc = "EAST-1:28,SOUTH+1:7";
			this.static_inventory.Add( _using );
			_using = new Obj_Screen_Resist();
			_using.icon = "icons/mob/screen_alien.dmi";
			_using.screen_loc = "EAST-2:26,SOUTH+1:7";
			this.hotkeybuttons.Add( _using );
			this.throw_icon = new Obj_Screen_ThrowCatch();
			this.throw_icon.icon = "icons/mob/screen_alien.dmi";
			this.throw_icon.screen_loc = "EAST-1:28,SOUTH+1:7";
			this.hotkeybuttons.Add( this.throw_icon );
			this.pull_icon = new Obj_Screen_Pull();
			this.pull_icon.icon = "icons/mob/screen_alien.dmi";
			this.pull_icon.update_icon( this.mymob );
			this.pull_icon.screen_loc = "EAST-2:26,SOUTH+1:7";
			this.static_inventory.Add( this.pull_icon );
			this.healths = new Obj_Screen_Healths_Alien();
			this.infodisplay.Add( this.healths );
			this.nightvisionicon = new Obj_Screen_Alien_Nightvision();
			this.infodisplay.Add( this.nightvisionicon );
			this.alien_plasma_display = new Obj_Screen_Alien_PlasmaDisplay();
			this.infodisplay.Add( this.alien_plasma_display );
			this.zone_select = new Obj_Screen_ZoneSel_Alien();
			this.zone_select.update_icon( this.mymob );
			this.static_inventory.Add( this.zone_select );
			return;
		}

		// Function from file: alien.dm
		public override void persistant_inventory_update(  ) {
			Mob H = null;

			
			if ( !( this.mymob != null ) ) {
				return;
			}
			H = this.mymob;

			if ( this.hud_version != 3 ) {
				
				if ( Lang13.Bool( H.r_hand ) ) {
					H.r_hand.screen_loc = "CENTER:-16,SOUTH:5";
					H.client.screen.Add( H.r_hand );
				}

				if ( Lang13.Bool( H.l_hand ) ) {
					H.l_hand.screen_loc = "CENTER: 16,SOUTH:5";
					H.client.screen.Add( H.l_hand );
				}
			} else {
				
				if ( Lang13.Bool( H.r_hand ) ) {
					H.r_hand.screen_loc = null;
				}

				if ( Lang13.Bool( H.l_hand ) ) {
					H.l_hand.screen_loc = null;
				}
			}
			return;
		}

	}

}