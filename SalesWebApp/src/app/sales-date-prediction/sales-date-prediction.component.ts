import { Component, OnInit, ViewChild } from '@angular/core';
import { SalesDatePredictionService } from '../services/sales-date-prediction.service';
import { CommonModule } from '@angular/common';
import { MatPaginator, MatPaginatorModule, MatPaginatorIntl, MatPaginatorSelectConfig } from '@angular/material/paginator';
import { MatTableModule, MatTableDataSource } from '@angular/material/table';
import { SalesDatePredictionMdl } from '../models/sales-date-prediction-mdl';
import { MatSort, MatSortModule } from '@angular/material/sort';
import { debounceTime, Subject, Subscription } from 'rxjs';
import { MatIconModule } from '@angular/material/icon';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { OrdersModalComponent } from '../orders-modal-component/orders-modal.component';
import { ROWS_PER_PAGE } from '../constants/constants';
import { OrderDialogDataMdl } from '../models/order-dialog-data-mdl';

@Component({
    selector: 'app-sales-date-prediction',
    standalone: true,
    imports: [MatDialogModule, CommonModule, MatPaginatorModule, MatTableModule, MatSortModule, MatIconModule],
    templateUrl: './sales-date-prediction.component.html',
    styleUrl: './sales-date-prediction.component.css'
})

export class SalesDatePredictionComponent implements OnInit {

    dataSource: MatTableDataSource<SalesDatePredictionMdl>;
    displayedColumns: string[] = ['customerName', 'lastOrderDate', 'nextPredictedOrder', 'option1', 'option2'];
    private readonly customPaginatorIntl = new MatPaginatorIntl();
    private subscription: Subscription;
    private readonly modelChanged: Subject<string> = new Subject<string>();
    private readonly debounceTime = 500;

    @ViewChild(MatPaginator, { static: true }) paginator!: MatPaginator;
    @ViewChild(MatSort) sort: MatSort;

    constructor(public dialog: MatDialog, private readonly salesService: SalesDatePredictionService, private paginatorInt: MatPaginatorIntl) {
        paginatorInt.itemsPerPageLabel = ROWS_PER_PAGE;
    }

    openDialog(dialogData: OrderDialogDataMdl) {
        this.dialog.open(OrdersModalComponent, { data: dialogData });
    }

    ngOnInit(): void {
        this.salesService.getSaleDatePredictions().subscribe(response => {
            this.setTableData(response.data);
            this.customPaginatorIntl.itemsPerPageLabel = ROWS_PER_PAGE;
        });

        this.subscription = this.modelChanged
            .pipe(debounceTime(this.debounceTime),).subscribe((value) => {

                this.salesService.getSaleDatePredictionsByWord(value).subscribe(response => {
                    this.setTableData(response.data);
                });
            });
    }

    setTableData(data: SalesDatePredictionMdl[]) {
        this.dataSource = new MatTableDataSource(data);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
    }

    onClickViewOrders(custId: number, customerName: string) {
        console.log("View Order: " + custId);
        this.openDialog({ custId: custId, customerName: customerName });
    }

    onClickNewOrder(custId: number) {
        console.log("New Order: " + custId);
    }

    searchKey(event: Event) {
        const data = (event.target as HTMLInputElement).value;
        this.modelChanged.next(data);
    }

    ngOnDestroy(): void {
        this.subscription.unsubscribe();
    }
}


