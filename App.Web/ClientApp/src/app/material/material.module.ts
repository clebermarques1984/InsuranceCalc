import { NgModule } from "@angular/core";
import * as Material from "@angular/material";
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";

const mats = [
	Material.MatToolbarModule,
	Material.MatButtonModule,
	Material.MatSidenavModule,
	Material.MatIconModule,
	Material.MatListModule,
	Material.MatCardModule,
	Material.MatTableModule,
	Material.MatInputModule,
	Material.MatButtonModule,
	Material.MatSelectModule,
	Material.MatRadioModule,
	Material.MatCardModule,
	Material.MatSnackBarModule,
	Material.MatDialogModule,
	Material.MatRippleModule,
	Material.MatGridListModule,
	Material.MatPaginatorModule,
	Material.MatSortModule
];

@NgModule({
	imports: [mats],
	exports: [mats]
})
export class MaterialModule {}
