import React, { useState } from "react";
import "./MyProtfolio.css";
import ReactPaginate from 'react-paginate';
import { IoIosArrowBack } from "react-icons/io";
import { IoIosArrowForward } from "react-icons/io";

const transactions = [
     { id: 1, fluctuations: '+$500', balance: '$1500', date: '2023-07-20', status: 'plus', content: 'Get from selling course A' },
     { id: 2, fluctuations: '-$200', balance: '$1300', date: '2023-07-21', status: 'sub', content: 'Buy the React course' },
     { id: 3, fluctuations: '+$300', balance: '$1600', date: '2023-07-22', status: 'plus', content: 'Get from selling course B' },
     { id: 4, fluctuations: '-$100', balance: '$1500', date: '2023-07-23', status: 'sub', content: 'Buy .NET course' },
     { id: 5, fluctuations: '-$100', balance: '$1600', date: '2023-07-25', status: 'sub', content: 'Buy a Project Management course' },
     { id: 6, fluctuations: '+$500', balance: '$2100', date: '2023-07-20', status: 'plus', content: 'Get from selling course C' },
     { id: 7, fluctuations: '-$200', balance: '$1900', date: '2023-07-21', status: 'sub', content: 'Buy C++ course' },
     { id: 8, fluctuations: '+$300', balance: '$2200', date: '2023-07-22', status: 'plus', content: 'Get from selling course D' },
     { id: 9, fluctuations: '-$100', balance: '$2100', date: '2023-07-23', status: 'sub', content: 'Buy SQL course' },
     { id: 10, fluctuations: '-$100', balance: '$2000', date: '2023-07-25', status: 'sub', content: 'Buy the Angola course' },
];

const TransactionTable = () => {
     const ITEMS_PER_PAGE = 5;

     const [currentPage, setCurrentPage] = useState(0);

     const handlePageClick = (event) => {
          setCurrentPage(event.selected);
     };

     const offset = currentPage * ITEMS_PER_PAGE;
     const currentPageItems = transactions.slice(offset, offset + ITEMS_PER_PAGE);
     return (
          <div id="transaction-table">
               <div className="header-table">
                    <h2>Recent Transactions</h2>
                    <ReactPaginate
                         previousLabel={<IoIosArrowBack />}
                         nextLabel={<IoIosArrowForward />}
                         breakLabel={'...'}
                         breakClassName={'break-me'}
                         pageCount={Math.ceil(transactions.length / ITEMS_PER_PAGE)}
                         marginPagesDisplayed={2}
                         pageRangeDisplayed={5}
                         onPageChange={handlePageClick}
                         containerClassName={'pagination'}
                         activeClassName={'active'}
                    />
               </div>
               <table>
                    <thead>
                         <tr>
                              <th>No</th>
                              <th>Fluctuations</th>
                              <th>Amount</th>
                              <th>Date</th>
                              <th>Content</th>
                         </tr>
                    </thead>
                    <tbody>
                         {currentPageItems.map(transaction => (
                              <tr key={transaction.id}>
                                   <td>{transaction.id}</td>
                                   <td className={`Flu-${transaction.status === "plus" ? "plus" : "sub"}`}>{transaction.fluctuations}</td>
                                   <td><strong>{transaction.balance}</strong></td>
                                   <td>{transaction.date}</td>
                                   <td>{transaction.content}</td>
                              </tr>
                         ))}
                    </tbody>
               </table>
          </div>
     );
};
export default TransactionTable;