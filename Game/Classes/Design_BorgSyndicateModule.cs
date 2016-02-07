// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_BorgSyndicateModule : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Cyborg Illegal Upgrades Module";
			this.desc = "Allows for the construction of restricted upgrades for cyborgs";
			this.id = "borg_syndicate_module";
			this.build_type = 16;
			this.req_tech = new ByTable().Set( "combat", 4 ).Set( "syndicate", 3 );
			this.build_path = typeof(Obj_Item_Borg_Upgrade_Syndicate);
			this.materials = new ByTable().Set( "$metal", 10000 ).Set( "$glass", 15000 ).Set( "$diamond", 10000 );
			this.construction_time = 120;
			this.category = new ByTable(new object [] { "Cyborg Upgrade Modules" });
		}

	}

}