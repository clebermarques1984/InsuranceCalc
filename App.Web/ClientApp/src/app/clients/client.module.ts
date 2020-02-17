import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { ClientDetailComponent } from "./client-detail/client-detail.component";
import { ClientListComponent } from "./client-list/client-list.component";
import { Routes, RouterModule } from "@angular/router";
import { SharedModule } from "../shared/shared.module";
import { MaterialModule } from "../material/material.module";

const components = [ClientDetailComponent, ClientListComponent];

const routes: Routes = [
	{
		path: "",
		component: ClientListComponent
	}
];

@NgModule({
	imports: [
		CommonModule,
		RouterModule.forChild(routes),
		SharedModule,
		FormsModule,
		MaterialModule,
		ReactiveFormsModule
	],
	declarations: [components],
	entryComponents: [ClientDetailComponent],
	exports: [components, RouterModule, FormsModule, ReactiveFormsModule]
})
export class ClientModule {}
