import { NgModule } from "@angular/core";
import { EffectsModule } from "@ngrx/effects";
import { StoreModule } from "@ngrx/store";
import { StoreDevtoolsModule } from "@ngrx/store-devtools";
import { environment } from "../../environments/environment";
import { defaultDataServiceConfig } from "./config";
import { DefaultDataServiceConfig, EntityDataModule } from "@ngrx/data";
import { entityConfig } from "./entity-metadata";

@NgModule({
	imports: [
		StoreModule.forRoot({}),
		EffectsModule.forRoot([]),
		environment.production ? [] : StoreDevtoolsModule.instrument(),
		EntityDataModule.forRoot(entityConfig)
	],
	providers: [
		{ provide: DefaultDataServiceConfig, useValue: defaultDataServiceConfig }
	]
})
export class AppStoreModule {}
