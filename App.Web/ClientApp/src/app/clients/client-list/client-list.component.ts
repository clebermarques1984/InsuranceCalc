import { Component, OnInit, ViewChild } from "@angular/core";
import {
	MatDialog,
	MatPaginator,
	MatSort,
	MatTableDataSource,
	MatDialogConfig
} from "@angular/material";
import { Observable } from "rxjs";
//Components
import { ClientDetailComponent } from "../client-detail/client-detail.component";
//Services
import { NotificationService } from "../../shared/notification.service";
import { Client } from "../../core";
import { ClientService } from "../client.service";

@Component({
	selector: "app-client-list",
	templateUrl: "./client-list.component.html",
	styleUrls: ["./client-list.component.css"]
})
export class ClientListComponent implements OnInit {
	selected: Client;
	clients$: Observable<Client[]>;
	@ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
	@ViewChild(MatSort, { static: true }) sort: MatSort;
	listData: MatTableDataSource<Client>;
	searchKey: string;
	displayedColumns: string[] = ["nome", "idade", "cpf", "actions"];

	constructor(
		private notificationService: NotificationService,
		private dialog: MatDialog,
		private service: ClientService
	) {
		this.clients$ = this.service.entities$;
	}

	ngOnInit() {
		this.getClients();
		this.clients$.subscribe(data => {
			this.listData = new MatTableDataSource(data);
			this.listData.sort = this.sort;
			this.listData.paginator = this.paginator;
			this.listData.filterPredicate = (data, filter) => {
				return this.displayedColumns.some(ele => {
					return (
						ele != "actions" && data[ele].toLowerCase().indexOf(filter) != -1
					);
				});
			};
		});
	}

	getClients() {
		this.service.getAll();
		this.Clear();
	}

	Clear() {
		this.selected = null;
	}

	onSearchClear() {
		this.searchKey = "";
		this.applyFilter();
	}

	applyFilter() {
		this.listData.filter = this.searchKey.trim().toLowerCase();
	}

	onCreate() {
		this.service.initializeFormGroup();
		this.openDialog();
	}

	onDelete(client: Client) {
		this.service.delete(client.id);
		this.notificationService.success(":: Cliente excluído com sucesso");
	}

	onEdit(row: Client) {
		this.service.form.patchValue(row);
		this.openDialog();
	}

	openDialog() {
		const dialogConfig = new MatDialogConfig();
		dialogConfig.disableClose = true;
		dialogConfig.autoFocus = true;
		dialogConfig.width = "60%";
		this.dialog.open(ClientDetailComponent, dialogConfig);
	}
}
