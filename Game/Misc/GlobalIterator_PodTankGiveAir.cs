// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class GlobalIterator_PodTankGiveAir : GlobalIterator {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.delay = 15;
		}

		public GlobalIterator_PodTankGiveAir ( ByTable arguments = null, bool? autostart = null ) : base( arguments, autostart ) {
			
		}

		// Function from file: spacepods.dm
		public override bool process( Obj port = null, dynamic mecha = null ) {
			GasMixture tank_air = null;
			GasMixture cabin_air = null;
			double release_pressure = 0;
			dynamic cabin_pressure = null;
			dynamic pressure_delta = null;
			dynamic transfer_moles = null;
			GasMixture removed = null;
			GasMixture t_air = null;
			GasMixture removed2 = null;

			
			if ( Lang13.Bool( ((dynamic)port).internal_tank ) ) {
				tank_air = ((Ent_Static)((dynamic)port).internal_tank).return_air();
				cabin_air = ((dynamic)port).cabin_air;
				release_pressure = 101.32499694824219;
				cabin_pressure = cabin_air.return_pressure();
				pressure_delta = Num13.MinInt( ((int)( release_pressure - Convert.ToDouble( cabin_pressure ) )), Convert.ToInt32( ( tank_air.return_pressure() - cabin_pressure ) / 2 ) );
				transfer_moles = 0;

				if ( Convert.ToDouble( pressure_delta ) > 0 ) {
					
					if ( ( tank_air.return_temperature() ??0) > 0 ) {
						transfer_moles = pressure_delta * cabin_air.return_volume() / ( ( cabin_air.return_temperature() ??0) * 8.314 );
						removed = tank_air.remove( transfer_moles );
						cabin_air.merge( removed );
					}
				} else if ( Convert.ToDouble( pressure_delta ) < 0 ) {
					t_air = ((Obj_Spacepod)port).get_turf_air();
					pressure_delta = cabin_pressure - release_pressure;

					if ( t_air != null ) {
						pressure_delta = Num13.MinInt( Convert.ToInt32( cabin_pressure - t_air.return_pressure() ), Convert.ToInt32( pressure_delta ) );
					}

					if ( Convert.ToDouble( pressure_delta ) > 0 ) {
						transfer_moles = pressure_delta * cabin_air.return_volume() / ( ( cabin_air.return_temperature() ??0) * 8.314 );
						removed2 = cabin_air.remove( transfer_moles );

						if ( t_air != null ) {
							t_air.merge( removed2 );
						} else {
							Lang13.Delete( removed2 );
							removed2 = null;
						}
					}
				}
			} else {
				return this.stop();
			}
			return false;
		}

	}

}