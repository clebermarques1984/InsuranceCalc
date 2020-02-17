import { BrowserModule } from "@angular/platform-browser";
import { HttpClientModule } from "@angular/common/http";
import { NgModule } from "@angular/core";
import { LayoutModule } from "@angular/cdk/layout";
import { EntityDataModule } from "@ngrx/data";

import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";
import { CoreModule } from "./core/core.module";
import { AppStoreModule } from "./store/store.module";
import { MaterialModule } from "./material/material.module";
import { HomeComponent } from "./home/home.component";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";

@NgModule({
	declarations: [AppComponent, HomeComponent],
	imports: [
		BrowserModule,
		BrowserAnimationsModule,
		HttpClientModule,
		LayoutModule,
		MaterialModule,
		CoreModule,
		AppRoutingModule,
		AppStoreModule,
		EntityDataModule
	],
	providers: [],
	bootstrap: [AppComponent]
})
export class AppModule {}
