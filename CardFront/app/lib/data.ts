
import { 
  AccountStatementResponse, 
  BaseResponse, 
  CreatePaymentResponse, 
  CreatePurchaseResponse, 
  DetailsResponse, 
  HistoryResponse, 
  Payment, 
  Purchase, 
  PurchaseResponse, 
  PurchaseToExcelResponse } from './definitions';

const BASE_URL = "http://localhost:5044/api/v1";

export async function getDetailsCard(cardNumber: string): Promise<BaseResponse<DetailsResponse>> {
  const res = await fetch(`${ BASE_URL }/details/${ cardNumber }`, { cache: 'no-cache' });
  const json = await res.json();

  return json;
}

export async function getTransactionPurchases(cardNumber: string): Promise<BaseResponse<PurchaseResponse[]>> {
  const month = new Date().getMonth();
  const res = await fetch(`http://localhost:5044/api/v1/transactions/purchase/${ cardNumber }?Month=${ month + 1 }`, { cache: 'no-cache' });
  const json = await res.json();

  return json;
}

export async function getTransactionHistory(cardNumber: string): Promise<BaseResponse<HistoryResponse[]>> {
  const month = new Date().getMonth();
  const res = await fetch(`http://localhost:5044/api/v1/transactions/history/${ cardNumber }?Month=${ month + 1 }`, { cache: 'no-cache' });
  const json = await res.json();

  console.log(json);

  return json;
}

export async function getAccountStatement(cardNumber: string): Promise<BaseResponse<AccountStatementResponse>> {
  const month = new Date().getMonth();
  const res = await fetch(`${ BASE_URL }/transactions/accountstatement/${ cardNumber }?Month=${ month + 1 }`, { cache: 'no-cache' });
  const json = await res.json();

  return json;
}

export async function getPurchaseToExcel(cardNumber: string): Promise<BaseResponse<PurchaseToExcelResponse>> {
  const month = new Date().getMonth();
  const res = await fetch(`${ BASE_URL }/transactions/purchase-to-excel/${ cardNumber }?Month=${ month + 1 }`, { cache: 'no-cache' });
  const json = await res.json();

  return json;
}

export async function addPurchase(purchase: Purchase): Promise<BaseResponse<CreatePurchaseResponse>> {
  const body = JSON.stringify(purchase);
  const res = await fetch(`${ BASE_URL }/transactions/purchase`, { 
    cache: 'no-cache', 
    method: 'POST', 
    body: body, 
    headers: { 'Content-Type': 'application/json' } 
  });
  const json = await res.json();
  return json;
}

export async function addPayment(payment: Payment): Promise<BaseResponse<CreatePaymentResponse>> {
  const body = JSON.stringify(payment);
  const res = await fetch(`${ BASE_URL }/transactions/payment`, { 
    cache: 'no-cache', 
    method: 'POST', 
    body: body, 
    headers: { 'Content-Type': 'application/json' } 
  });
  const json = await res.json();
  return json;
}



