// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Construction_Mecha_PhazonChassis : Construction_Mecha {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.result = "/obj/mecha/combat/phazon";
			this.steps = new ByTable(new object [] { 
				new ByTable().Set( "key", typeof(Obj_Item_MechaParts_Part_PhazonTorso) ), 
				new ByTable().Set( "key", typeof(Obj_Item_MechaParts_Part_PhazonLeftArm) ), 
				new ByTable().Set( "key", typeof(Obj_Item_MechaParts_Part_PhazonRightArm) ), 
				new ByTable().Set( "key", typeof(Obj_Item_MechaParts_Part_PhazonLeftLeg) ), 
				new ByTable().Set( "key", typeof(Obj_Item_MechaParts_Part_PhazonRightLeg) ), 
				new ByTable().Set( "key", typeof(Obj_Item_MechaParts_Part_PhazonHead) )
			 });
		}

		public Construction_Mecha_PhazonChassis ( Game_Data atom = null ) : base( atom ) {
			
		}

		// Function from file: mecha_construction_paths.dm
		public override void spawn_result(  ) {
			Game_Data const_holder = null;

			const_holder = this.holder;
			((dynamic)const_holder).construct = new Construction_Reversible_Mecha_Phazon( const_holder );
			((dynamic)const_holder).icon = "icons/mecha/mech_construction.dmi";
			((dynamic)const_holder).icon_state = "phazon0";
			((dynamic)const_holder).density = 1;
			Lang13.Delete( this );
			Task13.Source = null;
			return;
		}

		// Function from file: mecha_construction_paths.dm
		public override bool action( dynamic used_atom = null, dynamic user = null ) {
			return this.check_all_steps( used_atom, user );
		}

		// Function from file: mecha_construction_paths.dm
		public override bool custom_action( int? index = null, dynamic diff = null, dynamic used_atom = null, dynamic user = null ) {
			((Ent_Static)used_atom).visible_message( "" + used_atom + " has connected " + diff + " to the " + this.holder + ".", "<span class='notice'>You connect " + diff + " to the " + this.holder + ".</span>" );
			((dynamic)this.holder).overlays += diff.icon_state + "+o";
			GlobalFuncs.qdel( diff );
			return true;
		}

	}

}