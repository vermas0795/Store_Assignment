import { BaseModel } from './base.model';

export class EstimationLogs extends BaseModel {
    appUserId :number;
    discount :number;
    pricePerGram :number;
    weight :number;
    totalPrice:number; 
}
