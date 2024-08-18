
import DetailsCard from './ui/dashboard/details-card';
import './ui/global.css';
import TransactionsHistoryTable from './ui/transaction-history/table';

export default function Page() {
  return (
    <>
      <DetailsCard />
      <TransactionsHistoryTable  />
    </>
  ) 
}
