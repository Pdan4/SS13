// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Stamp_Chameleon : Obj_Item_Weapon_Stamp {

		public Obj_Item_Weapon_Stamp_Chameleon ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: stamps.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			dynamic stamp_types = null;
			ByTable stamps = null;
			dynamic stamp_type = null;
			dynamic S = null;
			ByTable show_stamps = null;
			dynamic input_stamp = null;
			Obj_Item chosen_stamp = null;

			stamp_types = Lang13.GetTypes( typeof(Obj_Item_Weapon_Stamp) ) - this.type;
			stamps = new ByTable();

			foreach (dynamic _a in Lang13.Enumerate( stamp_types )) {
				stamp_type = _a;
				
				S = Lang13.Call( stamp_type );
				stamps[GlobalFuncs.capitalize( S.name )] = S;
			}
			show_stamps = new ByTable().Set( "EXIT", null ) + GlobalFuncs.sortList( stamps );
			input_stamp = Interface13.Input( user, "Choose a stamp to disguise as.", "Choose a stamp.", null, show_stamps, InputType.Any );

			if ( user.contents.Contains( Lang13.Bool( user ) && this != null ) ) {
				chosen_stamp = stamps[GlobalFuncs.capitalize( input_stamp )];

				if ( chosen_stamp != null ) {
					this.name = chosen_stamp.name;
					this.icon_state = chosen_stamp.icon_state;
					this.item_color = chosen_stamp.item_color;
				}
			}
			return null;
		}

	}

}