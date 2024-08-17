"use client";
import Link from 'next/link';
import {
  CalendarDaysIcon,    
  CurrencyDollarIcon,  
} from '@heroicons/react/24/outline';
import { Button } from '@/app/ui/button';
import { ChangeEvent, FormEvent, useState } from 'react';
import { addPayment } from '@/app/lib/data';
import Swal from 'sweetalert2';

export default function CreatePaymentForm() {

  const [payment, setPayment] = useState({
    cardNumber: "123456789012",    
    paymentDate: "",
    amount: 0,
  });

  function handleChange(e: ChangeEvent<HTMLInputElement>) {    
    setPayment({ ...payment, [e.target.name]: e.target.value });
  }

  async function submit(e: FormEvent<HTMLFormElement>) {
    e.preventDefault();
    const response = await addPayment(payment);    

    if (response.statusCode == 200) {
      Swal.fire({
        position: "top-end",
        icon: "success",
        title: "Pago guardado correctamente",
        showConfirmButton: false,
        timer: 1000
      });
      setPayment({ ...payment, amount: 0, paymentDate: "" });
    }
  }

  return (
    <div className='w-full'>
      <h1 className=' mb-8 text-xl md:text-2xl'>
        Agregar Pago
      </h1> 
      <form onSubmit={submit}>
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
                  onChange={handleChange}
                  value={payment.amount}
                  placeholder="Ingrese el monto"
                  className="peer block w-full rounded-md border border-gray-200 py-2 pl-10 text-sm outline-2 placeholder:text-gray-500"
                />
                <CurrencyDollarIcon className="pointer-events-none absolute left-3 top-1/2 h-[18px] w-[18px] -translate-y-1/2 text-gray-500 peer-focus:text-gray-900" />
              </div>
            </div>
          </div>
          
          <div className="mb-4">
            <label htmlFor="paymentDate" className="mb-2 block text-sm font-medium">
              Fecha
            </label>
            <div className="relative mt-2 rounded-md">
              <div className="relative">
                <input
                  id="paymentDate"
                  name="paymentDate"
                  type="date"   
                  onChange={handleChange}
                  value={payment.paymentDate}                                 
                  className="peer block w-full rounded-md border border-gray-200 py-2 pl-10 text-sm outline-2 placeholder:text-gray-500"
                />
                <CalendarDaysIcon className="pointer-events-none absolute left-3 top-1/2 h-[18px] w-[18px] -translate-y-1/2 text-gray-500 peer-focus:text-gray-900" />
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
