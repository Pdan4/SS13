// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_MechaParts_MechaEquipment_Weapon_Ballistic_MissileRack_Bolas : Obj_Item_MechaParts_MechaEquipment_Weapon_Ballistic_MissileRack {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.projectile = typeof(Obj_Item_Weapon_Legcuffs_Bolas);
			this.fire_sound = "sound/weapons/whip.ogg";
			this.projectiles = 10;
			this.missile_speed = 1;
			this.projectile_energy_cost = 50;
			this.equip_cooldown = 10;
			this.icon_state = "mecha_bolas";
		}

		public Obj_Item_MechaParts_MechaEquipment_Weapon_Ballistic_MissileRack_Bolas ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: weapons.dm
		public override bool action( dynamic target = null ) {
			dynamic M = null;

			
			if ( !this.action_checks( target ) ) {
				return false;
			}
			this.set_ready_state( false );
			M = Lang13.Call( this.projectile, this.chassis.loc );
			GlobalFuncs.playsound( this.chassis, this.fire_sound, 50, 1 );
			M.thrown_from = this;
			((Ent_Dynamic)M).throw_at( target, this.missile_range, this.missile_speed );
			this.projectiles--;
			this.log_message( "Fired from " + this.name + ", targeting " + target + "." );
			this.do_after_cooldown();
			return false;
		}

		// Function from file: weapons.dm
		public override bool can_attach( Obj_Mecha M = null ) {
			
			if ( base.can_attach( M ) ) {
				
				if ( M is Obj_Mecha_Combat_Gygax ) {
					return true;
				}
			}
			return false;
		}

	}

}