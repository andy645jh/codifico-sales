import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-orders-modal-component',
  standalone: true,
  imports: [],
  templateUrl: './orders-modal.component.html',
  styleUrl: './orders-modal.component.css'
})

export class OrdersModalComponent implements OnInit{
  constructor(public dialogRef: MatDialogRef<OrdersModalComponent>,
    @Inject(MAT_DIALOG_DATA) public data: number) {

  }

  ngOnInit(): void {
    console.log("Data", this.data);
  }

  onNoClick(): void{
    this.dialogRef.close();
  }
}
