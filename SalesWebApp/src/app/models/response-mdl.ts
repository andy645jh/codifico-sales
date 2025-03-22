export class ResponseMdl<T> {
    data: T;
    success: boolean;
    message: string;
    error: string;
    errorMessages: string[];
}

export class SalesDatePrediction {
    custId: number;
    customerName: string;
    lastOrderDate: Date;
    nextPredictedOrder: Date;
}