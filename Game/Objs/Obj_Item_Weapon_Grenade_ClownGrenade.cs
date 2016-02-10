// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Grenade_ClownGrenade : Obj_Item_Weapon_Grenade {

		public bool stage = false;
		public bool state = false;
		public bool path = false;
		public int affected_area = 2;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.force = 2;
			this.icon_state = "chemg";
		}

		// Function from file: clowngrenade.dm
		public Obj_Item_Weapon_Grenade_ClownGrenade ( dynamic loc = null ) : base( (object)(loc) ) {
			this.icon_state = Lang13.Initial( this, "icon_state" ) + "_locked";
			return;
		}

		// Function from file: clowngrenade.dm
		public override void prime( dynamic L = null ) {
			int i = 0;
			int number = 0;
			dynamic direction = null;
			Obj_Item_Weapon_Bananapeel_Traitorpeel peel = null;
			int a = 0;

			base.prime( (object)(L) );
			GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/items/bikehorn.ogg", 25, -3 );
			i = 0;
			number = 0;

			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.alldirs )) {
				direction = _a;
				
				i = 0;

				while (i < 2) {
					number++;
					peel = new Obj_Item_Weapon_Bananapeel_Traitorpeel( GlobalFuncs.get_turf( this.loc ) );
					a = 1;

					if ( ( number & 2 ) != 0 ) {
						a = 1;

						while (a <= 2) {
							Map13.Step( peel, Convert.ToInt32( direction ) );
							a++;
						}
					} else {
						Map13.Step( peel, Convert.ToInt32( direction ) );
					}
					i++;
				}
			}
			new Obj_Item_Weapon_Bananapeel_Traitorpeel( GlobalFuncs.get_turf( this.loc ) );
			GlobalFuncs.qdel( this );
			return;
		}

	}

}