import moment from 'moment';
import { getTransactionPurchases } from '@/app/lib/data';
import { formatCurrency } from '@/app/lib/utils';

export default async function TransactionsPurchasesTable() {
  const purchases = await getTransactionPurchases("123456789012");  
  
  return (
    <div className="w-full">
      <h1 className=' mb-8 text-xl md:text-2xl'>
        Transacciones
      </h1>      
      <div className="mt-6 flow-root">
        <div className="overflow-x-auto">
          <div className="inline-block min-w-full align-middle">
            <div className="overflow-hidden rounded-md bg-gray-50 p-2 md:pt-0">              
              <table className="hidden min-w-full rounded-md text-gray-900 md:table">
                <thead className="rounded-md bg-gray-50 text-left text-sm font-normal">
                  <tr>
                    <th scope="col" className="px-4 py-5 font-medium sm:pl-6">
                      Fecha
                    </th>
                    <th scope="col" className="px-3 py-5 font-medium">
                      Tipo
                    </th>
                    <th scope="col" className="px-3 py-5 font-medium">
                      Descripcion
                    </th>                    
                    <th scope="col" className="px-3 py-5 font-medium">
                      Monto
                    </th>                    
                  </tr>
                </thead>

                <tbody className="divide-y divide-gray-200 text-gray-900">
                  {purchases.value.map((purchase, i) => (
                    <tr key={i} className="group">                      
                      <td className="whitespace-nowrap bg-white px-4 py-5 text-sm">
                        { moment(purchase.paymentDate).format("DD-MM-YYYY HH:mm:ss") } 
                      </td>
                      <td className="whitespace-nowrap bg-white px-4 py-5 text-sm">
                        { purchase.transactionType }
                      </td>
                      <td className="whitespace-nowrap bg-white px-4 py-5 text-sm">
                        { purchase.description }
                      </td>
                      <td className="whitespace-nowrap bg-white px-4 py-5 text-sm group-first-of-type:rounded-md group-last-of-type:rounded-md">
                        {  formatCurrency( purchase.amount ) }
                      </td>
                    </tr>
                  ))}
                </tbody>
              </table>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}
