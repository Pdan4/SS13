// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_AiModule_ToyAI : Obj_Item_Weapon_AiModule {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.origin_tech = "programming=3;materials=6;syndicate=7";
			this.laws = new ByTable(new object [] { "" });
			this.icon = "icons/obj/toy.dmi";
			this.icon_state = "AI";
		}

		public Obj_Item_Weapon_AiModule_ToyAI ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: AI_modules.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			this.laws[1] = GlobalFuncs.generate_ion_law();
			user.WriteMsg( "<span class='notice'>You press the button on " + this + ".</span>" );
			GlobalFuncs.playsound( user, "sound/machines/click.ogg", 20, 1 );
			this.loc.visible_message( new Txt( "<span class='warning'>" ).icon( this ).str( " " ).item( this.laws[1] ).str( "</span>" ).ToString() );
			return null;
		}

		// Function from file: AI_modules.dm
		public override dynamic transmitInstructions( Game_Data law_datum = null, dynamic sender = null ) {
			
			if ( Lang13.Bool( ((dynamic)law_datum).owner ) ) {
				((dynamic)law_datum).owner.WriteMsg( "<span class='warning'>KRZZZT</span>" );
				((Mob_Living_Silicon)((dynamic)law_datum).owner).add_ion_law( this.laws[1] );
			} else {
				((AiLaws)law_datum).add_ion_law( this.laws[1] );
			}
			return this.laws[1];
		}

	}

}