// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_AdvMassSpectrometer : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Advanced Mass-Spectrometer";
			this.desc = "A device for analyzing chemicals in the blood and their quantities.";
			this.id = "adv_mass_spectrometer";
			this.req_tech = new ByTable().Set( "biotech", 2 ).Set( "magnets", 4 );
			this.build_type = 2;
			this.materials = new ByTable().Set( "$metal", 30 ).Set( "$glass", 20 );
			this.reliability = 74;
			this.build_path = typeof(Obj_Item_Device_MassSpectrometer_Adv);
			this.category = new ByTable(new object [] { "Medical Designs" });
		}

	}

}