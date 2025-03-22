import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { SalesDatePredictionComponent } from "./sales-date-prediction/sales-date-prediction.component";

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, SalesDatePredictionComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'SalesWebApp';
}
