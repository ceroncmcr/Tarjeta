"use client";
import { getAccountStatement } from "@/app/lib/data";

export default function AccountStatementToPDF() {
  async function GetAccountStatement() {
    const response = await getAccountStatement("123456789012");
    const base64String = `data:application/pdf;base64,${ response.value.b64}`;
    const downloadLink = document.createElement("a");
    const fileName = "EstadoCuenta.pdf";
    downloadLink.href = base64String;
    downloadLink.download = fileName;
    downloadLink.click();
  }

  return (    
    <button 
      className="flex h-10 items-center rounded-lg bg-blue-500 px-4 text-sm font-medium text-white transition-colors hover:bg-blue-400 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-blue-500 active:bg-blue-600 aria-disabled:cursor-not-allowed aria-disabled:opacity-50"
    onClick={GetAccountStatement}>Generar Estado de Cuenta</button>    
  );
}
