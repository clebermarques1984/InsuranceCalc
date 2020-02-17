import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { NotificationService } from "./notification.service";
// import { FormsModule, ReactiveFormsModule } from "@angular/forms";
// import { ListHeaderComponent } from './list-header.component';
// import { CardContentComponent } from './card-content.component';
// import { ButtonFooterComponent } from './button-footer.component';
// import { ModalComponent } from './modal.component';

const components = [
	//   ModalComponent
];

const providers = [];

@NgModule({
	imports: [CommonModule], // FormsModule, ReactiveFormsModule],
	declarations: [components],
	providers: [providers],
	exports: [components, providers] // FormsModule, ReactiveFormsModule]
})
export class SharedModule {}
