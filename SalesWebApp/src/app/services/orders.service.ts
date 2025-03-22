import { Injectable } from '@angular/core';
import { ResponseMdl } from '../models/response-mdl';
import { OrderMdl } from '../models/order-mdl';
import { HttpClient } from '@angular/common/http';
import { BASE_URL, CLIENT_ORDERS } from '../constants/constants';

@Injectable({
  providedIn: 'root'
})
export class OrdersService {

    constructor(private readonly http: HttpClient) { }

    getOrders(customerId:number) {
        return this.http.get<ResponseMdl<OrderMdl[]>>(BASE_URL + CLIENT_ORDERS + '/'+customerId);
    }
}
