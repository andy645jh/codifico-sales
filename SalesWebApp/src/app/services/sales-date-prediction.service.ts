import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ResponseMdl } from '../models/response-mdl';
import { SalesDatePredictionMdl } from '../models/sales-date-prediction-mdl';
import { BASE_URL, SALES_DATE_PREDICTION } from '../constants/constants';

@Injectable({
    providedIn: 'root'
})
export class SalesDatePredictionService {
    constructor(private readonly http: HttpClient) { }

    getSaleDatePredictions() {
        return this.http.get<ResponseMdl<SalesDatePredictionMdl[]>>(BASE_URL + SALES_DATE_PREDICTION);
    }

    getSaleDatePredictionsByWord(word:string) {
        return this.http.get<ResponseMdl<SalesDatePredictionMdl[]>>(BASE_URL + SALES_DATE_PREDICTION + '/' + word);
    }
}
