import { getDetailsCard } from "@/app/lib/data";
import { formatCurrency } from "@/app/lib/utils";
import { Button } from "../button";
import AccountStatementToPDF from "../transaction-history/account-statement";
import PurchaseToExcel from "../purchases/purchase-to-excel";

export default async function DetailsCard() {
  const details = await getDetailsCard("123456789012");
  return (
    <div className="flex w-full flex-col md:col-span-4">
      <h2 className={`text-xl md:text-2xl`}>
        Detalle tarjeta
      </h2>  
      <h3 className={`text-xl`}>
        Nombre: { details.value.name }       
      </h3>
      <p>Numero de tarjeta: { details.value.cardNumber }</p>       
      <div className="flex grow flex-col justify-between rounded-xl bg-gray-50 p-2">
        <div className="bg-white px-2">                          
              <div className='flex flex-row  justify-between py-4 border-t'>
                <div className="flex justify-between">
                  <div className="min-w-0 justify-between">
                    <p className="truncate text-sm font-semibold md:text-base">
                      Saldo actual: <span className="font-normal">
                        { formatCurrency( details.value.currentBalance  )}
                      </span>
                    </p>
                    <p className="truncate text-sm font-semibold md:text-base">
                      Límite: <span className="font-normal">
                        { formatCurrency( details.value.limit ) }
                      </span>
                    </p>
                    <p className="truncate text-sm font-semibold md:text-base">
                      Saldo disponible: <span className="font-normal">
                        { formatCurrency( details.value.availableBalance ) }
                      </span>
                    </p>
                    <p className="truncate text-sm font-semibold md:text-base">
                      Interés bonificable: <span className="font-normal">
                        { formatCurrency( details.value.bonusableInterets ) }
                      </span>
                    </p>
                  </div>                  
                </div>
                <div className="flex justify-between">
                  <div className="min-w-0 justify-between">
                    <p className="truncate text-sm font-semibold md:text-base">
                      Cuota Mínima: <span className="font-normal">
                        { formatCurrency( details.value.minPaymentDue ) }
                      </span>
                    </p>
                    <p className="truncate text-sm font-semibold md:text-base">
                      Monto Total a Pagar: <span className="font-normal">
                        { formatCurrency( details.value.currentBalance )}
                      </span>
                    </p>
                    <p className="truncate text-sm font-semibold md:text-base">
                      Monto total de contado con intereses: <span className="font-normal">
                        { formatCurrency( details.value.paymentWithInterest ) }
                      </span>
                    </p>
                  </div>
                </div>
                <div className="flex flex-col justify-between">
                  <div>
                    <AccountStatementToPDF />
                  </div>
                  <div>
                    <PurchaseToExcel />                
                  </div>                  
                </div>
              </div>
   
        </div>
        
      </div>
    </div>
  )
}