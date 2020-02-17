import { EntityMetadataMap, EntityDataModuleConfig } from "@ngrx/data";
//import { EntityMetadataMap } from "@ngrx/data";

const entityMetadata: EntityMetadataMap = {
	Client: {}
};

// because the plural of "hero" is not "heros"
const pluralNames = {};

export const entityConfig: EntityDataModuleConfig = {
	entityMetadata,
	pluralNames
};
