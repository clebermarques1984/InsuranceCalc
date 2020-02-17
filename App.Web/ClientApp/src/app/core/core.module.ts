import { CommonModule } from "@angular/common";
import { NgModule } from "@angular/core";
import { RouterModule } from "@angular/router";
import { AppNavComponent } from "./app-nav/app-nav.component";
import { MaterialModule } from "../material/material.module";

const components = [AppNavComponent];

@NgModule({
	imports: [
		CommonModule,
		MaterialModule,
		RouterModule // because it use routerLink
	],
	exports: [components],
	declarations: [components]
})
export class CoreModule {}
