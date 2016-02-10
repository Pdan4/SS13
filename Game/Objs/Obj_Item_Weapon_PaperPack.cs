// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_PaperPack : Obj_Item_Weapon {

		public int? amount = 0;
		public int maxamount = 20;
		public Type papertype = typeof(Obj_Item_Weapon_Paper);
		public string pptype = "";

		protected override void __FieldInit() {
			base.__FieldInit();

			this.throwforce = 2;
			this.throw_range = 5;
			this.throw_speed = 1;
			this.pressure_resistance = 1;
			this.attack_verb = new ByTable(new object [] { "slaps", "baps", "whaps" });
			this.autoignition_temperature = 519.1500244140625;
			this.fire_fuel = 1;
			this.icon = "icons/obj/paper.dmi";
			this.icon_state = "pp_large";
			this.layer = 3.9;
		}

		// Function from file: paper_pack.dm
		public Obj_Item_Weapon_PaperPack ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.amount = 20;
			this.pixel_x = Rand13.Int( -5, 3 );
			this.pixel_y = Rand13.Int( -3, 5 );
			this.update_icon();
			return;
		}

		// Function from file: paper_pack.dm
		public override dynamic examine( dynamic user = null, string size = null ) {
			base.examine( (object)(user), size );

			if ( Lang13.Bool( this.amount ) ) {
				GlobalFuncs.to_chat( user, "<span class='info'>There are " + this.amount + " sheets in the pack.</span>" );
			}
			return null;
		}

		// Function from file: paper_pack.dm
		public override bool? update_icon( dynamic location = null, dynamic target = null ) {
			
			if ( Lang13.Bool( this.amount ) ) {
				
				if ( ( this.amount ??0) > 14 ) {
					this.icon_state = "" + this.pptype + "pp_large";
				} else if ( ( this.amount ??0) > 8 ) {
					this.icon_state = "" + this.pptype + "pp_medium";
				} else if ( ( this.amount ??0) > 0 ) {
					this.icon_state = "" + this.pptype + "pp_small";
				}
				this.name = "" + this.pptype + "paper pack";
				this.desc = "A pack of " + this.pptype + "papers, secured by some red ribbon.";
			} else {
				new Obj_Item_Weapon_Ribbon( GlobalFuncs.get_turf( this ) );
				GlobalFuncs.qdel( this );
			}
			return null;
		}

		// Function from file: paper_pack.dm
		public int? usepaper( int? sheetcount = null ) {
			sheetcount = sheetcount ?? 0;

			int? usedpaper = null;

			usedpaper = 0;

			if ( Lang13.Bool( sheetcount ) && ( sheetcount ??0) <= ( this.amount ??0) ) {
				usedpaper = sheetcount;
				this.amount -= sheetcount ??0;
			}

			if ( Lang13.Bool( sheetcount ) && ( sheetcount ??0) > ( this.amount ??0) ) {
				usedpaper = ( sheetcount ??0) - ( this.amount ??0);
				this.amount = 0;
			}
			this.update_icon();
			return usedpaper;
		}

		// Function from file: paper_pack.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			
			if ( Task13.User.loc != null ) {
				Lang13.Call( this.papertype, Task13.User.loc );
				this.usepaper( 1 );
			}
			return null;
		}

		// Function from file: paper_pack.dm
		[Verb]
		[VerbInfo( name: "Untie Paper Pack", group: "Object", access: VerbAccess.InUserContents, range: 127 )]
		public void ribbontie(  ) {
			int? i = null;

			
			if ( ( this.amount ??0) <= 5 ) {
				i = null;
				i = 1;

				while (( i ??0) <= ( this.amount ??0)) {
					Lang13.Call( this.papertype, Task13.User.loc );
					i++;
				}
				this.usepaper( this.amount );
				GlobalFuncs.to_chat( Task13.User, "<span class='notice'>You pick the ribbon knot and drop all the papers.</span>" );
			} else {
				GlobalFuncs.to_chat( Task13.User, "<span class='warning'>You don't think it would be wise to drop this much paper.</span>" );
			}
			return;
		}

	}

}