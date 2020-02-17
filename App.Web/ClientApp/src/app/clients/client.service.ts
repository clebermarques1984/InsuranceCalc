import { Injectable } from "@angular/core";
import {
	EntityCollectionServiceBase,
	EntityCollectionServiceElementsFactory
} from "@ngrx/data";
import { FormGroup, FormControl, Validators } from "@angular/forms";
import { Client } from "../core";

@Injectable({ providedIn: "root" })
export class ClientService extends EntityCollectionServiceBase<Client> {
	constructor(serviceElementsFactory: EntityCollectionServiceElementsFactory) {
		super("Client", serviceElementsFactory);
	}

	public form: FormGroup = new FormGroup({
		id: new FormControl(null),
		nome: new FormControl("", Validators.required),
		idade: new FormControl(0),
		cpf: new FormControl("", Validators.required)
	});

	public initializeFormGroup() {
		this.form.setValue({
			id: null,
			nome: "",
			idade: 0,
			cpf: ""
		});
		this.form.reset();
	}
}
