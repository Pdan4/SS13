// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Construction_MechaChassis_Odysseus : Construction_MechaChassis {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.steps = new ByTable(new object [] { 
				new ByTable().Set( "key", typeof(Obj_Item_MechaParts_Part_OdysseusTorso) ), 
				new ByTable().Set( "key", typeof(Obj_Item_MechaParts_Part_OdysseusHead) ), 
				new ByTable().Set( "key", typeof(Obj_Item_MechaParts_Part_OdysseusLeftArm) ), 
				new ByTable().Set( "key", typeof(Obj_Item_MechaParts_Part_OdysseusRightArm) ), 
				new ByTable().Set( "key", typeof(Obj_Item_MechaParts_Part_OdysseusLeftLeg) ), 
				new ByTable().Set( "key", typeof(Obj_Item_MechaParts_Part_OdysseusRightLeg) )
			 });
		}

		public Construction_MechaChassis_Odysseus ( Ent_Static atom = null ) : base( atom ) {
			
		}

		// Function from file: mecha_construction_chassis.dm
		public override void spawn_result( dynamic user = null ) {
			Ent_Static const_holder = null;

			const_holder = this.holder;
			((dynamic)const_holder).construct = new Construction_Reversible_Mecha_Odysseus( const_holder );
			const_holder.icon = "icons/mecha/mech_construction.dmi";
			const_holder.icon_state = "odysseus0";
			const_holder.density = true;
			Task13.Schedule( 0, (Task13.Closure)(() => {
				GlobalFuncs.qdel( this );
				return;
			}));
			return;
		}

	}

}