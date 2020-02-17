import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { HomeComponent } from "./home/home.component";
//import { NotFoundComponent } from './core';

const routes: Routes = [
	{ path: "", pathMatch: "full", redirectTo: "home" },
	{
		path: "client",
		loadChildren: () =>
			import("./clients/client.module").then(m => m.ClientModule)
	},
	{ path: "home", component: HomeComponent }
	//{ path: '**', component: NotFoundComponent }
];

@NgModule({
	imports: [RouterModule.forRoot(routes)],
	exports: [RouterModule]
})
export class AppRoutingModule {}
