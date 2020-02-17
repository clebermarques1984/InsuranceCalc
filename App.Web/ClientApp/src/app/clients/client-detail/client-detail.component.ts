import { Component, OnInit, Inject } from "@angular/core";
import { MatDialogRef } from "@angular/material";

import { Client } from "../../core";
import { NotificationService } from "../../shared/notification.service";
import { ClientService } from "../client.service";

@Component({
	selector: "app-client-detail",
	templateUrl: "./client-detail.component.html",
	styleUrls: ["./client-detail.component.css"]
})
export class ClientDetailComponent implements OnInit {
	constructor(
		private notificationService: NotificationService,
		public dialogRef: MatDialogRef<ClientDetailComponent>,
		private service: ClientService
	) {}

	ngOnInit() {}

	onSubmit() {
		if (this.service.form.valid) {
			let client: Client = this.service.form.value;
			if (!client.id) {
				console.log(client);
				this.service.add(client);
				this.showSuccessNotification(":: Cliente cadastrado com sucesso");
			} else {
				console.log(client);
				this.service.update(client);
				this.showSuccessNotification(":: Cliente atualizado com sucesso");
			}
		}
	}

	onClear() {
		this.service.initializeFormGroup();
	}

	onClose() {
		this.service.initializeFormGroup();
		this.dialogRef.close();
	}

	showSuccessNotification(message: string) {
		this.onClose();
		this.notificationService.success(message);
	}

	handleError(error: any) {
		this.notificationService.warn(`:: ${error}`);
	}
}
