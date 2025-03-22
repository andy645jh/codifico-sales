import { Component, model, OnInit, ViewChild } from '@angular/core';
import { SalesDatePredictionService } from '../services/sales-date-prediction.service';
import { CommonModule } from '@angular/common';
import { MatPaginator,MatPaginatorModule, MatPaginatorIntl, MatPaginatorSelectConfig } from '@angular/material/paginator';
import { MatTableModule, MatTableDataSource  } from '@angular/material/table';
import { SalesDatePrediction } from '../models/response-mdl';
import { MatSort, Sort, MatSortModule } from '@angular/material/sort';
import { debounceTime, Subject, Subscription } from 'rxjs';
import { MatIconModule } from '@angular/material/icon';
import { MatDialog, MatDialogRef, MatDialogModule } from '@angular/material/dialog';
import { OrdersModalComponent } from '../orders-modal-component/orders-modal.component';

@Component({
    selector: 'app-sales-date-prediction',
    standalone: true,
    imports: [MatDialogModule, CommonModule, MatPaginatorModule, MatTableModule,MatSortModule,MatIconModule ],
    templateUrl: './sales-date-prediction.component.html',
    styleUrl: './sales-date-prediction.component.css'
})

export class SalesDatePredictionComponent implements OnInit {

    dataSource: MatTableDataSource<SalesDatePrediction>;
    displayedColumns: string[] = ['customerName', 'lastOrderDate', 'nextPredictedOrder', 'option1', 'option2'];
    private readonly customPaginatorIntl = new MatPaginatorIntl();
    private subscription: Subscription;
    private readonly modelChanged: Subject<string> = new Subject<string>();
    private readonly debounceTime = 500;

    @ViewChild(MatPaginator, { static: true }) paginator!: MatPaginator;
    @ViewChild(MatSort) sort: MatSort;

    constructor(public dialog: MatDialog, private readonly salesService: SalesDatePredictionService, private paginatorInt: MatPaginatorIntl) {
        paginatorInt.itemsPerPageLabel = "Rows per page:";
     }

    openDialog(custId:number) {
        this.dialog.open(OrdersModalComponent, { width: '250px', data: custId });
    }

    ngOnInit(): void {
        this.salesService.getSaleDatePredictions().subscribe(response => {
            this.dataSource = new MatTableDataSource(response.data);
            this.dataSource.paginator = this.paginator;
            this.dataSource.sort = this.sort;

            this.customPaginatorIntl.itemsPerPageLabel = 'Rows per page:';
        });

        this.subscription = this.modelChanged
            .pipe(debounceTime(this.debounceTime),).subscribe((value) => {

                this.salesService.getSaleDatePredictionsByWord(value).subscribe(response => {
                    this.dataSource = new MatTableDataSource(response.data);
                    this.dataSource.paginator = this.paginator;
                    this.dataSource.sort = this.sort;
                });
            });
    }

    onClickViewOrders(custId: number) {
        console.log("View Order: " + custId);
        this.openDialog(custId);
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


