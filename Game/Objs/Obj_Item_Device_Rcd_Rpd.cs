// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Device_Rcd_Rpd : Obj_Item_Device_Rcd {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.starting_materials = new ByTable().Set( "$iron", 75000 ).Set( "$glass", 37500 );
			this.schematics = new ByTable(new object [] { 
				typeof(RcdSchematic_DeconPipes), 
				typeof(RcdSchematic_PaintPipes), 
				typeof(RcdSchematic_Pipe), 
				typeof(RcdSchematic_Pipe_Bent), 
				typeof(RcdSchematic_Pipe_Manifold), 
				typeof(RcdSchematic_Pipe_Valve), 
				typeof(RcdSchematic_Pipe_Dvalve), 
				typeof(RcdSchematic_Pipe_Cap), 
				typeof(RcdSchematic_Pipe_Manifold4w), 
				typeof(RcdSchematic_Pipe_Mtvalve), 
				typeof(RcdSchematic_Pipe_Dtvalve), 
				typeof(RcdSchematic_Pipe_LayerManifold), 
				typeof(RcdSchematic_Pipe_LayerAdapter), 
				typeof(RcdSchematic_Pipe_Connector), 
				typeof(RcdSchematic_Pipe_UnaryVent), 
				typeof(RcdSchematic_Pipe_PassiveVent), 
				typeof(RcdSchematic_Pipe_Pump), 
				typeof(RcdSchematic_Pipe_PassiveGate), 
				typeof(RcdSchematic_Pipe_VolumePump), 
				typeof(RcdSchematic_Pipe_Scrubber), 
				typeof(RcdSchematic_Pmeter), 
				typeof(RcdSchematic_Gsensor), 
				typeof(RcdSchematic_Pipe_Filter), 
				typeof(RcdSchematic_Pipe_Mixer), 
				typeof(RcdSchematic_Pipe_ThermalPlate), 
				typeof(RcdSchematic_Pipe_Injector), 
				typeof(RcdSchematic_Pipe_DpVent), 
				typeof(RcdSchematic_Pipe_He), 
				typeof(RcdSchematic_Pipe_HeBent), 
				typeof(RcdSchematic_Pipe_Juntion), 
				typeof(RcdSchematic_Pipe_HeatExchanger), 
				typeof(RcdSchematic_Pipe_Insulated), 
				typeof(RcdSchematic_Pipe_InsulatedBent), 
				typeof(RcdSchematic_Pipe_InsulatedManifold), 
				typeof(RcdSchematic_Pipe_Insulated4wManifold), 
				typeof(RcdSchematic_Pipe_Disposal), 
				typeof(RcdSchematic_Pipe_Disposal_Bent), 
				typeof(RcdSchematic_Pipe_Disposal_Junction), 
				typeof(RcdSchematic_Pipe_Disposal_YJunction), 
				typeof(RcdSchematic_Pipe_Disposal_Trunk), 
				typeof(RcdSchematic_Pipe_Disposal_Bin), 
				typeof(RcdSchematic_Pipe_Disposal_Outlet), 
				typeof(RcdSchematic_Pipe_Disposal_Chute), 
				typeof(RcdSchematic_Pipe_Disposal_Sort), 
				typeof(RcdSchematic_Pipe_Disposal_SortWrap)
			 });
			this.icon_state = "rpd";
		}

		public Obj_Item_Device_Rcd_Rpd ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: RPD.dm
		public override void rebuild_ui(  ) {
			string dat = null;
			dynamic cat = null;
			ByTable L = null;
			double i = 0;
			dynamic C = null;

			dat = "";
			dat += @"
	<b>Selected:</b> <span id=""selectedname""></span>
	<h2>Options</h2>
	<div id=""schematic_options"">
	</div>
	<h2>Available schematics</h2>
	";

			foreach (dynamic _b in Lang13.Enumerate( this.schematics )) {
				cat = _b;
				
				dat += "<b>" + cat + ":</b><ul style='list-style-type:disc'>";
				L = this.schematics[cat];

				foreach (dynamic _a in Lang13.IterateRange( 1, L.len )) {
					i = _a;
					
					C = L[i];
					dat += new Txt( "<li><a href='?src=" ).Ref( this.v_interface ).str( ";cat=" ).item( cat ).str( ";index=" ).item( i ).str( "'>" ).item( C.name ).str( "</a></li>" ).ToString();
				}
				dat += "</ul>";
			}
			this.v_interface.updateLayout( dat );

			if ( this.selected != null ) {
				this.update_options_menu();
				this.v_interface.updateContent( "selectedname", this.selected.name );
			}
			return;
		}

	}

}