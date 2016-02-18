// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Job_CargoTech : Job {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.title = "Cargo Technician";
			this.flag = 128;
			this.department_head = new ByTable(new object [] { "Head of Personnel" });
			this.department_flag = 4;
			this.faction = "Station";
			this.total_positions = 3;
			this.spawn_positions = 2;
			this.supervisors = "the quartermaster and the head of personnel";
			this.selection_color = "#dcba97";
			this.outfit = typeof(Outfit_Job_CargoTech);
			this.access = new ByTable(new object [] { 12, 50, 31, 34, 41, 48, 54, 64 });
			this.minimal_access = new ByTable(new object [] { 12, 31, 34, 50, 64 });
		}

	}

}