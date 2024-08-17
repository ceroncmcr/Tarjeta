
export interface BaseResponse<T>{
  statusCode: number;
  contentType: string;
  value: T
}

export interface DetailsResponse {
  name: string;
  cardNumber: string;
  currentBalance: number;
  limit: number;
  availableBalance: number;
  bonusableInterets: number;
  minPaymentDue: number;
  paymentWithInterest: number;
}

export interface PurchaseResponse{
  cardNumber: string;
  paymentDate: Date;
  transactionType: string;
  amount: number;
  description: string;
}

export interface HistoryResponse{
  cardNumber: string;
  paymentDate: Date;
  transactionType: string;
  amount: number;
  description: string;
}

export interface CreatePurchaseResponse{
  id: number;
}

export interface CreatePaymentResponse{
  id: number;
}

export interface AccountStatementResponse{
  b64: string;
}

export interface PurchaseToExcelResponse{
  b64: string;
}

export interface Purchase{
  cardNumber: string;
  paymentDate: string;  
  amount: number;
  description: string;
}

export interface Payment{
  cardNumber: string;
  paymentDate: string;  
  amount: number;  
}