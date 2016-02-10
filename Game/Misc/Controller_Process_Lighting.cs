// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Controller_Process_Lighting : Controller_Process {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.schedule_interval = 5;
		}

		public Controller_Process_Lighting ( dynamic scheduler = null ) : base( (object)(scheduler) ) {
			
		}

		// Function from file: lighting.dm
		public override bool doWork(  ) {
			bool _default = false;

			int light_updates = 0;
			int overlay_updates = 0;
			ByTable lighting_update_lights_old = null;
			LightSource L = null;
			ByTable lighting_update_overlays_old = null;
			Dynamic_LightingOverlay O = null;

			light_updates = 0;
			overlay_updates = 0;
			lighting_update_lights_old = GlobalVars.lighting_update_lights;
			GlobalVars.lighting_update_lights = new ByTable();

			foreach (dynamic _a in Lang13.Enumerate( lighting_update_lights_old, typeof(LightSource) )) {
				L = _a;
				

				if ( light_updates >= 100 ) {
					GlobalVars.lighting_update_lights.Add( L );
					continue;
				}
				_default = L.check();

				if ( L.destroyed || _default || L.force_update ) {
					L.remove_lum();

					if ( !L.destroyed ) {
						L.apply_lum();
					}
				} else if ( L.vis_update ) {
					L.smart_vis_update();
				}
				L.vis_update = false;
				L.force_update = false;
				L.needs_update = false;
				light_updates++;
				this.scheck();
			}
			lighting_update_overlays_old = GlobalVars.lighting_update_overlays;
			GlobalVars.lighting_update_overlays = new ByTable();

			foreach (dynamic _b in Lang13.Enumerate( lighting_update_overlays_old, typeof(Dynamic_LightingOverlay) )) {
				O = _b;
				

				if ( overlay_updates >= 1000 ) {
					GlobalVars.lighting_update_overlays.Add( O );
					continue;
				}
				O.update_overlay();
				O.needs_update = false;
				overlay_updates++;
				this.scheck();
			}
			return _default;
		}

		// Function from file: lighting.dm
		public override void setup(  ) {
			this.name = "lighting";
			GlobalFuncs.create_lighting_overlays();
			return;
		}

	}

}