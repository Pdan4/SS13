// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Snackbar : Obj_Item_Weapon_ReagentContainers_Food_Snacks {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.bitesize = 5;
			this.volume = 10;
			this.icon_state = "snackbar";
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Snackbar ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: snackbar.dm
		public void update_name(  ) {
			string newname = null;
			int i = 0;
			Reagent r = null;

			newname = "";
			i = 0;

			foreach (dynamic _a in Lang13.Enumerate( this.reagents.reagent_list, typeof(Reagent) )) {
				r = _a;
				
				i++;

				if ( i == 1 ) {
					newname += "" + r.name;
				} else if ( i == this.reagents.reagent_list.len ) {
					newname += " and " + r.name;
				} else {
					newname += ", " + r.name;
				}
			}
			this.name = String13.ToLower( "" + newname + " snack bar" );
			return;
		}

		// Function from file: snackbar.dm
		public override bool? update_icon( dynamic location = null, dynamic target = null ) {
			Icon I = null;

			I = new Icon( "icons/obj/food.dmi", "snackbar" );
			I += GlobalFuncs.mix_color_from_reagents( this.reagents.reagent_list );
			this.icon = I;
			return null;
		}

		// Function from file: snackbar.dm
		public override void on_reagent_change(  ) {
			
			if ( !Lang13.Bool( this.reagents.total_volume ) ) {
				this.icon_state = "";
				Task13.Schedule( 1, (Task13.Closure)(() => {
					GlobalFuncs.qdel( this );
					return;
				}));
			} else {
				this.update_icon();
				this.update_name();
			}
			return;
		}

	}

}