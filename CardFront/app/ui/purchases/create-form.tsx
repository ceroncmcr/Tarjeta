
import Link from 'next/link';
import {
  CalendarDaysIcon,    
  CurrencyDollarIcon,
  PencilSquareIcon,  
} from '@heroicons/react/24/outline';
import { Button } from '@/app/ui/button';


export default function CreatePurchaseForm() {
  return (
    <div className='w-full'>
      <h1 className=' mb-8 text-xl md:text-2xl'>
        Agregar compra
      </h1> 
      <form>
        <div className="rounded-md bg-gray-50 p-4 md:p-6">

          <div className="mb-4">
            <label htmlFor="amount" className="mb-2 block text-sm font-medium">
              Monto
            </label>
            <div className="relative mt-2 rounded-md">
              <div className="relative">
                <input
                  id="amount"
                  name="amount"
                  type="number"
                  step="0.01"
                  placeholder="Ingrese el monto"
                  className="peer block w-full rounded-md border border-gray-200 py-2 pl-10 text-sm outline-2 placeholder:text-gray-500"
                />
                <CurrencyDollarIcon className="pointer-events-none absolute left-3 top-1/2 h-[18px] w-[18px] -translate-y-1/2 text-gray-500 peer-focus:text-gray-900" />
              </div>
            </div>
          </div>
          
          <div className="mb-4">
            <label htmlFor="amount" className="mb-2 block text-sm font-medium">
              Fecha
            </label>
            <div className="relative mt-2 rounded-md">
              <div className="relative">
                <input
                  id="amount"
                  name="amount"
                  type="date"
                  step="0.01"
                  placeholder="Enter USD amount"
                  className="peer block w-full rounded-md border border-gray-200 py-2 pl-10 text-sm outline-2 placeholder:text-gray-500"
                />
                <CalendarDaysIcon className="pointer-events-none absolute left-3 top-1/2 h-[18px] w-[18px] -translate-y-1/2 text-gray-500 peer-focus:text-gray-900" />
              </div>
            </div>
          </div>

          <div className="mb-4">
            <label htmlFor="amount" className="mb-2 block text-sm font-medium">
              Descripción
            </label>
            <div className="relative mt-2 rounded-md">
              <div className="relative">
                <input
                  id="amount"
                  name="amount"
                  type="text"
                  step="0.01"
                  placeholder="Ingrese la descripción de la compra"
                  className="peer block w-full rounded-md border border-gray-200 py-2 pl-10 text-sm outline-2 placeholder:text-gray-500"
                />
                <PencilSquareIcon className="pointer-events-none absolute left-3 top-1/2 h-[18px] w-[18px] -translate-y-1/2 text-gray-500 peer-focus:text-gray-900" />
              </div>
            </div>
          </div>

        </div>
        <div className="mt-6 flex justify-end gap-4">
          <Link
            href="/"
            className="flex h-10 items-center rounded-lg bg-gray-100 px-4 text-sm font-medium text-gray-600 transition-colors hover:bg-gray-200"
          >
            Cancelar
          </Link>
          <Button type="submit">Agregar</Button>
        </div>
      </form>
    </div>    
  );
}
