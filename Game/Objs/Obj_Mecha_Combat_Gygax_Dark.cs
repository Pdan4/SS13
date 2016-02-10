// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Mecha_Combat_Gygax_Dark : Obj_Mecha_Combat_Gygax {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.initial_icon = "darkgygax";
			this.health = 400;
			this.deflect_chance = 25;
			this.damage_absorption = new ByTable().Set( "brute", 0.6 ).Set( "fire", 0.8 ).Set( "bullet", 0.6 ).Set( "laser", 0.5 ).Set( "energy", 0.41 ).Set( "bomb", 0.8 );
			this.max_temperature = 45000;
			this.overload_coeff = 1;
			this.wreckage = typeof(Obj_Effect_Decal_MechaWreckage_Gygax_Dark);
			this.max_equip = 4;
			this.step_energy_drain = 5;
			this.icon_state = "darkgygax";
		}

		// Function from file: gygax.dm
		public Obj_Mecha_Combat_Gygax_Dark ( dynamic loc = null ) : base( (object)(loc) ) {
			Obj_Item_MechaParts_MechaEquipment ME = null;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			ME = new Obj_Item_MechaParts_MechaEquipment_Weapon_Ballistic_Scattershot();
			ME.attach( this );
			ME = new Obj_Item_MechaParts_MechaEquipment_Weapon_Ballistic_MissileRack_Flashbang_Clusterbang();
			ME.attach( this );
			ME = new Obj_Item_MechaParts_MechaEquipment_Teleporter();
			ME.attach( this );
			ME = new Obj_Item_MechaParts_MechaEquipment_TeslaEnergyRelay();
			ME.attach( this );
			return;
		}

		// Function from file: gygax.dm
		public override void add_cell( Ent_Dynamic C = null ) {
			
			if ( C != null ) {
				C.forceMove( this );
				this.cell = C;
				return;
			}
			this.cell = new Obj_Item_Weapon_Cell( this );
			this.cell.charge = 30000;
			this.cell.maxcharge = 30000;
			return;
		}

	}

}