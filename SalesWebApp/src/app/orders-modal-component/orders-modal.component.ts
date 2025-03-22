import { Component, Inject, OnInit, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MAT_DIALOG_DATA, MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { OrdersService } from '../services/orders.service';
import { OrderMdl } from '../models/order-mdl';
import { MatPaginator, MatPaginatorIntl, MatPaginatorModule } from '@angular/material/paginator';
import { MatSort, MatSortModule } from '@angular/material/sort';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { ROWS_PER_PAGE } from '../constants/constants';
import { MatIconModule } from '@angular/material/icon';
import { OrderDialogDataMdl } from '../models/order-dialog-data-mdl';

@Component({
    selector: 'app-orders-modal-component',
    standalone: true,
    imports: [CommonModule, MatDialogModule, MatPaginatorModule,MatTableModule,MatSortModule,MatIconModule],
    templateUrl: './orders-modal.component.html',
    styleUrl: './orders-modal.component.css'
})

export class OrdersModalComponent implements OnInit {
    orders: MatTableDataSource<OrderMdl>;

    displayedColumns: string[] = ['orderId','requiredDate','shippedDate','shipName','shipAddress', 'shipCity'];
    private readonly customPaginatorIntl = new MatPaginatorIntl();


    @ViewChild(MatPaginator, { static: true }) paginator!: MatPaginator;
    @ViewChild(MatSort) sort: MatSort;

    constructor(private readonly ordersService: OrdersService,
        private paginatorInt: MatPaginatorIntl,
        public dialogRef: MatDialogRef<OrdersModalComponent>,
        @Inject(MAT_DIALOG_DATA) public data: OrderDialogDataMdl) {

        paginatorInt.itemsPerPageLabel = ROWS_PER_PAGE;
    }

    ngOnInit(): void {

        this.ordersService.getOrders(this.data.custId).subscribe(response => {
            this.orders = new MatTableDataSource(response.data);
            this.orders.paginator = this.paginator;
            this.orders.sort = this.sort;

            this.customPaginatorIntl.itemsPerPageLabel = ROWS_PER_PAGE;
        });
    }

    onCloseClick(): void {
        this.dialogRef.close();
    }
}

