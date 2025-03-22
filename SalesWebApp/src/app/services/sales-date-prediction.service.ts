import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ResponseMdl,SalesDatePrediction } from '../models/response-mdl';

@Injectable({
    providedIn: 'root'
})
export class SalesDatePredictionService {
    constructor(private http: HttpClient) { }

    getSaleDatePredictions() {
        return this.http.get<ResponseMdl<SalesDatePrediction[]>>('https://localhost:7283/api/sales/sales-date-prediction');
    }

    getSaleDatePredictionsByWord(word:string) {
        return this.http.get<ResponseMdl<SalesDatePrediction[]>>('https://localhost:7283/api/sales/sales-date-prediction/'+word);
    }
}
